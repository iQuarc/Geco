using System.Diagnostics;

namespace Geco.Common.Metadata
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
            IncludedColumns = new MetadataCollection<Column>(this);
            Columns = new MetadataCollection<Column>(this);
        }

        public override string Name { get; }
        public Table Table { get; }
        public override bool IsFrozen => Table.IsFrozen;
        public bool IsUnique { get; }
        public bool IsClustered { get; }

        public MetadataCollection<Column> Columns { get; }
        public MetadataCollection<Column> IncludedColumns { get; }
    }
}