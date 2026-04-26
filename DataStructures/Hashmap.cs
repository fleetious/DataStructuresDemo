using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Hashmap<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private LinkedList<KeyValuePair<TKey, TValue>>[] buckets;
        private List<TValue> values = new List<TValue>();
        private List<TKey> keys = new List<TKey>();
        private int count = 0;
        private bool isReadOnly = false;

        private readonly IEqualityComparer<TKey> keyComparer;
        private int size;

        public ICollection<TKey> Keys => keys;

        public ICollection<TValue> Values => values;

        public int Count => count;

        public bool IsReadOnly => isReadOnly;

        public TValue this[TKey key] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public Hashmap(int size = 256, IEqualityComparer<TKey> comparer = null)
        {
            this.size = size;
            this.buckets = new LinkedList<KeyValuePair<TKey, TValue>>[size];
            keyComparer = comparer ?? EqualityComparer<TKey>.Default;
        }

        public void Add(TKey key, TValue value)
        {
            int hash = keyComparer.GetHashCode(key);

            if (buckets[hash % size] == null)
            {
                buckets[hash % size] = new LinkedList<KeyValuePair<TKey, TValue>>();
                buckets[hash % size].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            }
        }

        public bool ContainsKey(TKey key)
        {
            int hash = keyComparer.GetHashCode(key);

            if (buckets[hash % size] is null or default(LinkedList<KeyValuePair<TKey, TValue>>)) return false;

            if (buckets[hash % size].Any(pair => keyComparer.Equals(pair.Key, key)))
            {
                return true;
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            if(!ContainsKey(key)) return false;

            int hash = keyComparer.GetHashCode(key);

            buckets[hash % size].DistinctBy(elementToRemove => buckets[hash % size].Remove(elementToRemove));
            return true;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            if (!ContainsKey(key))
            {
                value = default;
                return false;
            }

            int hash = keyComparer.GetHashCode(key);
            
            value = buckets[hash % size].First(pair => keyComparer.Equals(pair.Key, key)).Value;
            return true;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key, item.Value);
        }

        public void Clear()
        {
            count = 0;
            keys.Clear();
            values.Clear();
            buckets = new LinkedList<KeyValuePair<TKey, TValue>>[size];
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            int hash = keyComparer.GetHashCode(item.Key);

            if (buckets[hash % size] == null) return false;

            if (buckets[hash % size].Any(pair => pair.Equals(item)))
            {
                return true;
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            if(!ContainsKey(item.Key)) return false;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
