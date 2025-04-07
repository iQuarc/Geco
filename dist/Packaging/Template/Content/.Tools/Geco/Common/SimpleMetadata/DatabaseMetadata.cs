namespace Geco.Common.SimpleMetadata;

public class DatabaseMetadata : IDatabaseMetadata
{
   private readonly Dictionary<string, IMetadataItem> items = new();

   public DatabaseMetadata(string name, IReadOnlyDictionary<string, Type> typeMappings)
   {
      Schemas      = new MetadataCollection<Schema>(null, OnRemoveSchema);
      TypeMappings = typeMappings;
      Name         = name;
   }

   public IReadOnlyDictionary<string, Type> TypeMappings { get; }

   public string                                     Name       { get; }
   public MetadataCollection<Schema>                 Schemas    { get; }
   public IReadOnlyDictionary<string, IMetadataItem> ItemsIndex => items;

   public TMetadataItem Find<TMetadataItem>(string fullyQualifiedTableName)
      where TMetadataItem : class, IMetadataItem
   {
      items.TryGetValue(fullyQualifiedTableName, out var item);
      return item as TMetadataItem;
   }

   public void AddToIndex(IMetadataItem item)
   {
      items.TryAdd(item.FullyQualifiedName, item);
   }

   public void RemoveFromIndex(IMetadataItem item)
   {
      items.Remove(item.FullyQualifiedName);
   }

   private void OnRemoveSchema(Schema schema)
   {
      schema.GetWritable().Remove();
      RemoveFromIndex(schema);
   }
}

public interface IDatabaseMetadata
{
   string                                     Name       { get; }
   MetadataCollection<Schema>                 Schemas    { get; }
   IReadOnlyDictionary<string, IMetadataItem> ItemsIndex { get; }
   void                                       AddToIndex(IMetadataItem      item);
   void                                       RemoveFromIndex(IMetadataItem item);

   TMetadataItem Find<TMetadataItem>(string fullyQualifiedTableName)
      where TMetadataItem : class, IMetadataItem;
}