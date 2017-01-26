namespace Geco.Common.Metadata
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

        public override bool IsFrozen => Table.IsFrozen;
    }
}