using System.Diagnostics;

namespace Geco.Common.SimpleMetadata
{
    [DebuggerDisplay("[{Name}]")]
    public class Schema : MetadataItem
    {
        public Schema(string name)
        {
            Name = name;
            Tables = new MetadataCollection<Table>(OnAdd, OnRemove);
        }

        public override string Name { get; }
        public MetadataCollection<Table> Tables { get; }

        private void OnAdd(Table table)
        {
        }

        private void OnRemove(Table table)
        {
            // Remove all FK references a table when it is removed from the model
            foreach (var fk in table.ForeignKeys)
            {
                fk.TargetTable.IncomingForeignKeys.GetWritable().Remove(fk.Name);
                foreach (var fkToColumn in fk.ToColumns)
                    fkToColumn.ForeignKey = null;
            }

            foreach (var fk in table.IncomingForeignKeys)
            {
                fk.ParentTable.ForeignKeys.GetWritable().Remove(fk.Name);
                foreach (var fkToColumn in fk.FromColumns)
                    fkToColumn.ForeignKey = null;
            }
        }
    }
}