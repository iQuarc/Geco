using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Geco.Common;
using Geco.Common.SimpleMetadata;
using Microsoft.Extensions.Configuration;

namespace Geco.Database
{
    /// <summary>
    /// Generates seed scripts with merge statements for (Sql Server)
    /// </summary>
    [Options(typeof(SeedDataGeneratorOptions))]
    public class SeedDataGenerator : BaseGeneratorWithMetadata
    {
        private readonly SeedDataGeneratorOptions options;
        private readonly IConfigurationRoot configurationRoot;

        private readonly Func<Column, bool> columnsFilter = c => !c.IsComputed;
        private readonly Func<Table, string> whereClause = _ => null;
        private readonly Func<Table, string> mergeFilter = _ => null;

        public SeedDataGenerator(SeedDataGeneratorOptions options, IMetadataProvider provider, IInflector inflector, IConfigurationRoot configurationRoot) : base(provider, inflector, options.ConnectionName)
        {
            this.options = options;
            this.configurationRoot = configurationRoot;
        }

        protected override void Generate()
        {
            var tables = Db.Schemas.SelectMany(s => s.Tables)
                .Where(t => (options.Tables.Any(n => TableNameMaches(t, n))
                || TableNameMachesRegex(t, options.TablesRegex))
                && !options.ExcludedTables.Any(n => TableNameMaches(t, n))
                && !TableNameMachesRegex(t, options.ExcludedTablesRegex)).OrderBy(t => t.Schema.Name + "." + t.Name).ToArray();
            TopologicalSort(tables);
            GenerateSeedFile(options.OutputFileName, tables);

            ColorConsole.WriteLine($"File: '{Path.GetFileName(options.OutputFileName)}' was generated.", ConsoleColor.Yellow);
        }

        private bool TableNameMachesRegex(Table table, string tablesRegex)
        {
            return !String.IsNullOrWhiteSpace(tablesRegex) && (
                   Regex.IsMatch(table.Name, tablesRegex) ||
                   Regex.IsMatch($"[{table.Name}]", tablesRegex) ||
                   Regex.IsMatch($"{table.Schema.Name}.{table.Name}", tablesRegex) ||
                   Regex.IsMatch($"[{table.Schema.Name}].[{table.Name}]", tablesRegex));
        }

