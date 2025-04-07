using System.Collections.Concurrent;
using System.Data.Common;
using System.Diagnostics;

namespace Geco.Common.MetadataProviders;

public abstract class MetadataProviderBase : IMetadataProvider
{
   private   DatabaseMetadata? metadata;
   protected string?           ConnectionName { get; private set; }
   private   DbConnection?     Connection     { get; set; }

   public DatabaseMetadata GetMetadata(string connectionName)
   {
      return metadata ??= LoadMetadata(connectionName);
   }

   public void Reload()
   {
      metadata = null;
   }

   /// <summary>
   ///    Loads metadata from a database
   /// </summary>
   /// <param name="connectionName"></param>
   /// <returns></returns>
   public DatabaseMetadata LoadMetadata(string connectionName)
   {
      var sw = new Stopwatch();
      sw.Start();
      ConnectionName = connectionName;
      DatabaseMetadata db;

      using (Connection = CreateConnection())
      {
         Connection.Open();
         db = new DatabaseMetadata(GetName(), GetClrTypeMappings());

         foreach (var tableInfo in LoadTables())
         {
            var schema = db.Schemas.GetOrAdd(tableInfo.SchemaName, () => new Schema(tableInfo.SchemaName, db));
            schema.Tables.Add(new Table(tableInfo.Name, schema).WithMetadata(tableInfo));
         }

         foreach (var columnInfo in LoadColumns())
         {
            var schema = db.Schemas[columnInfo.SchemaName];
            var table  = schema.Tables[columnInfo.TableName];
            var index  = table.Columns.Count;

            table.Columns.Add(new Column(columnInfo.Name, table, index, columnInfo.DataType,
                  columnInfo.Precision, columnInfo.Scale, columnInfo.MaxLength,
                  columnInfo.IsNullable, columnInfo.IsKey, columnInfo.IsIdentity, columnInfo.IsRowGuidCol,
                  columnInfo.IsComputed, columnInfo.DefaultValue, columnInfo.ComputedDefinition)
               .WithMetadata(columnInfo));
         }

         foreach (var foreignKeyInfo in LoadForeignKeys())
         {
            var parentTable = db.Schemas[foreignKeyInfo.ParentTableSchema].Tables[foreignKeyInfo.ParentTable];

            var targetTable = db.Schemas[foreignKeyInfo.ReferencedTableSchema]
               .Tables[foreignKeyInfo.ReferencedTable];

            var fk = parentTable.ForeignKeys.GetOrAdd(foreignKeyInfo.Name,
               () => new ForeignKey(foreignKeyInfo.Name, parentTable, targetTable, foreignKeyInfo.UpdateAction,
                  foreignKeyInfo.DeleteAction).WithMetadata(foreignKeyInfo));

            var parentColumn = parentTable.Columns[foreignKeyInfo.ParentColumn];
            fk.FromColumns.Add(parentColumn);
            parentColumn.ForeignKey = fk;

            var targetColumn = targetTable.Columns[foreignKeyInfo.ReferencedColumn];
            fk.ToColumns.Add(targetColumn);

            targetTable.IncomingForeignKeys.GetOrAdd(foreignKeyInfo.Name, () => fk);
         }

         foreach (var triggerInfo in LoadTriggerInfo())
         {
            var schema = db.Schemas[triggerInfo.ParentTableSchema];
            var table  = schema.Tables[triggerInfo.ParentTable];

            table.Triggers.GetOrAdd(triggerInfo.Name,
               () => new Trigger(triggerInfo.Name, table).WithMetadata(triggerInfo));
         }

         foreach (var indexInfo in LoadIndexInfo())
         {
            var schema = db.Schemas[indexInfo.SchemaName];
            var table  = schema.Tables[indexInfo.TableName];
            var column = table.Columns[indexInfo.ColumnName];

            var index = table.Indexes.GetOrAdd(indexInfo.IndexName,
               () => new DataBaseIndex(indexInfo.IndexName, table, indexInfo.IsUnique, indexInfo.IsClustered)
                  .WithMetadata(indexInfo));

            if (indexInfo.IsIncluded)
               index.IncludedColumns.Add(column);
            else
               index.Columns.Add(column);
         }
      }

      sw.Stop();

      WriteLine(("Database Metadata loaded in ", DarkYellow),
         ($"{sw.ElapsedMilliseconds} ms", Green));

      return db;
   }

