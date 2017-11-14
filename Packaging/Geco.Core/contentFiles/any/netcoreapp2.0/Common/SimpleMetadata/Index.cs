using System.Diagnostics;

namespace Geco.Common.SimpleMetadata
{
    [DebuggerDisplay("[{Name}] IsUnique:{IsUnique} IsClustered:{IsClustered} Columns:{Columns} IncludedColumns:{IncludedColumns}")]
    public class Index : MetadataItem
    {
        public Index(string name, Table table, bool isUnique, bool isClustered)
        {
            Name = name;
            Table = table;
            IsUnique = isUnique;
            IsClustered = isClustered;
            IncludedColumns = new MetadataCollection<Column>();
            Columns = new MetadataCollection<Column>();
        }

        public override string Name { get; }
        public Table Table { get; }
        public bool IsUnique { get; }
        public bool IsClustered { get; }

        public MetadataCollection<Column> Columns { get; }
        public MetadataCollection<Column> IncludedColumns { get; }
    }
}