using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;
using Geco.Common.Inflector;
using Geco.Common.Templates;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Geco.Database;

/// <summary>
///    Generates seed scripts with merge statements for (Sql Server)
/// </summary>
[Options(typeof(SeedDataGeneratorOptions))]
public class SeedDataGenerator : BaseGeneratorWithMetadata
{
   private readonly Func<Column, bool>       columnsFilter = c => !c.IsComputed && c.DataType != "timestamp";
   private readonly IConfigurationRoot       configurationRoot;
   private readonly Func<Table, string>      mergeFilter = _ => null;
   private readonly SeedDataGeneratorOptions options;
   private          Func<Table, string>      whereClause = _ => null;

   public SeedDataGenerator(SeedDataGeneratorOptions options, IMetadataProvider provider, IInflector inflector,
      IConfigurationRoot configurationRoot, TemplateEngine templateEngine) : base(provider, inflector,
      options.ConnectionName)
   {
      TemplateEngine         = templateEngine;
      this.options           = options;
      this.configurationRoot = configurationRoot;
   }

   public TemplateEngine TemplateEngine { get; }

   protected override void Generate()
   {
      if (options.Tables.Count == 0 && string.IsNullOrEmpty(options.TablesRegex) &&
          options.ExcludedTables.Count == 0 && string.IsNullOrEmpty(options.ExcludedTablesRegex))
      {
         WriteLine(
            $"No tables were selected. Use options Tables, TableRegex, ExcludedTables or ExcludedTablesRegex to specify the tables for which Seed data will be generated ",
            Red);
         return;
      }

      whereClause = t => (!string.IsNullOrEmpty(options.FilterTemplate)
         ? TemplateEngine.RunTemplate(options.FilterTemplate, t, options)
         : null) ?? "";

      var tables = Db.Schemas.SelectMany(s => s.Tables)
         .Where(t => (options.Tables.Any(n => t.TableNameMatches(n))
                      || t.TableNameMatchesRegex(options.TablesRegex, false))
                     && !options.ExcludedTables.Any(n => t.TableNameMatches(n))
                     && !t.TableNameMatchesRegex(options.ExcludedTablesRegex, false))
         .OrderBy(t => t.Schema.Name + "." + t.Name).ToArray();
      TopologicalSort(tables);
      GenerateSeedFile(options.OutputFileName, tables);

      WriteLine($"File: '{Path.GetFileName(options.OutputFileName)}' was generated.",
         Yellow);
   }

   protected override TextWriter CreateFileWriter(string fileName)
   {
      if (options.Compressed)
      {
         if (!fileName.EndsWith(".gz"))
            fileName += ".gz";
         return new StreamWriter(new GZipStream(File.Create(fileName), CompressionLevel.Optimal, false), Encoding.UTF8);
      }

      return base.CreateFileWriter(fileName);
   }

   private void GenerateSeedFile(string file, IEnumerable<Table> tables)
   {
      var connectionString = configurationRoot.GetConnectionString(ConnectionName);
      using (BeginFile(file))
      {
         foreach (var table in tables)
            if (table.Metadata["is_memory_optimized"] == "False" && table.Metadata["temporal_type"] == "0")
            {
               using var cnn = new SqlConnection(connectionString);
               cnn.Open();
               using var tran = cnn.BeginTransaction(IsolationLevel.Snapshot);
               foreach (var tableValues in GetTableValues(table, cnn, tran).Batch(options.ItemsPerStatement))
                  GenerateTableSeed(table, tableValues);
            }
      }
   }

   private void GenerateTableSeed(Table table, IEnumerable<IEnumerable<object>> rowValues)
   {
      var columns = table.Columns.Where(columnsFilter).ToList();
      var rows    = rowValues.WithInfo().ToList();
      if (!rows.Any() && options.SkipEmpty)
         return;

      var onDelete = options.DeleteTables.Any(n => table.TableNameMatches(n)) ||
                     table.TableNameMatchesRegex(options.DeleteTablesRegex, false);

      if (table.Columns.Any(c => c.IsIdentity))
         W($"SET IDENTITY_INSERT [{table.Schema.Name}].[{table.Name}] ON");

      W($"MERGE [{table.Schema.Name}].[{table.Name}] AS Target");
      WI("USING ( VALUES ");
      var count = 0;
      foreach (var rowData in rows)
      {
         W($"({CommaJoin(rowData.Item, QuoteValue)})");
         if (!rowData.IsLast)
            Comma();
         count++;
      }

      DW($") As Source ({CommaJoin(columns, c => $"[{c.Name}]")}) ");
      W($"ON {string.Join(" AND ", GetMatchColumns(table))}");
      if (table.Columns.Any(c => !c.IsKey))
      {
         WI($"WHEN MATCHED {mergeFilter(table)}THEN UPDATE SET");

         foreach (var columnInfo in table.Columns.Where(c => columnsFilter(c) && !c.IsKey && !c.IsIdentity).WithInfo())
         {
            W($"Target.[{columnInfo.Item.Name}] = Source.[{columnInfo.Item.Name}]");
            if (!columnInfo.IsLast)
               Comma();
         }

         Dedent();
      }

      W("WHEN NOT MATCHED THEN");
      IW($"INSERT ({CommaJoin(columns, c => $"[{c.Name}]")})");
      WD($"VALUES ({CommaJoin(columns, c => $"Source.[{c.Name}]")})");
      SemiColon(!onDelete);

      WI("WHEN NOT MATCHED BY SOURCE THEN", onDelete);
      WD("DELETE;", onDelete);

      if (table.Columns.Any(c => c.IsIdentity))
         W($"SET IDENTITY_INSERT [{table.Schema.Name}].[{table.Name}] OFF");

      W("--GO");
      W();
      WriteLine(
         $"Generated merge script for {count} row{(count >= 2 ? "s" : "")} for [{table.Schema.Name}].[{table.Name}].",
         DarkYellow);
   }

