using System;
using System.Collections;
using System.Collections.Generic;

namespace Geco.Common.Metadata
{
    public class MetadataCollection<TEntity> : IReadOnlyCollection<TEntity>, IReadOnlyDictionary<string, TEntity>, IMetadataWriteAccessor<TEntity>
        where TEntity : IMetadataItem
    {
        private readonly IFreezableOwner freezableOwner;
        private readonly Dictionary<string, TEntity> innerDictionary = new Dictionary<string, TEntity>(StringComparer.OrdinalIgnoreCase);

        public MetadataCollection(IFreezableOwner freezableOwner)
        {
            this.freezableOwner = freezableOwner;
        }

        public void Add(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            innerDictionary.Add(item.Name, item);
        }

        public void Add(string key, TEntity value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (value == null) throw new ArgumentNullException(nameof(value));
            innerDictionary.Add(key, value);
        }

        public void Clear()
        {
            innerDictionary.Clear();
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

        public bool Remove(string key)
        {
            return innerDictionary.Remove(key);
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
            return innerDictionary.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        IEnumerator<KeyValuePair<string, TEntity>> IEnumerable<KeyValuePair<string, TEntity>>.GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }

        IDictionary<string, TEntity> IMetadataWriteAccessor<TEntity>.GetWritable()
        {
            if (freezableOwner.IsFrozen)
                throw new InvalidOperationException("Cannot get writable accessor while the collection is frozen!");
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

    internal static class MetadataExtensions
    {
        public static IDictionary<string, TEntity> GetWritable<TEntity>(this IMetadataWriteAccessor<TEntity> metadataCollection) 
            where TEntity : IMetadataItem
        {
            return metadataCollection.GetWritable();
        }
    }
}