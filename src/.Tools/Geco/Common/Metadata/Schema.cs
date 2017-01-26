using System.Diagnostics;

namespace Geco.Common.Metadata
{
    [DebuggerDisplay("[{Name}]")]
    public class Schema : MetadataItem
    {
        private readonly DatabaseMetadata dbMetadata;
        public Schema(string name, DatabaseMetadata dbMetadata)
        {
            this.dbMetadata = dbMetadata;
            Name = name;
            Tables = new MetadataCollection<Table>(this);
        }

        public override string Name { get; }
        public override bool IsFrozen => dbMetadata.IsFrozen;
        public MetadataCollection<Table> Tables { get; }
    }
}