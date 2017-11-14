using System.Collections.Generic;

namespace Geco.Common.SimpleMetadata
{
    public class ForeignKey: MetadataItem
    {
        public ForeignKey(string name, Table parentTable, Table targetTable, IReadOnlyList<Column> fromColumns, IReadOnlyList<Column> toColumns)
        {
            Name = name;
            ParentTable = parentTable;
            TargetTable = targetTable;
            FromColumns = fromColumns;
            ToColumns = toColumns;
        }

        public override string Name { get; }
        public Table ParentTable { get;}
        public Table TargetTable { get;}
        public IReadOnlyList<Column> FromColumns { get; }
        public IReadOnlyList<Column> ToColumns { get;}
    }
}