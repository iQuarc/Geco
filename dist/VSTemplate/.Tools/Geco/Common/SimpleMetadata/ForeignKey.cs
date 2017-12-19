using System.Collections.Generic;

namespace Geco.Common.SimpleMetadata
{
    public class ForeignKey : MetadataItem
    {
        public ForeignKey(string name, Table parentTable, Table targetTable, IReadOnlyList<Column> fromColumns, IReadOnlyList<Column> toColumns, ForeignKeyAction updateAction, ForeignKeyAction deleteAction)
        {
            Name = name;
            ParentTable = parentTable;
            TargetTable = targetTable;
            FromColumns = fromColumns;
            ToColumns = toColumns;
            UpdateAction = updateAction;
            DeleteAction = deleteAction;
        }

        public override string Name { get; }
        public Table ParentTable { get; }
        public Table TargetTable { get; }
        public IReadOnlyList<Column> FromColumns { get; }
        public IReadOnlyList<Column> ToColumns { get; }

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