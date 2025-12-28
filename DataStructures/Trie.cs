using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Clear() // Delete all data in the Trie
        {
            throw new NotImplementedException();
        }

        public void Insert(string word) // Add a word to the Trie
        {
            throw new NotImplementedException();
        }

        private TrieNode SearchNode(string prefix) // Find the node at the end of this prefix. Use this function WHENEVER you need to find a node.
        {
            throw new NotImplementedException();
        }

        public bool Contains(string word) // Return if a given word exists (use SearchNode)
        {
            throw new NotImplementedException();
        }

        public List<string> GetAllMatchingPrefix(string prefix) // Get every word after a given prefix
        {
            throw new NotImplementedException();
        }

        public bool Remove(string word) // Remove a given word if it exists, and return if you found it
        {
            throw new NotImplementedException();
        }
    }

}
