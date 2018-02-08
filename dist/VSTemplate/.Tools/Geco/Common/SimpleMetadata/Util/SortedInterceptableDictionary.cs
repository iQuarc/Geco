using System;
using System.Collections;
using System.Collections.Generic;

namespace Geco.Common.SimpleMetadata.Util
{
    internal class SortedInterceptableDictionary<TKey, TEntity> : IDictionary<TKey, TEntity>
    {
        private readonly List<TEntity> entities = new List<TEntity>();

        private readonly IDictionary<TKey, int> innerDictionary;
        private readonly Action<TEntity> onAdd;
        private readonly Action<TEntity> onRemove;

        public SortedInterceptableDictionary(IEqualityComparer<TKey> equalityComparer, Action<TEntity> onAdd, Action<TEntity> onRemove)
        {
            this.onAdd = onAdd;
            innerDictionary = new Dictionary<TKey, int>(equalityComparer ?? EqualityComparer<TKey>.Default);
            this.onRemove = onRemove;
        }

        public int Count => innerDictionary.Count;

        public TEntity this[TKey key]
        {
            get => GetEntity(key);
            set
            {
                if (innerDictionary.TryGetValue(key, out var idx))
                {
                    onRemove?.Invoke(entities[idx]);
                    entities.RemoveAt(idx);
                }
                onAdd?.Invoke(value);
                entities.Add(value);
                innerDictionary[key] = entities.Count - 1;
            }
        }

        public ICollection<TKey> Keys => innerDictionary.Keys;

        public ICollection<TEntity> Values => entities;
        bool ICollection<KeyValuePair<TKey, TEntity>>.IsReadOnly => innerDictionary.IsReadOnly;

        public void Clear()
        {
            if (onRemove != null)
                foreach (var item in entities)
                    onRemove(item);
            innerDictionary.Clear();
            entities.Clear();
        }

        public void Add(TKey key, TEntity value)
        {
            onAdd?.Invoke(value);
            entities.Add(value);
            innerDictionary.Add(key, entities.Count - 1);
        }

        public bool ContainsKey(TKey key)
        {
            return innerDictionary.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            if (innerDictionary.TryGetValue(key, out var idx))
            {
                onRemove?.Invoke(entities[idx]);
                entities.RemoveAt(idx);
                innerDictionary.Remove(key);
                return true;
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TEntity value)
        {
            if (innerDictionary.TryGetValue(key, out var idx))
            {
                value = entities[idx];
                return true;
            }
            value = default;
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TEntity>> GetEnumerator()
        {
            foreach (var innerDictionaryKey in innerDictionary.Keys)
                yield return new KeyValuePair<TKey, TEntity>(innerDictionaryKey, GetEntity(innerDictionaryKey));
        }

        private TEntity GetEntity(TKey key)
        {
            return entities[innerDictionary[key]];
        }

        void ICollection<KeyValuePair<TKey, TEntity>>.Add(KeyValuePair<TKey, TEntity> item)
        {
            onAdd?.Invoke(item.Value);
            entities.Add(item.Value);
            innerDictionary.Add(item.Key, entities.Count - 1);
        }

        bool ICollection<KeyValuePair<TKey, TEntity>>.Contains(KeyValuePair<TKey, TEntity> item)
        {
            return innerDictionary.ContainsKey(item.Key) && entities[innerDictionary[item.Key]].Equals(item.Value);
        }

        void ICollection<KeyValuePair<TKey, TEntity>>.CopyTo(KeyValuePair<TKey, TEntity>[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        bool ICollection<KeyValuePair<TKey, TEntity>>.Remove(KeyValuePair<TKey, TEntity> item)
        {
            onRemove?.Invoke(item.Value);
            if (innerDictionary.TryGetValue(item.Key, out var idx))
            {
                onRemove?.Invoke(GetEntity(item.Key));
                entities.RemoveAt(idx);
                innerDictionary.Remove(item.Key);
                return true;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}