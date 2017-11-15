using System.Diagnostics;
using Geco.Common.MetadataProviders;

namespace Geco.Common.SimpleMetadata
{
    [DebuggerDisplay("[{Schema.Name}].[{Name}]")]
    public class Table : MetadataItem
    {
        public Table(string name, Schema schema)
        {
            Name = name;
            Schema = schema;
            Indexes = new MetadataCollection<Index>();
            Triggers = new MetadataCollection<Trigger>();
            IncomingForeignKeys = new MetadataCollection<ForeignKey>();
            ForeignKeys = new MetadataCollection<ForeignKey>();
            Columns = new MetadataCollection<Column>();
        }

        public override string Name { get; }
        public Schema Schema { get; }

        public MetadataCollection<Column> Columns { get; }
        public MetadataCollection<ForeignKey> ForeignKeys { get;}
        public MetadataCollection<ForeignKey> IncomingForeignKeys { get;}
        public MetadataCollection<Trigger> Triggers { get; }
        public MetadataCollection<Index> Indexes { get; }
    }
}