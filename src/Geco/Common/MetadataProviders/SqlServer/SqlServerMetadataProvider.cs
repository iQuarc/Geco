﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace Geco.Common.MetadataProviders.SqlServer
{
    public class SqlServerMetadataProvider : MetadataProviderBase
    {
        private readonly IConfigurationRoot configurationRoot;
        public SqlServerMetadataProvider(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        protected override string GetName()
        {
            return Scalar("SELECT DB_NAME()");
        }

        protected override IEnumerable<TableInfo> LoadTables()
        {
            return Query<TableInfo>(
                @"SELECT 
                      t.name as Name, 
                      OBJECT_SCHEMA_NAME(t.object_id) as [SchemaName], 
                      t.is_memory_optimized, 
                      t.is_tracked_by_cdc, 
                      t.temporal_type
                FROM sys.tables t ");
        }

        protected override IEnumerable<ColumnInfo> LoadColumns()
        {
            return Query<ColumnInfo>(
                @"SELECT
                      SCHEMA_NAME(t.schema_id) as SchemaName,
                      t.name as TableName,
                      c.name as Name,
                      ISNULL(sty.name, ty.name) as DataType,
                      CAST(c.precision as int) as Precision,
                      CAST(c.scale as int) as Scale,
                      CAST(ISNULL(COLUMNPROPERTY(c.object_id, c.name, 'charmaxlen'), c.max_length) AS int) as MaxLength,
                      c.is_nullable as IsNullable,
                      c.is_rowguidcol as IsRowGuidCol,
                      CAST((CASE WHEN EXISTS (SELECT 1
                            FROM sys.index_columns ic
                            INNER JOIN sys.indexes i ON ic.object_id = i.object_id AND i.index_id = ic.index_id
                            INNER JOIN sys.key_constraints kc ON kc.parent_object_id = i.object_id
                            WHERE i.is_primary_key = 1 AND kc.type = 'PK' AND ic.column_id = c.column_id AND ic.object_id = c.object_id)
                      THEN 1
                      ELSE 0 END) AS Bit) as IsKey,
                      CAST(columnproperty(t.object_id, c.name ,'IsIdentity')  AS Bit) as IsIdentity,
                      object_definition(c.default_object_id) as DefaultValue,
                      is_computed as IsComputed
                FROM sys.columns c
                INNER JOIN sys.tables t ON c.object_id = t.object_id
                INNER JOIN sys.types ty ON c.user_type_id = ty.user_type_id
				LEFT JOIN sys.types sty ON ty.system_type_id = sty.user_type_id
                ORDER BY SchemaName, TableName, c.column_id");
        }

        protected override IEnumerable<ForeignKeyInfo> LoadForeignKeys()
        {
            return Query<ForeignKeyInfo>(
                @"SELECT 
                        f.name as Name, 
                        OBJECT_SCHEMA_NAME(f.parent_object_id) as ParentTableSchema, 
                        OBJECT_NAME(f.parent_object_id) as ParentTable,
                        OBJECT_SCHEMA_NAME(f.referenced_object_id) as ReferencedTableSchema, 
                        OBJECT_NAME(f.referenced_object_id) as ReferencedTable,
                        cp.name as ParentColumn,
                        cr.name as ReferencedColumn,
		                f.update_referential_action AS UpdateAction,
		                f.delete_referential_action as DeleteAction
                FROM sys.foreign_keys f
                INNER JOIN sys.foreign_key_columns fkp ON fkp.constraint_object_id = f.object_id
                INNER JOIN sys.columns cp ON fkp.parent_object_id = cp.object_id AND fkp.parent_column_id = cp.column_id
                INNER JOIN sys.columns cr ON fkp.referenced_object_id = cr.object_id AND fkp.referenced_column_id= cr.column_id");
        }

        protected override IEnumerable<TriggerInfo> LoadTriggerInfo()
        {
            return Query<TriggerInfo>(
                @"SELECT 
                    tr.name, OBJECT_NAME(tr.parent_id) as  ParentTable, OBJECT_SCHEMA_NAME(tr.parent_id) as ParentTableSchema
                FROM sys.triggers tr 
                WHERE tr.parent_class <> 0");
        }

        protected override IEnumerable<IndexColumnInfo> LoadIndexInfo()
        {
            return Query<IndexColumnInfo>(@"
                SELECT 
	                OBJECT_SCHEMA_NAME(si.object_id) as SchemaName,
	                OBJECT_NAME(si.object_id) as TableName,
	                c.name as ColumnName,
	                si.name as IndexName,
	                si.is_unique as IsUnique,
	                CAST(CASE WHEN si.type = 1 THEN 1 ELSE 0 END AS Bit) AS IsClustered,
	                ic.is_included_column as IsIncluded
                FROM sys.index_columns ic
                INNER JOIN sys.indexes si ON ic.object_id = si.object_id AND ic.index_id = si.index_id
                INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
                WHERE OBJECTPROPERTY(si.object_id, 'IsUserTable') = 1 AND OBJECT_NAME(si.object_id) NOT LIKE 'sysdiagrams'
                ORDER BY SchemaName, TableName, si.index_id, ic.column_id");
        }

        protected override DbConnection CreateConection()
        {
            return new SqlConnection(configurationRoot.GetConnectionString(ConnectionName));
        }

        protected override DbCommand CreateCommand(DbConnection cnn, string commandText)
        {
            return new SqlCommand(commandText, (SqlConnection)cnn);
        }

        protected override IReadOnlyDictionary<string, Type> GetClrTypeMappings()
        {
            return new ReadOnlyDictionary<string, Type>
            (
                new Dictionary<string, Type>
                {
                    { "bigint", typeof(long) },
                    { "binary", typeof(byte[]) },
                    { "bit", typeof(bool) },
                    { "char", typeof(char) },
                    { "date", typeof(DateTime) },
                    { "datetime", typeof(DateTime) },
                    { "datetime2", typeof(DateTime) },
                    { "datetimeoffset", typeof(DateTimeOffset) },
                    { "decimal", typeof(decimal) },
                    { "float", typeof(double) },
                    { "image", typeof(byte[]) },
                    { "int", typeof(int) },
                    { "money", typeof(decimal) },
                    { "nchar", typeof(char) },
                    { "ntext", typeof(string) },
                    { "numeric", typeof(decimal) },
                    { "nvarchar", typeof(string) },
                    { "real", typeof(float) },
                    { "smalldatetime", typeof(DateTime) },
                    { "smallint", typeof(short) },
                    { "smallmoney", typeof(decimal) },
                    { "sql_variant", typeof(byte[]) },
                    { "sysname", typeof(string) },
                    { "text", typeof(string) },
                    { "time", typeof(TimeSpan) },
                    { "timestamp", typeof(byte[]) },
                    { "tinyint", typeof(byte) },
                    { "uniqueidentifier", typeof(Guid) },
                    { "varbinary", typeof(byte[]) },
                    { "varchar", typeof(string) },
                    { "xml", typeof(string) },
                }
            );
        }
    }
}