   private static IEnumerable<string> GetMatchColumns(Table table)
   {
      if (table.Columns.Any(c => c.IsKey))
         return table.Columns.Where(c => c.IsKey).Select(c => $"Source.[{c.Name}] = Target.[{c.Name}]");
      return table.Columns.Select(c => $"Source.[{c.Name}] = Target.[{c.Name}]");
   }

   private IEnumerable<IEnumerable<object>> GetTableValues(Table table, SqlConnection cnn, SqlTransaction tran)
   {
      using (var cmd = new SqlCommand())
      {
         var columns = table.Columns
            .Where(columnsFilter)
            .ToList();
         var where = whereClause(table);
         if (options.TableFilters.TryGetWithTableNameKey(table, out var filter))
         {
            if (!string.IsNullOrEmpty(where))
               where += " AND ";
            where += $"({filter})";
         }

         cmd.CommandText =
            $"SELECT {CommaJoin(columns, ColumnExpression)} FROM [{table.Schema.Name}].[{table.Name}] T WHERE {(string.IsNullOrEmpty(where) ? "1=1" : where)}";
         cmd.Connection  = cnn;
         cmd.Transaction = tran;
         using (var rdr = cmd.ExecuteReader())
         {
            if (!rdr.Read())
            {
               if (!options.SkipEmpty)
                  yield return Enumerable.Empty<object>();
            }
            else
            {
               do
               {
                  var arr = new object[rdr.FieldCount];
                  rdr.GetValues(arr);
                  yield return arr;
               } while (rdr.Read());
            }
         }
      }
   }

   private string ColumnExpression(Column column)
   {
      if (!Db.TypeMappings.ContainsKey(column.DataType))
         return $"CAST(T.[{column.Name}] as NVARCHAR(MAX)) as[{column.Name}]";
      return $"T.[{column.Name}]";
   }

   private string QuoteValue(object value)
   {
      if (value == null || value == DBNull.Value)
         return "NULL";
      if (value is bool)
         return (bool)value ? "1" : "0";
      if (value is string || value is Guid)
         return "N'" + value.ToString().Trim().Replace("'", "''") + "'";
      if (value is DateTime)
         return "N'" + ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss:fff") + "'";
      if (value is DateTimeOffset)
         return "N'" + ((DateTimeOffset)value).ToString("yyyy-MM-dd HH:mm:ss.fffffff K") + "'";
      if (value is TimeSpan t)
         return "N'" + t + "'";

      var bs = value as byte[];
      if (bs != null)
      {
         var sb = new StringBuilder(bs.Length * 2 + 2);
         sb.Append("0x");
         foreach (var b in bs)
            sb.Append(b.ToString("X2"));
         return sb.ToString();
      }

      return value.ToString();
   }


   private void TopologicalSort(IList<Table> tables)
   {
      var sorted     = false;
      var comparer   = new TopologicalComparer();
      var iterations = 0;
      while (!sorted)
      {
         sorted = true;
         iterations++;
         if (iterations > 100)
            throw new InvalidOperationException(
               "Cannot sort tables due to cyclic relation between selected tables.");

         for (var i = 0; i < tables.Count - 1; i++)
         for (var j = i + 1; j < tables.Count; j++)
            if (comparer.Compare(tables[i], tables[j]) > 0)
            {
               var aux = tables[i];
               tables[i] = tables[j];
               tables[j] = aux;
               sorted    = false;
            }
      }
   }

   private class TopologicalComparer : IComparer<Table>
   {
      public int Compare(Table? source, Table? target)
      {
         if (source == null || target == null)
            return 0;

         // Source goes before any table that references is
         if (source.IncomingForeignKeys.Any(fk => fk.ParentTable.Equals(target)) ||
             target.ForeignKeys.Any(fk => fk.TargetTable.Equals(source)))
            return -1;

         // Source goes after any table which it references
         if (source.ForeignKeys.Any(fk => fk.TargetTable.Equals(target)) ||
             target.IncomingForeignKeys.Any(fk => fk.ParentTable.Equals(source)))
            return 1;

         return 0;
      }
   }
}