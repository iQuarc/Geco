using System.Diagnostics;

namespace Geco.Common.SimpleMetadata;

[DebuggerDisplay("[{Name}] {DataType}({MaxLength}) Nullable:{IsNullable} Key:{IsKey}")]
public class Column : MetadataItem
{
   public Column(string name, Table table, int ordinal, string dataType, int precision, int scale, int maxLength,
      bool isNullable, bool isKey, bool isIdentity, bool isRowGuidCol, bool isComputed, string defaultValue,
      string? columnDefinition)
   {
      Name               = name;
      FullyQualifiedName = $"{table.FullyQualifiedName}.[{name}]";
      Ordinal            = ordinal;
      DataType           = dataType;
      Precision          = precision;
      Scale              = scale;
      IsNullable         = isNullable;
      IsKey              = isKey;
      IsIdentity         = isIdentity;
      IsRowGuidCol       = isRowGuidCol;
      IsComputed         = isComputed;
      MaxLength          = maxLength;
      Table              = table;
      DefaultValue       = defaultValue;
      ComputedDefinition = columnDefinition;

      Indexes             = new MetadataCollection<DataBaseIndex>();
      IndexIncludes       = new MetadataCollection<DataBaseIndex>();
      IncomingForeignKeys = new MetadataCollection<ForeignKey>();

      Db.AddToIndex(this);
   }

   public override string Name               { get; }
   public override string FullyQualifiedName { get; }

   public int     Ordinal            { get; }
   public string  DataType           { get; }
   public int     Precision          { get; }
   public int     Scale              { get; }
   public int     MaxLength          { get; }
   public bool    IsNullable         { get; }
   public bool    IsKey              { get; }
   public bool    IsIdentity         { get; }
   public bool    IsRowGuidCol       { get; }
   public bool    IsComputed         { get; }
   public string? ComputedDefinition { get; }

   public Table                             Table               { get; }
   public ForeignKey?                       ForeignKey          { get; set; }
   public MetadataCollection<ForeignKey>    IncomingForeignKeys { get; set; }
   public MetadataCollection<DataBaseIndex> Indexes             { get; set; }
   public MetadataCollection<DataBaseIndex> IndexIncludes       { get; set; }

   public string DefaultValue { get; }

   protected internal override IDatabaseMetadata Db => Table.Db;

   protected override void OnRemove()
   {
      Table.Columns.GetWritable().Remove(Name);
      ForeignKey?.GetWritable().Remove();
      Indexes.GetWritable().Remove(Name);
      IndexIncludes.GetWritable().Remove(Name);

      foreach (var foreignKey in IncomingForeignKeys)
         foreignKey.GetWritable().Remove();

      Db.RemoveFromIndex(this);
   }
}