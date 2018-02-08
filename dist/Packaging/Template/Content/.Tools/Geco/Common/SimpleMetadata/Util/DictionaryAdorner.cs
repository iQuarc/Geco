using System;
using System.Collections;
using System.Collections.Generic;

namespace Geco.Common.SimpleMetadata.Util
{
    internal class DictionaryWrapper<TKey, TEntity> : IDictionary<TKey, TEntity>
    {
        private readonly IDictionary<TKey, TEntity> innerDictionary;
        private readonly Action<TEntity> onAdd;
        private readonly Action<TEntity> onRemove;

        public DictionaryWrapper(IDictionary<TKey, TEntity> innerDictionary, Action<TEntity> onAdd, Action<TEntity> onRemove)
        {
            this.innerDictionary = innerDictionary;
            this.onAdd = onAdd;
            this.onRemove = onRemove;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            if (onRemove != null)
                foreach (var item in innerDictionary)
                    onRemove(item.Value);
            innerDictionary.Clear();
        }

        public bool Contains(KeyValuePair<TKey, TEntity> item)
        {
            return innerDictionary.Contains(item);
        }

        void ICollection<KeyValuePair<TKey, TEntity>>.CopyTo(KeyValuePair<TKey, TEntity>[] array, int arrayIndex)
        {
            innerDictionary.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<TKey, TEntity> item)
        {
            onRemove?.Invoke(item.Value);
            return innerDictionary.Remove(item);
        }

        public int Count => innerDictionary.Count;
        bool ICollection<KeyValuePair<TKey, TEntity>>.IsReadOnly => innerDictionary.IsReadOnly;

        public void Add(TKey key, TEntity value)
        {
            onAdd?.Invoke(value);
            innerDictionary.Add(key, value);
        }

        public bool ContainsKey(TKey key)
        {
            return innerDictionary.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            if (innerDictionary.TryGetValue(key, out var value))
                onRemove?.Invoke(value);
            return innerDictionary.Remove(key);
        }

        public bool TryGetValue(TKey key, out TEntity value)
        {
            return innerDictionary.TryGetValue(key, out value);
        }

        public TEntity this[TKey key]
        {
            get => innerDictionary[key];
            set
            {
                if (innerDictionary.TryGetValue(key, out var existing))
                    onRemove?.Invoke(existing);
                onAdd?.Invoke(value);
                innerDictionary[key] = value;
            }
        }

        public ICollection<TKey> Keys => innerDictionary.Keys;
        public ICollection<TEntity> Values => innerDictionary.Values;

        void ICollection<KeyValuePair<TKey, TEntity>>.Add(KeyValuePair<TKey, TEntity> item)
        {
            onAdd?.Invoke(item.Value);
            innerDictionary.Add(item);
        }

        public IEnumerator<KeyValuePair<TKey, TEntity>> GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }
    }
}