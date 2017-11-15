using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Geco.Common.SimpleMetadata
{
    public class MetadataCollection<TEntity> : IReadOnlyCollection<TEntity>, IMetadataWriteAccessor<TEntity>
        where TEntity : IMetadataItem
    {
        private readonly Dictionary<string, TEntity> innerDictionary = new Dictionary<string, TEntity>(StringComparer.OrdinalIgnoreCase);

        public void Add(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            innerDictionary.Add(item.Name, item);
        }

        public bool Contains(TEntity item)
        {
            return innerDictionary.ContainsValue(item);
        }

        public int Count => innerDictionary.Count;

        public bool ContainsKey(string key)
        {
            return innerDictionary.ContainsKey(key);
        }

        public bool TryGetValue(string key, out TEntity value)
        {
            return innerDictionary.TryGetValue(key, out value);
        }

        public TEntity this[string key] => innerDictionary[key];

        public IEnumerable<string> Keys => innerDictionary.Keys;
        public IEnumerable<TEntity> Values => innerDictionary.Values;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return innerDictionary.Values.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IDictionary<string, TEntity> IMetadataWriteAccessor<TEntity>.GetWritable()
        {
            return this.innerDictionary;
        }

        public override string ToString()
        {
            return String.Join(",", innerDictionary.Keys);
        }
    }

    internal interface IMetadataWriteAccessor<TEntity>
        where TEntity : IMetadataItem
    {
        IDictionary<string, TEntity> GetWritable();
    }

    internal static partial class MetadataExtensions
    {
        public static IDictionary<string, TEntity> GetWritable<TEntity>(this IMetadataWriteAccessor<TEntity> metadataCollection) 
            where TEntity : IMetadataItem
        {
            return metadataCollection.GetWritable();
        }
    }
}