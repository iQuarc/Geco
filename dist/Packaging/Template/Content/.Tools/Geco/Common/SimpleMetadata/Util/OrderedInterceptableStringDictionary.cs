using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Geco.Common.SimpleMetadata.Util
{
    /// <summary>
    /// A string dictionary which preserves the order of elements which were added and allows intercepting additions and deletions
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TElement">The element type</typeparam>
    internal class OrderedInterceptableDictionary<TKey,TElement> : IDictionary<TKey, TElement>
    {
        private readonly IDictionary<TKey, int> keyOrder;
        private readonly SortedDictionary<int, (TKey Key,TElement Element)> elements;

        private readonly Action<TElement> onAdd;
        private readonly Action<TElement> onRemove;
        private int curentOrder;

        public OrderedInterceptableDictionary(IEqualityComparer<TKey> comparer, Action<TElement> onAdd, Action<TElement> onRemove)
        {
            this.onAdd = onAdd;
            keyOrder = new Dictionary<TKey, int>(comparer ?? EqualityComparer<TKey>.Default);
            elements = new SortedDictionary<int, (TKey, TElement)>();
            this.onRemove = onRemove;
        }

        public int Count => elements.Count;

        public TElement this[TKey key]
        {
            get => GetElement(key);
            set
            {
                if (keyOrder.ContainsKey(key))
                {
                    Remove(key);
                }
                Add(key, value);
            }
        }

        public ICollection<TKey> Keys => elements.Values.Select(v => v.Key).ToList();
        public ICollection<TElement> Values => elements.Values.Select(v => v.Element).ToList();
        bool ICollection<KeyValuePair<TKey, TElement>>.IsReadOnly => false;

        public void Clear()
        {
            if (onRemove != null)
                foreach (var item in elements.Values)
                    onRemove(item.Element);
            elements.Clear();
            keyOrder.Clear();
        }

        public void Add(TKey key, TElement value)
        {
            onAdd?.Invoke(value);
            keyOrder.Add(key, curentOrder);
            elements.Add(curentOrder, (key,value));
            curentOrder++;
        }

        public bool ContainsKey(TKey key)
        {
            return keyOrder.ContainsKey(key);
        }

        public bool Remove(TKey key)
        {
            if (keyOrder.TryGetValue(key, out var idx))
            {
                onRemove?.Invoke(elements[idx].Element);
                keyOrder.Remove(key);
                elements.Remove(idx);
                return true;
            }
            return false;
        }

        public bool TryGetValue(TKey key, out TElement value)
        {
            if (keyOrder.TryGetValue(key, out var idx))
            {
                value = elements[idx].Element;
                return true;
            }
            value = default;
            return false;
        }

        public IEnumerator<KeyValuePair<TKey, TElement>> GetEnumerator()
        {
            foreach (var value in elements.Values)
            {
                yield return new KeyValuePair<TKey, TElement>(value.Key, value.Element);
            }
        }

        private TElement GetElement(TKey key)
        {
            return elements[keyOrder[key]].Element;
        }

        void ICollection<KeyValuePair<TKey, TElement>>.Add(KeyValuePair<TKey, TElement> item)
        {
            Add(item.Key, item.Value);
        }

        bool ICollection<KeyValuePair<TKey, TElement>>.Contains(KeyValuePair<TKey, TElement> item)
        {
            return keyOrder.ContainsKey(item.Key) && Object.Equals(elements[keyOrder[item.Key]].Element, item.Value);
        }

        void ICollection<KeyValuePair<TKey, TElement>>.CopyTo(KeyValuePair<TKey, TElement>[] array, int arrayIndex)
        {
            throw new NotSupportedException();
        }

        bool ICollection<KeyValuePair<TKey, TElement>>.Remove(KeyValuePair<TKey, TElement> item)
        {
            return ContainsKey(item.Key) && GetElement(item.Key).Equals(item.Value) && Remove(item.Key);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}