using System;
using System.Collections.Generic;
using System.Data.Common;
using Geco.Common.SimpleMetadata;

namespace Geco.Common.MetadataProviders
{
    public abstract class MetadataProviderBase : IMetadataProvider
    {
        /// <summary>
        ///     Loads metadata from a database
        /// </summary>
        /// <returns></returns>
        public DatabaseMetadata LoadMetadata(bool freeze)
        {
            var db = new DatabaseMetadata(GetClrTypeMappings());
            foreach (var table in LoadTables())
            {
                var schema = db.Schemas.GetOrAdd(table.SchemaName, () => new Schema(table.SchemaName, db));
                schema.Tables.Add(new Table(table.Name, schema));
            }

            foreach (var column in LoadColumns())
            {
                var schema = db.Schemas[column.SchemaName];
                var table = schema.Tables[column.TableName];

                table.Columns.Add(new Column(column.Name, table, column.DataType, column.Precision, column.Scale, column.MaxLength,
                    column.IsNullable, column.IsKey, column.IsIdentity, column.IsRowguidCol, column.DefaultValue));
            }

            foreach (var foreignKey in LoadForeignKeys())
            {
                var parentTable = db.Schemas[foreignKey.ParentTableSchema].Tables[foreignKey.ParentTable];
                var targetTable = db.Schemas[foreignKey.ReferencedTableSchema].Tables[foreignKey.ReferencedTable];
                var parentColumn = parentTable.Columns[foreignKey.ParentColumn];
                var targetColumn = targetTable.Columns[foreignKey.ReferencedColumn];

                var fk = parentTable.ForeignKeys.GetOrAdd(foreignKey.Name,
                    () => new ForeignKey(foreignKey.Name, parentTable, targetTable, parentColumn, targetColumn));

                targetTable.IncomingForeignKeys.GetOrAdd(foreignKey.Name, () => fk);
                parentColumn.ForeignKey = fk;
            }

            foreach (var trigger in LoadTriggerInfo())
            {
                var schema = db.Schemas[trigger.ParentTableSchema];
                var table = schema.Tables[trigger.ParentTable];

                table.Triggers.GetOrAdd(trigger.Name, () => new Trigger(trigger.Name, table));
            }

            foreach (var indexInfo in LoadIndexInfo())
            {
                var schema = db.Schemas[indexInfo.SchemaName];
                var table = schema.Tables[indexInfo.TableName];
                var column = table.Columns[indexInfo.ColumnName];

                var index = table.Indexes.GetOrAdd(indexInfo.IndexName, () => new Index(indexInfo.IndexName, table, indexInfo.IsUnique, indexInfo.IsClustered));
                if (indexInfo.IsIncluded)
                    index.IncludedColumns.Add(column);
                else
                    index.Columns.Add(column);
            }
            if (freeze)
                db.Freeze();
            return db;
        }

        protected abstract IEnumerable<TableInfo> LoadTables();
        protected abstract IEnumerable<ColumnInfo> LoadColumns();
        protected abstract IEnumerable<ForeignKeyInfo> LoadForeignKeys();
        protected abstract IEnumerable<TriggerInfo> LoadTriggerInfo();
        protected abstract IEnumerable<IndexColumnInfo> LoadIndexInfo();


        protected abstract DbConnection CreateConection();
        protected abstract DbCommand CreateCommand(DbConnection cnn, string commandText);

        protected abstract IReadOnlyDictionary<string, Type> GetClrTypeMappings();

        protected virtual IEnumerable<T> Query<T>(string query)
            where T : new()
        {
            using (var cnn = CreateConection())
            using (var cmd = CreateCommand(cnn, query))
            {
                cnn.Open();
                
                using (var rdr = cmd.ExecuteReader())
                {
                    foreach (var value in QueryUtil.MaterializeReader<T>(rdr))
                    {
                        yield return value;
                    }
                }
            }
        }

        protected class TableInfo
        {
            public string Name { get; set; }
            public string SchemaName { get; set; }
        }

        protected class TriggerInfo
        {
            public string Name { get; set; }
            public string ParentTableSchema { get; set; }
            public string ParentTable { get; set; }
        }

        protected class ColumnInfo
        {
            public string DataType { get; set; }
            public bool IsKey { get; set; }
            public bool IsIdentity { get; set; }
            public bool IsNullable { get; set; }
            public bool IsRowguidCol { get; set; }
            public int MaxLength { get; set; }
            public string Name { get; set; }
            public int Precision { get; set; }
            public int Scale { get; set; }
            public string SchemaName { get; set; }
            public string TableName { get; set; }
            public string DefaultValue { get; set; }
        }

        protected class ForeignKeyInfo
        {
            public string Name { get; set; }
            public string ParentTableSchema { get; set; }
            public string ParentTable { get; set; }
            public string ReferencedTableSchema { get; set; }
            public string ReferencedTable { get; set; }
            public string ParentColumn { get; set; }
            public string ReferencedColumn { get; set; }
        }

        protected class IndexColumnInfo
        {
            public string SchemaName { get; set; }
            public string TableName { get; set; }
            public string ColumnName { get; set; }
            public string IndexName { get; set; }
            public bool IsUnique { get; set; }
            public bool IsClustered { get; set; }
            public bool IsIncluded { get; set; }
        }
    }
}