namespace Geco.Common.Metadata
{
    public class ForeignKey: MetadataItem
    {
        public ForeignKey(string name, Table parentTable, Table targetTable, Column fromColumn, Column toColumn)
        {
            Name = name;
            ParentTable = parentTable;
            TargetTable = targetTable;
            FromColumn = fromColumn;
            ToColumn = toColumn;
        }

        public override string Name { get; }
        public override bool IsFrozen => ParentTable.IsFrozen;
        public Table ParentTable { get;}
        public Table TargetTable { get;}
        public Column FromColumn { get; }
        public Column ToColumn { get;}
    }
}