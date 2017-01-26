using System.Diagnostics;

namespace Geco.Common.Metadata
{
    [DebuggerDisplay("[{Schema.Name}].[{Name}]")]
    public class Table : MetadataItem
    {
        public Table(string name, Schema schema)
        {
            Name = name;
            Schema = schema;
            Indexes = new MetadataCollection<Index>(this);
            Triggers = new MetadataCollection<Trigger>(this);
            IncomingForeignKeys = new MetadataCollection<ForeignKey>(this);
            ForeignKeys = new MetadataCollection<ForeignKey>(this);
            Columns = new MetadataCollection<Column>(this);
        }

        public override string Name { get; }
        public Schema Schema { get; }

        public MetadataCollection<Column> Columns { get; }
        public MetadataCollection<ForeignKey> ForeignKeys { get;}
        public MetadataCollection<ForeignKey> IncomingForeignKeys { get;}
        public MetadataCollection<Trigger> Triggers { get; }
        public MetadataCollection<Index> Indexes { get; }

        public override bool IsFrozen => Schema.IsFrozen;
    }
}