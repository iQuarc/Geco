using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using Geco.Common.SimpleMetadata;

namespace Geco.Common.MetadataProviders
{
    public abstract class MetadataProviderBase : IMetadataProvider
    {
        private DatabaseMetadata metadata = null;

        /// <summary>
        ///     Loads metadata from a database
        /// </summary>
        /// <param name="connectionName"></param>
        /// <returns></returns>
        public DatabaseMetadata LoadMetadata(string connectionName)
        {
            var sw = new Stopwatch();
            sw.Start();
            this.ConnectionName = connectionName;
            DatabaseMetadata db;
            using (Connection = CreateConection())
            {
                Connection.Open();
                db = new DatabaseMetadata(GetName(), GetClrTypeMappings());
                foreach (var table in LoadTables())
                {
                    var schema = db.Schemas.GetOrAdd(table.SchemaName, () => new Schema(table.SchemaName));
                    schema.Tables.Add(new Table(table.Name, schema).WithMetadata(table));
                }

                foreach (var column in LoadColumns())
                {
                    var schema = db.Schemas[column.SchemaName];
                    var table = schema.Tables[column.TableName];

                    table.Columns.Add(new Column(column.Name, table, column.DataType, column.Precision, column.Scale, column.MaxLength,
                        column.IsNullable, column.IsKey, column.IsIdentity, column.IsRowguidCol, column.IsComputed, column.DefaultValue).WithMetadata(column));
                }

                foreach (var foreignKey in LoadForeignKeys().GroupBy(x => new { x.ParentTableSchema, x.ParentTable, x.ReferencedTable, x.ReferencedTableSchema, x.Name }))
                {
                    var parentTable = db.Schemas[foreignKey.Key.ParentTableSchema].Tables[foreignKey.Key.ParentTable];
                    var targetTable = db.Schemas[foreignKey.Key.ReferencedTableSchema].Tables[foreignKey.Key.ReferencedTable];

                    var parentColumns = new ReadOnlyCollection<Column>(parentTable.Columns.Where(c => foreignKey.Any(x => x.ParentColumn == c.Name)).ToList());
                    var targetColumns = new ReadOnlyCollection<Column>(parentTable.Columns.Where(c => foreignKey.Any(x => x.ReferencedColumn == c.Name)).ToList());

                    var fk = parentTable.ForeignKeys.GetOrAdd(foreignKey.Key.Name,
                        () => new ForeignKey(foreignKey.Key.Name, parentTable, targetTable, parentColumns, targetColumns));

                    targetTable.IncomingForeignKeys.GetOrAdd(foreignKey.Key.Name, () => fk);
                    foreach (var parentColumn in parentColumns)
                    {
                        parentColumn.ForeignKey = fk;
                    }
                }

                foreach (var trigger in LoadTriggerInfo())
                {
                    var schema = db.Schemas[trigger.ParentTableSchema];
                    var table = schema.Tables[trigger.ParentTable];

                    table.Triggers.GetOrAdd(trigger.Name, () => new Trigger(trigger.Name, table).WithMetadata(trigger));
                }

                foreach (var indexInfo in LoadIndexInfo())
                {
                    var schema = db.Schemas[indexInfo.SchemaName];
                    var table = schema.Tables[indexInfo.TableName];
                    var column = table.Columns[indexInfo.ColumnName];

                    var index = table.Indexes.GetOrAdd(indexInfo.IndexName, () => new Index(indexInfo.IndexName, table, indexInfo.IsUnique, indexInfo.IsClustered).WithMetadata(indexInfo));
                    if (indexInfo.IsIncluded)
                        index.IncludedColumns.Add(column);
                    else
                        index.Columns.Add(column);
                }

            }
            sw.Stop();
            ColorConsole.WriteLine(("Database Metadata loaded in ", ConsoleColor.DarkYellow), ($"{sw.ElapsedMilliseconds} ms", ConsoleColor.Green));
            return db;
        }
        protected string ConnectionName { get; private set; }
        private DbConnection Connection { get; set; }

