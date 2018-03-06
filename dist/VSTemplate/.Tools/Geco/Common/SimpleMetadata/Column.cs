using System.Diagnostics;

namespace Geco.Common.SimpleMetadata
{
    [DebuggerDisplay("[{Name}] {DataType}({MaxLength}) Nullable:{IsNullable} Key:{IsKey}")]
    public class Column: MetadataItem
    {
        public Column(string name, Table table, int ordinal, string dataType, int precision, int scale, int maxLength, bool isNullable, bool isKey, bool isIdentity, bool isRowguidCol, bool isComputed, string defaultValue)
        {
            Name = name;
            Ordinal = ordinal;
            DataType = dataType;
            Precision = precision;
            Scale = scale;
            IsNullable = isNullable;
            IsKey = isKey;
            IsIdentity = isIdentity;
            IsRowguidCol = isRowguidCol;
            IsComputed = isComputed;
            MaxLength = maxLength;
            Table = table;
            DefaultValue = defaultValue;

            Indexes = new MetadataCollection<Index>();
            IndexIncludes = new MetadataCollection<Index>();
            IncommingForeignKeys = new MetadataCollection<ForeignKey>();
        }

        public override string Name { get; }
        public int Ordinal { get; }
        public string DataType { get;}
        public int Precision { get;}
        public int Scale { get;  }
        public int MaxLength { get; }
        public bool IsNullable { get; }
        public bool IsKey { get; }
        public bool IsIdentity { get; }
        public bool IsRowguidCol { get; }
        public bool IsComputed { get; }

        public Table Table { get;  }
        public ForeignKey ForeignKey { get; set; }
        public MetadataCollection<ForeignKey> IncommingForeignKeys { get; set; }
        public MetadataCollection<Index> Indexes { get; set; }
        public MetadataCollection<Index> IndexIncludes { get; set; }

        public string DefaultValue { get;}

        protected override void OnRemove()
        {
            Table.Columns.GetWritable().Remove(this.Name);
            ForeignKey?.GetWritable().Remove();
            Indexes.GetWritable().Remove(this.Name);
            IndexIncludes.GetWritable().Remove(this.Name);
            foreach (var foreignKey in IncommingForeignKeys)
                foreignKey.GetWritable().Remove();
        }
    }
}