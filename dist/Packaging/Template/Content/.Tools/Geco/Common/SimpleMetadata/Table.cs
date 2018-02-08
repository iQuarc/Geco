using System.Diagnostics;
using System.Linq;
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
            Columns = new MetadataCollection<Column>(null, OnRemove);
        }

        public override string Name { get; }
        public Schema Schema { get; }

        public MetadataCollection<Column> Columns { get; }
        public MetadataCollection<ForeignKey> ForeignKeys { get;}
        public MetadataCollection<ForeignKey> IncomingForeignKeys { get;}
        public MetadataCollection<Trigger> Triggers { get; }
        public MetadataCollection<Index> Indexes { get; }


        private void OnRemove(Column column)
        {
            foreach (var incomingForeignKey in IncomingForeignKeys)
            {
                if (incomingForeignKey.ToColumns.Contains(column))
                    incomingForeignKey.ToColumns.GetWritable().Remove(incomingForeignKey.Name);
            }
        }
    }
}