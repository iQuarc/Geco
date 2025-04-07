using System.Diagnostics;

namespace Geco.Common.SimpleMetadata;

[DebuggerDisplay("[{Name}]")]
public class Schema : MetadataItem
{
   public Schema(string name, IDatabaseMetadata db)
   {
      Name               = name;
      Db                 = db;
      FullyQualifiedName = $"[{name}]";
      Tables             = new MetadataCollection<Table>(OnAdd, OnRemove);
      db.AddToIndex(this);
   }

   public override             string            Name               { get; }
   public override             string            FullyQualifiedName { get; }
   protected internal override IDatabaseMetadata Db                 { get; }

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

   protected override void OnRemove()
   {
      Db.RemoveFromIndex(this);
   }
}