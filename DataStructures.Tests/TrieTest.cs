using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DataStructures.Tests
{
    public class TrieTest
    {
        [Theory]
        [InlineData("apple", "banana", "grape", "orange", "pear")]
        [InlineData("tex", "trapped", "me", "in", "his", "basement", "please", "help")]
        public void Insert_ShouldAddWords(params string[] values)
        {
            Trie trie = new Trie();

            for (int i = 0; i < values.Length; i++)
            {
                trie.Insert(values[i]);
            }

            for (int i = 0; i < values.Length; i++)
            {
                Assert.True(trie.Contains(values[i]));
            }
        }

        [Theory]
        [InlineData("apple", "banana", "grape", "orange", "pear")]
        [InlineData("tex", "trapped", "me", "in", "his", "basement", "please", "help")]
        public void Remove_ShouldRemove(params string[] values)
        {
            Trie trie = new Trie();

            for (int i = 0; i < values.Length; i++)
            {
                trie.Insert(values[i]);
            }

            Random random = new Random();
            int indexToRemove = random.Next(0, values.Length);
            trie.Remove(values[indexToRemove]);

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == values[indexToRemove]) continue;

                Assert.True(trie.Contains(values[i]));
            }
        }

        [Theory]
        [InlineData("he", "heap", "heave", "hey", "heaven", "heat", "heal", "heated", "heater", "healing", "head", "her", "hecate")]
        public void GetAllMatchingPrefixes_ShouldReturnWordsWithPrefix(string prefix, params string[] values)
        {
            Trie trie = new Trie();

            trie.Insert(prefix);
            for (int i = 0; i < values.Length; i++)
            {
                trie.Insert(values[i]);
            }

            List<string> results = trie.GetAllMatchingPrefix(prefix);
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].StartsWith(prefix))
                {
                    Assert.Contains(values[i], results);
                }
            }
        }

        [Fact]
        public void Clear_ShouldRemoveAllWords() // ily chartgpted
        {
            Trie trie = new Trie();
            trie.Insert("apple");
            trie.Insert("banana");
            trie.Insert("grape");
            trie.Clear();
            Assert.False(trie.Contains("apple"));
            Assert.False(trie.Contains("banana"));
            Assert.False(trie.Contains("grape"));
        }
    }
}
