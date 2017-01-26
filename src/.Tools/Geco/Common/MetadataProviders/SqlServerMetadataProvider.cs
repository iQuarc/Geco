using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Geco.Common.Metadata;

namespace Geco.Common.MetadataProviders
{
    public class SqlServerMetadataProvider : IMetadataProvider
    {
        private readonly string connectionString;
        public SqlServerMetadataProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        ///     Loads metadata from a database
        /// </summary>
        /// <returns></returns>
        public DatabaseMetadata LoadMetadata()
        {
            var db = new DatabaseMetadata();
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

            db.Freeze();
            return db;
        }

        private IEnumerable<TableInfo> LoadTables()
        {
            return Query<TableInfo>(
                "SELECT t.name as Name, OBJECT_SCHEMA_NAME(t.object_id) as [SchemaName]" +
                "FROM sys.tables t " +
                "WHERE t.name NOT like 'sysdiagrams' ");
        }

        private IEnumerable<ColumnInfo> LoadColumns()
        {
            return Query<ColumnInfo>(
                "SELECT " +
                "  t.name as TableName, " +
                "  OBJECT_SCHEMA_NAME(t.object_id) as SchemaName, " +
                "  c.name as Name, " +
                "  ty.name as DataType, " +
                "  c.precision as Precision, " +
                "  c.scale as Scale, " +
                "  c.max_length as MaxLength, " +
                "  c.is_nullable as IsNullable, " +
                "  c.is_rowguidcol as IsRowGuidCol, " +
                "  CASE WHEN EXISTS (SELECT 1 " +
                "        FROM sys.index_columns ic " +
                "        INNER JOIN sys.indexes i ON ic.object_id = i.object_id AND i.index_id = ic.index_id" +
                "        INNER JOIN sys.key_constraints kc ON kc.parent_object_id = i.object_id " +
                "        WHERE i.is_primary_key = 1 AND i.type = 1 AND kc.type = 'PK' AND ic.column_id = c.column_id AND ic.object_id = c.object_id) " +
                "  THEN 1 " +
                "  ELSE 0 END as IsKey, " +
                "  columnproperty(t.object_id, c.name ,'IsIdentity') as IsIdentity, " +
                "  object_definition(c.default_object_id) as DefaultValue " +
                "FROM sys.columns c " +
                "INNER JOIN sys.tables t ON c.object_id = t.object_id " +
                "INNER JOIN sys.types ty ON c.user_type_id = ty.user_type_id " +
                "WHERE t.Name NOT LIKE 'sysdiagrams' " +
                "ORDER BY SchemaName, TableName, c.column_id ");
        }

        private IEnumerable<ForeignKeyInfo> LoadForeignKeys()
        {
            return Query<ForeignKeyInfo>(
                "SELECT " +
                "  f.name as Name, " +
                "  OBJECT_SCHEMA_NAME(f.parent_object_id) as ParentTableSchema, " +
                "  OBJECT_NAME(f.parent_object_id) as ParentTable, " +
                "  OBJECT_SCHEMA_NAME(f.referenced_object_id) as ReferencedTableSchema, " +
                "  OBJECT_NAME(f.referenced_object_id) as ReferencedTable, " +
                "  cp.name as ParentColumn, " +
                "  cr.name as ReferencedColumn " +
                "FROM sys.foreign_keys f " +
                "INNER JOIN sys.foreign_key_columns fkp ON fkp.constraint_object_id = f.object_id " +
                "INNER JOIN sys.columns cp ON fkp.parent_object_id = cp.object_id AND fkp.parent_column_id = cp.column_id " +
                "INNER JOIN sys.columns cr ON fkp.referenced_object_id = cr.object_id AND fkp.referenced_column_id= cr.column_id " +
                "WHERE OBJECT_NAME(f.parent_object_id) NOT LIKE 'sysdiagrams' AND OBJECT_NAME(f.referenced_object_id) NOT LIKE 'sysdiagrams' ");
        }

        private IEnumerable<TriggerInfo> LoadTriggerInfo()
        {
            return Query<TriggerInfo>(
                "SELECT tr.name, OBJECT_NAME(tr.parent_id) as  ParentTable, OBJECT_SCHEMA_NAME(tr.parent_id) as ParentTableSchema " +
                "FROM sys.triggers tr " +
                "WHERE OBJECT_NAME(tr.parent_id) NOT LIKE 'sysdiagrams' ");
        }

        private IEnumerable<IndexInfo> LoadIndexInfo()
        {
            return Query<IndexInfo>(@"
                SELECT 
	                OBJECT_SCHEMA_NAME(si.object_id) as SchemaName,
	                OBJECT_NAME(si.object_id) as TableName,
	                c.name as ColumnName,
	                si.name as IndexName,
	                si.is_unique as IsUnique,
	                CASE WHEN si.type = 1 THEN 1 ELSE 0 END AS IsClustered,
	                ic.is_included_column as IsIncluded
                FROM sys.index_columns ic
                INNER JOIN sys.indexes si ON ic.object_id = si.object_id AND ic.index_id = si.index_id
                INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
                WHERE OBJECTPROPERTY(si.object_id, 'IsUserTable') = 1 AND OBJECT_NAME(si.object_id) NOT LIKE 'sysdiagrams'
                ORDER BY SchemaName, TableName, si.index_id, ic.column_id");
        }

        public IEnumerable<T> Query<T>(string query)
            where T : new()
        {
            using (var cnn = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(query, cnn))
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





        private class TableInfo
        {
            public string Name { get; set; }
            public string SchemaName { get; set; }
        }

        private class TriggerInfo
        {
            public string Name { get; set; }
            public string ParentTableSchema { get; set; }
            public string ParentTable { get; set; }
        }

        private class ColumnInfo
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

        private class ForeignKeyInfo
        {
            public string Name { get; set; }
            public string ParentTableSchema { get; set; }
            public string ParentTable { get; set; }
            public string ReferencedTableSchema { get; set; }
            public string ReferencedTable { get; set; }
            public string ParentColumn { get; set; }
            public string ReferencedColumn { get; set; }
        }

        private class IndexInfo
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

    public static class MetadataCollectionExtensions
    {
        public static T GetOrAdd<T>(this MetadataCollection<T> collection, string key, Func<T> factory)
            where T : class, IMetadataItem
        {
            if (!collection.ContainsKey(key))
            {
                var item = factory();
                var writable = collection.GetWritable();
                writable[key] = item;
                return item;
            }
            return collection[key];
        }
    }
}