        private bool TableNameMaches(Table table, string name)
        {
            return string.Equals(name, table.Name, StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(name, $"[{table.Name}]", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(name, $"{table.Schema.Name}.{table.Name}", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(name, $"[{table.Schema.Name}].[{table.Name}]", StringComparison.OrdinalIgnoreCase);
        }

        private void GenerateSeedFile(string file, IEnumerable<Table> tables)
        {
            using (BeginFile(file))
            {
                foreach (var table in tables)
                {
                    if (table.Metadata["is_memory_optimized"] == "False" && table.Metadata["temporal_type"] == "0")
                        foreach (var tableValues in GetTableValues(table)
                            .Batch(options.ItemsPerStatement))
                            GenerateTableSeed(table, tableValues);
                }
            }
        }

        private void GenerateTableSeed(Table table, IEnumerable<IEnumerable<object>> rowValues)
        {
            var columns = table.Columns.Where(columnsFilter).ToList();
            var rows = rowValues.WithInfo();
            if (!rows.Any())
                return;


            if (table.Columns.Any(c => c.IsIdentity))
                W($"SET IDENTITY_INSERT [{table.Schema.Name}].[{table.Name}] ON");

            W($"MERGE [{table.Schema.Name}].[{table.Name}] AS Target");
            WI($"USING ( VALUES ");
            int count = 0;
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

                foreach (var columnInfo in table.Columns.Where(c => columnsFilter(c) && !c.IsKey).WithInfo())
                {
                    W($"Target.[{columnInfo.Item.Name}] = Source.[{columnInfo.Item.Name}]");
                    if (!columnInfo.IsLast)
                        Comma();
                }
                Dedent();
            }
            W("WHEN NOT MATCHED THEN");
            IW($"INSERT ({CommaJoin(columns, c => $"[{c.Name}]")})");
            WD($"VALUES ({CommaJoin(columns, c => $"Source.[{c.Name}]")});");

            if (table.Columns.Any(c => c.IsIdentity))
                W($"SET IDENTITY_INSERT [{table.Schema.Name}].[{table.Name}] OFF");

            W("--GO");
            W();
            ColorConsole.WriteLine($"Generated merge script for {count} row{(count >= 2 ? "s" : "")} for [{table.Schema.Name}].[{table.Name}].", ConsoleColor.DarkYellow);
        }

        private static IEnumerable<string> GetMatchColumns(Table table)
        {
            if (table.Columns.Any(c => c.IsKey))
                return table.Columns.Where(c => c.IsKey).Select(c => $"Source.[{c.Name}] = Target.[{c.Name}]");
            else
                return table.Columns.Select(c => $"Source.[{c.Name}] = Target.[{c.Name}]");
        }

        private IEnumerable<IEnumerable<object>> GetTableValues(Table table)
        {
            var connectionString = configurationRoot.GetConnectionString(ConnectionName);
            using (var cnn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand())
            {
                var columns = table.Columns
                    .Where(columnsFilter)
                    .ToList();
                var where = whereClause(table);
                cmd.CommandText = $"SELECT {CommaJoin(columns, ColumnExpression)} FROM [{table.Schema.Name}].[{table.Name}] WHERE {(String.IsNullOrEmpty(where) ? "1=1" : where)}";
                cnn.Open();
                cmd.Connection = cnn;
                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        var arr = new object[rdr.FieldCount];
                        rdr.GetValues(arr);
                        yield return arr;
                    }
                }
            }
        }

        private string ColumnExpression(Column column)
        {
            if (!Db.TypeMappings.ContainsKey(column.DataType))
            {
                return $"CAST([{column.Name}] as NVARCHAR(MAX)) as[{column.Name}]";
            }
            return $"[{column.Name}]";
        }


        private string QuoteValue(Object value)
        {
            if (value == null || value == DBNull.Value)
                return "NULL";
            if (value is bool)
                return ((bool)value) ? "1" : "0";
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
                var sb = new StringBuilder(bs.Length * 2 + 30);
                sb.Append("CONVERT(VARBINARY(MAX),N'");
                foreach (var b in bs)
                {
                    sb.Append(b.ToString("X2"));
                }
                sb.Append("',2)");
                return sb.ToString();
            }

            return value.ToString();
        }


        private void TopologicalSort(IList<Table> tables)
        {
            bool sorted = false;
            var comparer = new TopologicalComparer();
            var iterations = 0;
            while (!sorted)
            {
                sorted = true;
                iterations++;
                if (iterations > 10000)
                    throw new InvalidOperationException("Cannot sort tables due to cyclic relation between selected tables.");

                for (int i = 0; i < tables.Count - 1; i++)
                    for (int j = i + 1; j < tables.Count; j++)
                    {
                        if (comparer.Compare(tables[i], tables[j]) > 0)
                        {
                            var aux = tables[i];
                            tables[i] = tables[j];
                            tables[j] = aux;
                            sorted = false;
                        }
                    }
            }
        }

        private class TopologicalComparer : IComparer<Table>
        {
            public int Compare(Table source, Table target)
            {
                if (source == null || target == null)
                    return 0;

                if (source.IncomingForeignKeys.Any(fk => fk.ParentTable == target) || target.ForeignKeys.Any(fk => fk.TargetTable == source))
                    return -1;

                if (target.IncomingForeignKeys.Any(fk => fk.ParentTable == source) || source.ForeignKeys.Any(fk => fk.TargetTable == target))
                    return 1;

                return 0;
            }
        }
    }
}