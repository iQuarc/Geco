using System.Diagnostics;

namespace Geco.Common.SimpleMetadata
{
    [DebuggerDisplay("[{Name}] {DataType}({MaxLength}) Nullable:{IsNullable} Key:{IsKey}")]
    public class Column: MetadataItem
    {
        public Column(string name, Table table, string dataType, int precision, int scale, int maxLength, bool isNullable, bool isKey, bool isIdentity, bool isRowguidCol, bool isComputed, string defaultValue)
        {
            Name = name;
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
        }

        public override string Name { get; }
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

        public string DefaultValue { get;}
    }
}