        public DatabaseMetadata GetMetadata(string connectionName)
        {
            return metadata ?? (metadata = LoadMetadata(connectionName));
        }

        public void Reload()
        {
            metadata = null;
        }

        protected abstract string GetName();
        protected abstract IEnumerable<TableInfo> LoadTables();
        protected abstract IEnumerable<ColumnInfo> LoadColumns();
        protected abstract IEnumerable<ForeignKeyInfo> LoadForeignKeys();
        protected abstract IEnumerable<TriggerInfo> LoadTriggerInfo();
        protected abstract IEnumerable<IndexColumnInfo> LoadIndexInfo();


        protected abstract DbConnection CreateConection();
        protected abstract DbCommand CreateCommand(DbConnection cnn, string commandText);

        protected abstract IReadOnlyDictionary<string, Type> GetClrTypeMappings();

        protected virtual IEnumerable<T> Query<T>(string query)
            where T : IMetadataItem, new()
        {
            using (var cmd = CreateCommand(Connection, query))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    foreach (var value in QueryUtil.MaterializeReader<T>(rdr))
                    {
                        yield return value;
                    }
                }
            }
        }

        protected virtual T? Scalar<T>(string query)
            where T : struct
        {
            using (var cmd = CreateCommand(Connection, "SELECT DB_NAME()"))
            {
                var result = cmd.ExecuteScalar();
                return result == DBNull.Value ? default(T) : (T)result;
            }
        }

        protected virtual string Scalar(string query)
        {
            using (var cmd = CreateCommand(Connection, "SELECT DB_NAME()"))
            {
                var result = cmd.ExecuteScalar();
                return result == DBNull.Value ? null : (string)result;
            }
        }

        protected class TableInfo : IMetadataItem
        {
            public string Name { get; set; }
            public string SchemaName { get; set; }

            public IDictionary<string, string> Metadata { get; } = new ConcurrentDictionary<string, string>();
        }

        protected class TriggerInfo : IMetadataItem
        {
            public string Name { get; set; }
            public string ParentTableSchema { get; set; }
            public string ParentTable { get; set; }

            public IDictionary<string, string> Metadata { get; } = new ConcurrentDictionary<string, string>();
        }

        protected class ColumnInfo : IMetadataItem
        {
            public string DataType { get; set; }
            public bool IsKey { get; set; }
            public bool IsIdentity { get; set; }
            public bool IsNullable { get; set; }
            public bool IsRowguidCol { get; set; }
            public bool IsComputed { get; set; }
            public int MaxLength { get; set; }
            public string Name { get; set; }
            public int Precision { get; set; }
            public int Scale { get; set; }
            public string SchemaName { get; set; }
            public string TableName { get; set; }
            public string DefaultValue { get; set; }

            public IDictionary<string, string> Metadata { get; } = new ConcurrentDictionary<string, string>();
        }

        protected class ForeignKeyInfo : IMetadataItem
        {
            public string Name { get; set; }
            public string ParentTableSchema { get; set; }
            public string ParentTable { get; set; }
            public string ReferencedTableSchema { get; set; }
            public string ReferencedTable { get; set; }
            public string ParentColumn { get; set; }
            public string ReferencedColumn { get; set; }

            public IDictionary<string, string> Metadata { get; } = new ConcurrentDictionary<string, string>();
        }

        protected class IndexColumnInfo : IMetadataItem
        {
            public string SchemaName { get; set; }
            public string TableName { get; set; }
            public string ColumnName { get; set; }
            public string IndexName { get; set; }
            public bool IsUnique { get; set; }
            public bool IsClustered { get; set; }
            public bool IsIncluded { get; set; }

            public string Name => $"[{TableName}].[{ColumnName}]";
            public IDictionary<string, string> Metadata { get; } = new ConcurrentDictionary<string, string>();
        }


    }
}