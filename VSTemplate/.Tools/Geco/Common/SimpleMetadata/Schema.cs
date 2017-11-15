using System.Diagnostics;

namespace Geco.Common.SimpleMetadata
{
    [DebuggerDisplay("[{Name}]")]
    public class Schema : MetadataItem
    {
        public Schema(string name)
        {
            Name = name;
            Tables = new MetadataCollection<Table>();
        }

        public override string Name { get; }
        public MetadataCollection<Table> Tables { get; }
    }
}