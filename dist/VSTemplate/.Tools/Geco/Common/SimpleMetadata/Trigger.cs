namespace Geco.Common.SimpleMetadata
{
    public class Trigger : MetadataItem
    {
        public Trigger(string name, Table table)
        {
            Table = table;
            Name = name;
        }

        public Table Table { get; }
        public override string Name { get; }

        protected override void OnRemove()
        {
            Table.Triggers.GetWritable().Remove(Name);
        }
    }
}