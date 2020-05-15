using System;
using System.Collections;
using System.Collections.Generic;

namespace Geco.Common.SimpleMetadata
{
    public class MetadataDictionary : IDictionary<string, string>
    {
        private readonly IDictionary<string, string> innerDictionary =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return innerDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable) innerDictionary).GetEnumerator();
        }

        public void Add(KeyValuePair<string, string> item)
        {
            innerDictionary.Add(item);
        }

        public void Clear()
        {
            innerDictionary.Clear();
        }

        public bool Contains(KeyValuePair<string, string> item)
        {
            return innerDictionary.Contains(item);
        }

        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            innerDictionary.CopyTo(array, arrayIndex);
        }

        public bool Remove(KeyValuePair<string, string> item)
        {
            return innerDictionary.Remove(item);
        }

        public int Count => innerDictionary.Count;

        public bool IsReadOnly => innerDictionary.IsReadOnly;

        public void Add(string key, string value)
        {
            innerDictionary.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return innerDictionary.ContainsKey(key);
        }

        public bool Remove(string key)
        {
            return innerDictionary.Remove(key);
        }

        public bool TryGetValue(string key, out string value)
        {
            return innerDictionary.TryGetValue(key, out value);
        }

        public string this[string key]
        {
            get
            {
                innerDictionary.TryGetValue(key, out var value);
                return value;
            }
            set => innerDictionary[key] = value;
        }

        public ICollection<string> Keys => innerDictionary.Keys;
        public ICollection<string> Values => innerDictionary.Values;
    }
}