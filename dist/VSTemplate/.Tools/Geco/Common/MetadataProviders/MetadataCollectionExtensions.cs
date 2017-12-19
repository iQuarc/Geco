using System;
using Geco.Common.SimpleMetadata;

namespace Geco.Common.MetadataProviders
{
    public static class MetadataCollectionExtensions
    {
        public static T GetOrAdd<T>(this MetadataCollection<T> collection, string key, Func<T> factory)
            where T : class, IMetadataItem
        {
            if (!collection.ContainsKey(key))
            {
                var item = factory();
                var writable = collection.GetWritable();
                writable[key] = item;
                return item;
            }
            return collection[key];
        }
    }
}