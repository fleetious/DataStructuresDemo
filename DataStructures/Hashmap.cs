using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class HashMap<TKey, TValue> : IDictionary<TKey, TValue>
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

        public TValue this[TKey key]
        {
            get
            {
                TValue value;
                TryGetValue(key, out value);
                return value;
            }

            set => Add(key, value);
        }

        public HashMap(int size = 256, IEqualityComparer<TKey> comparer = null)
        {
            this.size = size;
            this.buckets = new LinkedList<KeyValuePair<TKey, TValue>>[size];
            keyComparer = comparer ?? EqualityComparer<TKey>.Default;
        }

        public void Add(TKey key, TValue value)
        {
            if(ContainsKey(key))
            {
                throw new ArgumentException("key already exists in the hashmap");
            }

            if (buckets[GetBucketIndex(key)] == null)
            {
                buckets[GetBucketIndex(key)] = new LinkedList<KeyValuePair<TKey, TValue>>();
                buckets[GetBucketIndex(key)].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            }
            else
            {
                buckets[GetBucketIndex(key)].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            }

            Keys.Add(key);
            Values.Add(value);
            count++;
        }

        public bool ContainsKey(TKey key)
        {
            int hash = keyComparer.GetHashCode(key);

            if (buckets[GetBucketIndex(key)] is null or default(LinkedList<KeyValuePair<TKey, TValue>>)) return false;

            if (buckets[GetBucketIndex(key)].Any(pair => keyComparer.Equals(pair.Key, key)))
            {
                return true;
            }

            return false;
        }

        public bool Remove(TKey key)
        {
            KeyValuePair<TKey, TValue> pairRemoved = default;
            if (buckets[GetBucketIndex(key)] != null && buckets[GetBucketIndex(key)].Remove(buckets[GetBucketIndex(key)]
                .First(pair => keyComparer.Equals((pairRemoved = pair).Key, key))))
            {
                count--;
                Keys.Remove(key);
                Values.Remove(pairRemoved.Value);
                return true;
            }

            return false;
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            if (!ContainsKey(key))
            {
                throw new Exception(":3");
            }

            int hash = keyComparer.GetHashCode(key);

            value = buckets[GetBucketIndex(key)].First(pair => keyComparer.Equals(pair.Key, key)).Value;
            return true;
        }

        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        // chatgpt unit test compatibility
        public void Put(TKey key, TValue value) => Add(key, value);
        public void Put(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);
        public bool Get(TKey key, [MaybeNullWhen(false)] out TValue value) => TryGetValue(key, out value);
        public TValue Get(TKey key)
        {
            TValue value;
            if (TryGetValue(key, out value)) return value;
            return default;
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

            if (buckets[GetBucketIndex(item.Key)] == null) return false;

            if (buckets[GetBucketIndex(item.Key)].Any(pair => pair.Equals(item)))
            {
                return true;
            }

            return false;
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            for(int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] == null || buckets[i].Count == 0) continue;
                if(arrayIndex + buckets[i].Count >= array.Length)
                    throw new Exception("read documentation section 1a clause 5 to see what this means");

                buckets[i].CopyTo(array, arrayIndex += buckets[i].Count);
            }
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            int hash = keyComparer.GetHashCode(item.Key);

            bool wasRemoved = false;
            buckets[GetBucketIndex(item.Key)].DistinctBy(elementToRemove => wasRemoved = buckets[GetBucketIndex(item.Key)].Remove(elementToRemove));
            return wasRemoved;
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            int totalCount = 0;
            for (int i = 0; i < buckets.Length; i++)
            {
                if (buckets[i] == null) continue;
                totalCount += buckets[i].Count;
            }

            KeyValuePair<TKey, TValue>[] data = new KeyValuePair<TKey, TValue>[totalCount];

            CopyTo(data, 0);

            return new Enumatoratorer<KeyValuePair<TKey, TValue>>(data);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private int GetBucketIndex(TKey key)
        {
            int hash = keyComparer.GetHashCode(key);
            return Math.Abs(hash % size);
        }
    }

    // the big enumerta r thingeruy

    public class Enumatoratorer<T> : IEnumerator<T>
    {
        T IEnumerator<T>.Current => Data[index];

        object IEnumerator.Current => Data[index];

        private T[] Data;
        private int index = 0;

        public Enumatoratorer(T[] data)
        {
            Data = data;
        }

        public void Dispose()
        {
            Data = null;
        }

        public bool MoveNext()
        {
            if(index < Data.Length)
            {
                index++;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            index = 0;
        }
    }
}