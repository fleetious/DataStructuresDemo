using DataStructures;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;
namespace DataStructures.Tests
{
    public class HashMapTests
    {
        private IDictionary<string, int> CreateMap()
        {
            // assumes your HashMap implements IDictionary<TKey, TValue>
            return new HashMap<string, int>();
        }

        [Fact]
        public void Add_And_Indexer_Get_Works()
        {
            var map = CreateMap();

            map.Add("a", 1);

            Assert.Equal(1, map["a"]);
        }

        [Fact]
        public void Indexer_Set_Overwrites()
        {
            var map = CreateMap();

            map.Add("key", 1);

            map["key"] = 2;

            Assert.Equal(2, map["key"]);
        }

        [Fact]
        public void Add_DuplicateKey_Throws()
        {
            var map = CreateMap();

            map.Add("a", 1);

            Assert.Throws<ArgumentException>(() => map.Add("a", 2));
        }

        [Fact]
        public void ContainsKey_Works()
        {
            var map = CreateMap();

            map.Add("a", 1);

            Assert.True(map.ContainsKey("a"));
            Assert.False(map.ContainsKey("b"));
        }

        [Fact]
        public void Remove_ByKey_Works()
        {
            var map = CreateMap();

            map.Add("a", 1);
            var removed = map.Remove("a");

            Assert.True(removed);
            Assert.False(map.ContainsKey("a"));
        }

        [Fact]
        public void TryGetValue_Works()
        {
            var map = CreateMap();

            map.Add("a", 1);

            var found = map.TryGetValue("a", out int value);

            Assert.True(found);
            Assert.Equal(1, value);
        }

        [Fact]
        public void TryGetValue_NotFound()
        {
            var map = CreateMap();

            var found = map.TryGetValue("x", out int value);

            Assert.False(found);
            Assert.Equal(0, value); // default(int)
        }

        [Fact]
        public void Keys_Collection_Works()
        {
            var map = CreateMap();

            map.Add("a", 1);
            map.Add("b", 2);

            var keys = map.Keys.ToList();

            Assert.Contains("a", keys);
            Assert.Contains("b", keys);
            Assert.Equal(2, keys.Count);
        }

        [Fact]
        public void Values_Collection_Works()
        {
            var map = CreateMap();

            map.Add("a", 1);
            map.Add("b", 2);

            var values = map.Values.ToList();

            Assert.Contains(1, values);
            Assert.Contains(2, values);
            Assert.Equal(2, values.Count);
        }

        [Fact]
        public void Count_TracksItems()
        {
            var map = CreateMap();

            map.Add("a", 1);
            map.Add("b", 2);

            Assert.Equal(2, map.Count);
        }

        [Fact]
        public void Clear_RemovesAll()
        {
            var map = CreateMap();

            map.Add("a", 1);
            map.Add("b", 2);

            map.Clear();

            Assert.Empty(map);
        }

        [Fact]
        public void Contains_KeyValuePair_Works()
        {
            var map = CreateMap();

            map.Add("a", 1);

            Assert.True(map.Contains(new KeyValuePair<string, int>("a", 1)));
            Assert.False(map.Contains(new KeyValuePair<string, int>("a", 2)));
        }

        [Fact]
        public void Remove_KeyValuePair_Works()
        {
            var map = CreateMap();

            KeyValuePair<string, int> harkharkhark = new KeyValuePair<string, int>("a", 1);

            map.Add(harkharkhark);

            var removed = map.Remove(harkharkhark);
            Assert.True(removed);
            Assert.False(map.ContainsKey("a"));
        }

        [Fact]
        public void CopyTo_Works()
        {
            var map = CreateMap();

            map.Add("a", 1);
            map.Add("b", 2);

            var array = new KeyValuePair<string, int>[2];

            map.CopyTo(array, 0);

            Assert.Contains(array, kvp => kvp.Key == "a" && kvp.Value == 1);
            Assert.Contains(array, kvp => kvp.Key == "b" && kvp.Value == 2);
        }

        [Fact]
        public void Enumerator_IteratesAllItems()
        {
            var map = CreateMap();

            map.Add("a", 1);
            map.Add("b", 2);

            var seen = new List<string>();

            foreach (var kvp in map)
            {
                seen.Add(kvp.Key);
            }

            Assert.Contains("a", seen);
            Assert.Contains("b", seen);
            Assert.Equal(2, seen.Count);
        }

        

        [Fact]
        public void Enumerator_Reset_Works()
        {
            var map = CreateMap();

            map.Add("a", 1);
            map.Add("b", 2);

            var enumerator = map.GetEnumerator();

            Assert.True(enumerator.MoveNext());
            enumerator.Reset();

            // After reset, should iterate again
            int count = 0;
            while (enumerator.MoveNext())
            {
                count++;
            }

            Assert.Equal(2, count);
        }

        [Fact]
        public void NullKey_Throws()
        {
            var map = CreateMap();

            Assert.Throws<ArgumentNullException>(() => map.Add(null, 1));
        }

        [Fact]
        public void Large_Insert_PreservesAllValues()
        {
            var map = CreateMap();

            for (int i = 0; i < 1000; i++)
            {
                map.Add(i.ToString(), i);
            }

            for (int i = 0; i < 1000; i++)
            {
                Assert.Equal(i, map[i.ToString()]);
            }
        }
    }
}