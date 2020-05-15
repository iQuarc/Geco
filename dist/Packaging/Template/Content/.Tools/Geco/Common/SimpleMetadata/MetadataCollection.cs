using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Geco.Common.SimpleMetadata.Util;

namespace Geco.Common.SimpleMetadata
{
    [DebuggerNonUserCode]
    public class MetadataCollection<TEntity> : IReadOnlyList<TEntity>, IMetadataCollectionWriteAccessor<TEntity>
        where TEntity : IMetadataItem
    {
        private readonly OrderedInterceptableDictionary<string, TEntity> innerDictionary;

        public MetadataCollection(Action<TEntity> onAdded = null, Action<TEntity> onRemoved = null)
            : this(Enumerable.Empty<TEntity>(), onAdded, onRemoved)
        {
        }

        public MetadataCollection(IEnumerable<TEntity> source, Action<TEntity> onAdded = null,
            Action<TEntity> onRemoved = null)
        {
            innerDictionary =
                new OrderedInterceptableDictionary<string, TEntity>(StringComparer.OrdinalIgnoreCase, onAdded,
                    onRemoved);
            foreach (var entity in source)
                innerDictionary.Add(entity.Name, entity);
        }

        public TEntity this[string key] => innerDictionary[key];

        public IEnumerable<string> Keys => innerDictionary.Keys;
        public IEnumerable<TEntity> Values => innerDictionary.Values;

        IDictionary<string, TEntity> IMetadataCollectionWriteAccessor<TEntity>.GetWritable()
        {
            return innerDictionary;
        }

        public int Count => innerDictionary.Count;
        public TEntity this[int index] => innerDictionary.ElementAt(index).Value;

        public IEnumerator<TEntity> GetEnumerator()
        {
            return innerDictionary.Values.ToList().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(TEntity item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            innerDictionary.Add(item.Name, item);
        }

        public bool Contains(TEntity item)
        {
            return innerDictionary.Contains(new KeyValuePair<string, TEntity>(item.Name, item));
        }

        public bool ContainsKey(string key)
        {
            return innerDictionary.ContainsKey(key);
        }

        public bool TryGetValue(string key, out TEntity value)
        {
            return innerDictionary.TryGetValue(key, out value);
        }

        public override string ToString()
        {
            return string.Join(",", innerDictionary.Keys);
        }
    }

    [DebuggerNonUserCode]
    internal static partial class MetadataExtensions
    {
        public static IDictionary<string, TEntity> GetWritable<TEntity>(
            this IMetadataCollectionWriteAccessor<TEntity> metadataCollection)
            where TEntity : IMetadataItem
        {
            return metadataCollection.GetWritable();
        }

        public static IMetadataItemWriter GetWritable(this IMetadataItemWriter metadataItem)
        {
            return metadataItem;
        }
    }

    internal interface IMetadataCollectionWriteAccessor<TEntity>
        where TEntity : IMetadataItem
    {
        IDictionary<string, TEntity> GetWritable();
    }

    internal interface IMetadataItemWriteAccessor
    {
        IMetadataItemWriter GetWritable();
    }

    public interface IMetadataItemWriter
    {
        void Remove();
    }
}