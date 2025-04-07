namespace Geco.Common.SimpleMetadata;

public class Trigger : MetadataItem
{
   public Trigger(string name, Table table)
   {
      Table              = table;
      Name               = name;
      FullyQualifiedName = $"{table.FullyQualifiedName}.[{name}]";

      Db.AddToIndex(this);
   }

   public          Table  Table              { get; }
   public override string Name               { get; }
   public override string FullyQualifiedName { get; }

   protected internal override IDatabaseMetadata Db => Table.Db;

   protected override void OnRemove()
   {
      Table.Triggers.GetWritable().Remove(Name);
      Db.RemoveFromIndex(this);
   }
}