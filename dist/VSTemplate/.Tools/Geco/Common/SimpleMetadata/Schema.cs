using System.Diagnostics;
using System.Linq;

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

        private void OnAdd(Table table)
        {
            
        }

        private void OnRemove(Table table)
        {
            // Remove all FK references a table when it is removed from the model
            foreach (var col in Tables.SelectMany(t => t.Columns).Where(c => c.ForeignKey?.TargetTable == table))
                col.ForeignKey.TargetTable.IncomingForeignKeys.GetWritable().Remove(col.ForeignKey.Name);
            foreach (var fk in Tables.SelectMany(t => t.ForeignKeys).Where(fk => fk.TargetTable == table))
                fk.ParentTable.ForeignKeys.GetWritable().Remove(fk.Name);
            foreach (var fk in Tables.SelectMany(t => t.IncomingForeignKeys).Where(fk => fk.ParentTable == table))
                fk.TargetTable.IncomingForeignKeys.GetWritable().Remove(fk.Name);
        }

        public override string Name { get; }
        public MetadataCollection<Table> Tables { get; }
    }
}