   protected abstract string                       GetName();
   protected abstract IEnumerable<TableInfo>       LoadTables();
   protected abstract IEnumerable<ColumnInfo>      LoadColumns();
   protected abstract IEnumerable<ForeignKeyInfo>  LoadForeignKeys();
   protected abstract IEnumerable<TriggerInfo>     LoadTriggerInfo();
   protected abstract IEnumerable<IndexColumnInfo> LoadIndexInfo();


   protected abstract DbConnection                      CreateConnection();
   protected abstract DbCommand                         CreateCommand(DbConnection cnn, string commandText);
   protected abstract IReadOnlyDictionary<string, Type> GetClrTypeMappings();

   protected virtual IEnumerable<T> Query<T>(string query)
      where T : IMetadataItem
   {
      using var cmd = CreateCommand(Connection ?? throw new InvalidOperationException("Connection is not set"), query);
      using var rdr = cmd.ExecuteReader();
      foreach (var value in QueryUtil.MaterializeReader<T>(rdr))
         yield return value;
   }

   protected virtual T? Scalar<T>(string query)
      where T : struct
   {
      using var cmd = CreateCommand(Connection ?? throw new InvalidOperationException("Connection is not set"), query);
      var       result = cmd.ExecuteScalar();
      return result == null || result == DBNull.Value ? default : (T)result;
   }

   protected virtual string? Scalar(string query)
   {
      using var cmd = CreateCommand(Connection ?? throw new InvalidOperationException("Connection is not set"), query);
      var       result = cmd.ExecuteScalar();
      return result == null || result == DBNull.Value ? null : (string)result;
   }

   protected class TableInfo : IMetadataItem
   {
      public required string SchemaName         { get; set; }
      public required string Name               { get; set; }
      public required string FullyQualifiedName { get; set; }

      public IDictionary<string, string?> Metadata { get; } = new ConcurrentDictionary<string, string?>();
   }

   protected class TriggerInfo : IMetadataItem
   {
      public required string ParentTableSchema  { get; set; }
      public required string ParentTable        { get; set; }
      public required string Name               { get; set; }
      public required string FullyQualifiedName { get; set; }

      public IDictionary<string, string?> Metadata { get; } = new ConcurrentDictionary<string, string?>();
   }

   protected class ColumnInfo : IMetadataItem
   {
      public required string  DataType           { get; set; }
      public          bool    IsKey              { get; set; }
      public          bool    IsIdentity         { get; set; }
      public          bool    IsNullable         { get; set; }
      public          bool    IsRowGuidCol       { get; set; }
      public          bool    IsComputed         { get; set; }
      public          int     MaxLength          { get; set; }
      public          int     Precision          { get; set; }
      public          int     Scale              { get; set; }
      public required string  SchemaName         { get; set; }
      public required string  TableName          { get; set; }
      public required string  DefaultValue       { get; set; }
      public          string? ComputedDefinition { get; set; }
      public required string  Name               { get; set; }
      public required string  FullyQualifiedName { get; set; }

      public IDictionary<string, string?> Metadata { get; } = new ConcurrentDictionary<string, string?>();
   }

   protected class ForeignKeyInfo : IMetadataItem
   {
      public required string                       ParentTableSchema { get; set; }
      public required string                       ParentTable { get; set; }
      public required string                       ReferencedTableSchema { get; set; }
      public required string                       ReferencedTable { get; set; }
      public required string                       ParentColumn { get; set; }
      public required string                       ReferencedColumn { get; set; }
      public          ForeignKeyAction             UpdateAction { get; set; }
      public          ForeignKeyAction             DeleteAction { get; set; }
      public required string                       Name { get; set; }
      public required string                       FullyQualifiedName { get; set; }
      public          IDictionary<string, string?> Metadata { get; } = new ConcurrentDictionary<string, string?>();
   }

   protected class IndexColumnInfo : IMetadataItem
   {
      public required string SchemaName  { get; set; }
      public required string TableName   { get; set; }
      public required string ColumnName  { get; set; }
      public required string IndexName   { get; set; }
      public          bool   IsUnique    { get; set; }
      public          bool   IsClustered { get; set; }
      public          bool   IsIncluded  { get; set; }

      public          string                       Name => $"[{TableName}].[{ColumnName}]";
      public required string                       FullyQualifiedName { get; set; }
      public          IDictionary<string, string?> Metadata { get; } = new ConcurrentDictionary<string, string?>();
   }
}