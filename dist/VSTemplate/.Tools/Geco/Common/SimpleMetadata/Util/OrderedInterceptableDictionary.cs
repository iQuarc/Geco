using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Geco.Common.SimpleMetadata.Util
{
    /// <summary>
    ///     A string dictionary which preserves the order of elements which were added and allows intercepting additions and
    ///     deletions
    /// </summary>
    /// <typeparam name="TKey">The key type</typeparam>
    /// <typeparam name="TElement">The element type</typeparam>
    [DebuggerNonUserCode]
    internal class OrderedInterceptableDictionary<TKey, TElement> : IDictionary<TKey, TElement>
    {
        private readonly SortedDictionary<int, (TKey Key, TElement Element)> elements;
        private readonly IDictionary<TKey, int> keyOrder;

        private readonly Action<TElement> onAdded;
        private readonly Action<TElement> onRemoved;
        private int curentOrder;

        public OrderedInterceptableDictionary(IEqualityComparer<TKey> comparer, Action<TElement> onAdd,
            Action<TElement> onRemoved)
        {
            onAdded = onAdd;
            keyOrder = new Dictionary<TKey, int>(comparer ?? EqualityComparer<TKey>.Default);
            elements = new SortedDictionary<int, (TKey, TElement)>();
            this.onRemoved = onRemoved;
        }

        public int Count => elements.Count;

        public TElement this[TKey key]
        {
            get => GetElement(key);
            set
            {
                if (keyOrder.ContainsKey(key)) Remove(key);
                Add(key, value);
            }
        }

        public ICollection<TKey> Keys => elements.Values.Select(v => v.Key).ToList();
        public ICollection<TElement> Values => elements.Values.Select(v => v.Element).ToList();
        bool ICollection<KeyValuePair<TKey, TElement>>.IsReadOnly => false;

        public void Clear()
        {
            var values = elements.Values.ToList();
            elements.Clear();
            keyOrder.Clear();
            if (onRemoved != null)
                foreach (var item in values)
                    onRemoved(item.Element);
        }

        public void Add(TKey key, TElement value)
        {
            keyOrder.Add(key, curentOrder);
            elements.Add(curentOrder, (key, value));
            onAdded?.Invoke(value);
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
                var element = elements[idx].Element;
                keyOrder.Remove(key);
                elements.Remove(idx);
                onRemoved?.Invoke(element);
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
                yield return new KeyValuePair<TKey, TElement>(value.Key, value.Element);
        }

        void ICollection<KeyValuePair<TKey, TElement>>.Add(KeyValuePair<TKey, TElement> item)
        {
            Add(item.Key, item.Value);
        }

        bool ICollection<KeyValuePair<TKey, TElement>>.Contains(KeyValuePair<TKey, TElement> item)
        {
            return keyOrder.ContainsKey(item.Key) && Equals(elements[keyOrder[item.Key]].Element, item.Value);
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

        private TElement GetElement(TKey key)
        {
            return elements[keyOrder[key]].Element;
        }
    }
}