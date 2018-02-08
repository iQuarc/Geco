using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Geco.Common.SimpleMetadata.Util
{
    /// <summary>
    /// Dictionary which preserves the order of elements which were added and allows intercepting additions and deletions
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TElement">The element type</typeparam>
    [DebuggerNonUserCode]
    internal class OrderedInterceptableDictionary<TKey, TElement> : IDictionary<TKey, TElement>
    {
        private readonly List<TElement> elements = new List<TElement>();
        private readonly IDictionary<TKey, int> keyIndex;

        private readonly Action<TElement> onAdd;
        private readonly Action<TElement> onRemove;

        public OrderedInterceptableDictionary(IEqualityComparer<TKey> equalityComparer, Action<TElement> onAdd, Action<TElement> onRemove)
        {
            this.onAdd = onAdd;
            keyIndex = new Dictionary<TKey, int>(equalityComparer ?? EqualityComparer<TKey>.Default);
            this.onRemove = onRemove;
        }

        public int Count => keyIndex.Count;

        public TElement this[TKey key]
        {
            get => GetElement(key);
            set
            {
                if (keyIndex.TryGetValue(key, out var idx))
                {
                    onRemove?.Invoke(elements[idx]);
                    elements.RemoveAt(idx);
                }
                onAdd?.Invoke(value);
                elements.Add(value);
                keyIndex[key] = elements.Count - 1;
            }
        }

        public ICollection<TKey> Keys => keyIndex.Keys;

        public ICollection<TElement> Values => elements;
        bool ICollection<KeyValuePair<TKey, TElement>>.IsReadOnly => keyIndex.IsReadOnly;

        public void Clear()
        {
            if (onRemove != null)
                foreach (var item in elements)
                    onRemove(item);
            keyIndex.Clear();
            elements.Clear();
        }

        public void Add(TKey key, TElement value)
        {
            onAdd?.Invoke(value);
            elements.Add(value);
            keyIndex.Add(key, elements.Count - 1);
        }

        public bool ContainsKey(TKey key)
        {
            return keyIndex.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            if (keyIndex.TryGetValue(key, out var idx))
            {
                onRemove?.Invoke(elements[idx]);
                elements.RemoveAt(idx);
                keyIndex.Remove(key);
                return true;
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TElement value)
        {
            if (keyIndex.TryGetValue(key, out var idx))
            {
                value = elements[idx];
                return true;
            }
            value = default;
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TElement>> GetEnumerator()
        {
            foreach (var innerDictionaryKey in keyIndex.Keys.OrderBy( k => keyIndex[k]) )
                yield return new KeyValuePair<TKey, TElement>(innerDictionaryKey, GetElement(innerDictionaryKey));
        }

        private TElement GetElement(TKey key)
        {
            return elements[keyIndex[key]];
        }

        void ICollection<KeyValuePair<TKey, TElement>>.Add(KeyValuePair<TKey, TElement> item)
        {
            onAdd?.Invoke(item.Value);
            elements.Add(item.Value);
            keyIndex.Add(item.Key, elements.Count - 1);
        }

        bool ICollection<KeyValuePair<TKey, TElement>>.Contains(KeyValuePair<TKey, TElement> item)
        {
            return keyIndex.ContainsKey(item.Key) && elements[keyIndex[item.Key]].Equals(item.Value);
        }

        void ICollection<KeyValuePair<TKey, TElement>>.CopyTo(KeyValuePair<TKey, TElement>[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        bool ICollection<KeyValuePair<TKey, TElement>>.Remove(KeyValuePair<TKey, TElement> item)
        {
            onRemove?.Invoke(item.Value);
            if (keyIndex.TryGetValue(item.Key, out var idx))
            {
                onRemove?.Invoke(GetElement(item.Key));
                elements.RemoveAt(idx);
                keyIndex.Remove(item.Key);
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