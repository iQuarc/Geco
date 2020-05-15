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
            Indexes = new MetadataCollection<DataBaseIndex>(null, OnIndexRemove);
            Triggers = new MetadataCollection<Trigger>(null, OnRemoveIndex);
            IncomingForeignKeys = new MetadataCollection<ForeignKey>(null, OnRemoveForeignKey);
            ForeignKeys = new MetadataCollection<ForeignKey>(null, OnRemoveForeignKey);
            Columns = new MetadataCollection<Column>(null, OnRemoveColumn);
        }

        public override string Name { get; }
        public Schema Schema { get; }

        public MetadataCollection<Column> Columns { get; }
        public MetadataCollection<ForeignKey> ForeignKeys { get; }
        public MetadataCollection<ForeignKey> IncomingForeignKeys { get; }
        public MetadataCollection<Trigger> Triggers { get; }
        public MetadataCollection<DataBaseIndex> Indexes { get; }

        protected override void OnRemove()
        {
            Schema.Tables.GetWritable().Remove(this.Name);
            foreach (var foreignKey in ForeignKeys)
                foreignKey.GetWritable().Remove();
            foreach (var incomingForeignKey in IncomingForeignKeys)
                incomingForeignKey.GetWritable().Remove();
        }

        private void OnRemoveIndex(Trigger trigger)
        {
            trigger.GetWritable().Remove();
        }

        private void OnRemoveColumn(Column column)
        {
            column.GetWritable().Remove();
        }

        private void OnRemoveForeignKey(ForeignKey foreignKey)
        {
            foreignKey.GetWritable().Remove();
        }

        private void OnIndexRemove(DataBaseIndex index)
        {
            index.GetWritable().Remove();
        }
    }
}