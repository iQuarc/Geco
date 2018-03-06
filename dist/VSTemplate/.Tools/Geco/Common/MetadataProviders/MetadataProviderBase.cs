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
                foreach (var tableInfo in LoadTables())
                {
                    var schema = db.Schemas.GetOrAdd(tableInfo.SchemaName, () => new Schema(tableInfo.SchemaName));
                    schema.Tables.Add(new Table(tableInfo.Name, schema).WithMetadata(tableInfo));
                }

                foreach (var columnInfo in LoadColumns())
                {
                    var schema = db.Schemas[columnInfo.SchemaName];
                    var table = schema.Tables[columnInfo.TableName];
                    var index = table.Columns.Count;
                    table.Columns.Add(new Column(columnInfo.Name, table, index, columnInfo.DataType, columnInfo.Precision, columnInfo.Scale, columnInfo.MaxLength,
                        columnInfo.IsNullable, columnInfo.IsKey, columnInfo.IsIdentity, columnInfo.IsRowguidCol, columnInfo.IsComputed, columnInfo.DefaultValue).WithMetadata(columnInfo));
                }

                foreach (var foreignKeyInfo in LoadForeignKeys())
                {
                    var parentTable = db.Schemas[foreignKeyInfo.ParentTableSchema].Tables[foreignKeyInfo.ParentTable];
                    var targetTable = db.Schemas[foreignKeyInfo.ReferencedTableSchema]
                        .Tables[foreignKeyInfo.ReferencedTable];

                    var fk = parentTable.ForeignKeys.GetOrAdd(foreignKeyInfo.Name, 
                        () => new ForeignKey(foreignKeyInfo.Name, parentTable, targetTable, foreignKeyInfo.UpdateAction, foreignKeyInfo.DeleteAction).WithMetadata(foreignKeyInfo));

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
                    var table = schema.Tables[triggerInfo.ParentTable];

                    table.Triggers.GetOrAdd(triggerInfo.Name, () => new Trigger(triggerInfo.Name, table).WithMetadata(triggerInfo));
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
            using (var cmd = CreateCommand(Connection, query))
            {
                var result = cmd.ExecuteScalar();
                return result == DBNull.Value ? default(T) : (T)result;
            }
        }

        protected virtual string Scalar(string query)
        {
            using (var cmd = CreateCommand(Connection, query))
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
            public ForeignKeyAction UpdateAction { get; set; }
            public ForeignKeyAction DeleteAction { get; set; }
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