using System.Collections.Generic;

namespace Geco.Common.SimpleMetadata
{
    public class ForeignKey : MetadataItem
    {
        public ForeignKey(string name, Table parentTable, Table targetTable, ForeignKeyAction updateAction, ForeignKeyAction deleteAction)
        {
            Name = name;
            ParentTable = parentTable;
            TargetTable = targetTable;
            FromColumns = new MetadataCollection<Column>();
            ToColumns = new MetadataCollection<Column>();
            UpdateAction = updateAction;
            DeleteAction = deleteAction;
        }

        public override string Name { get; }
        public Table ParentTable { get; }
        public Table TargetTable { get; }
        public MetadataCollection<Column> FromColumns { get; }
        public MetadataCollection<Column> ToColumns { get; }

        public ForeignKeyAction UpdateAction { get;}
        public ForeignKeyAction DeleteAction { get;}
    }

    public enum ForeignKeyAction : byte
    {
        NoAction   = 0,
        Cascade    = 1,
        SetNull    = 2,
        SetDefault = 3
    }
}