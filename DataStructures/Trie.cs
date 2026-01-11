using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class TrieNode
    {
        public char Letter { get; private set; } // The letter of the current node
        public Dictionary<char, TrieNode> Children { get; private set; } // All known continuations from the current letter in the current prefix keyed off their beginning letters
        public bool IsWord { get; set; } // Whether or not the current node is at the end of a word

        public TrieNode(char c)
        {
            Children = new Dictionary<char, TrieNode>();
            Letter = c;
            IsWord = false;
        }
    }

    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            root = new TrieNode(default);
        }

        public void Clear() // Delete all data in the Trie
        {
            root = new TrieNode(default);
        }

        public void Insert(string word) // Add a word to the Trie
        {
            Insert(word, 0, root);
        }

        private void Insert(string word, int index, TrieNode currentNode)
        {
            if (index >= word.Length)
            {
                currentNode.IsWord = true;
                return;
            }

            currentNode.Children.TryAdd(word[index], new TrieNode(word[index]));
            TrieNode newRoot;
            currentNode.Children.TryGetValue(word[index], out newRoot);
            Insert(word, index + 1, newRoot);
        }

        private TrieNode SearchNode(string prefix) // Find the node at the end of this prefix. Use this function WHENEVER you need to find a node.
        {
            return SearchNode(prefix, 0, root);
        }

        private TrieNode SearchNode(string prefix, int index, TrieNode currentNode) // Find the node at the end of this prefix. Use this function WHENEVER you need to find a node.
        {
            if (index >= prefix.Length) return currentNode;

            TrieNode newRoot;

            if (currentNode.Children.TryGetValue(prefix[index], out newRoot) == false)
            {
                return null;
            }

            return SearchNode(prefix, index + 1, newRoot);
        }

        public bool Contains(string word) // Return if a given word exists (use SearchNode)
        {
            return SearchNode(word) != null;
        }

        public List<string> StartsWith(string prefix)
        {
            return GetAllMatchingPrefix(prefix);
        }

        public List<string> GetAllMatchingPrefix(string prefix) // Get every word after a given prefix
        {
            TrieNode trieNode = SearchNode(prefix);

            if (trieNode == null)
            {
                return new List<string>();
            }

            return GetAllMatchingPrefix(trieNode, prefix, new List<string>());
        }

        private static List<string> GetAllMatchingPrefix(TrieNode currentNode, string prefix, List<string> results) // Helper function for GetAllMatchingPrefix ty chatgpt
        {
            if (currentNode == null) return results;

            Dictionary<char, TrieNode> children = currentNode.Children;
            foreach (TrieNode node in children.Values) // what this
            {
                if (node.IsWord)
                {
                    results.Add(prefix + node.Letter.ToString());
                }

                GetAllMatchingPrefix(node, prefix + node.Letter.ToString(), results);
            }

            return results;
        }

        public bool Remove(string word) // Remove a given word if it exists, and return if you found it
        {
            return Remove(word, 0, root);
        }

        private bool Remove(string word, int index, TrieNode currentNode)
        {
            if (index >= word.Length)
            {
                currentNode = null;
                return true;
            }

            TrieNode newRoot;

            if (currentNode.Children.TryGetValue(word[index], out newRoot) == false)
            {
                return false;
            }

            return Remove(word, index + 1, newRoot);
        }
    }
}
