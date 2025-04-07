namespace Geco.Common.SimpleMetadata;

public class ForeignKey : MetadataItem
{
   public ForeignKey(string name, Table parentTable, Table targetTable, ForeignKeyAction updateAction,
      ForeignKeyAction      deleteAction)
   {
      Name               = name;
      FullyQualifiedName = $"{parentTable.FullyQualifiedName}.[{name}]";
      ParentTable        = parentTable;
      TargetTable        = targetTable;
      FromColumns        = new MetadataCollection<Column>(OnFromColumnAdd);
      ToColumns          = new MetadataCollection<Column>(OnToColumnsAdd);
      UpdateAction       = updateAction;
      DeleteAction       = deleteAction;

      Db.AddToIndex(this);
   }

   public override string Name               { get; }
   public override string FullyQualifiedName { get; }

   public Table                      ParentTable { get; }
   public Table                      TargetTable { get; }
   public MetadataCollection<Column> FromColumns { get; }
   public MetadataCollection<Column> ToColumns   { get; }

   public ForeignKeyAction UpdateAction { get; }
   public ForeignKeyAction DeleteAction { get; }

   protected internal override IDatabaseMetadata Db => ParentTable.Db;

   protected override void OnRemove()
   {
      ParentTable.ForeignKeys.GetWritable().Remove(Name);
      foreach (var fromColumn in FromColumns)
         fromColumn.ForeignKey = this;
      TargetTable.ForeignKeys.GetWritable().Remove(Name);
      Db.RemoveFromIndex(this);
   }

   private void OnFromColumnAdd(Column column)
   {
      column.ForeignKey = this;
   }

   private void OnToColumnsAdd(Column column)
   {
      column.IncomingForeignKeys.Add(this);
   }
}

public enum ForeignKeyAction : byte
{
   NoAction   = 0,
   Cascade    = 1,
   SetNull    = 2,
   SetDefault = 3
}