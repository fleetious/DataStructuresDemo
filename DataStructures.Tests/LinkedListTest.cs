using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures;

namespace DataStructures.Tests
{
    public class LinkedListTest
    {
        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 3, 7, 5 })]
        public void AddFirst(int[] toAdd, int[] expected)
        {
            GenericLinkedList<int> list = new();

            for (int i = 0; i < toAdd.Length; i++) list.AddFirst(toAdd[i]);

            Node<int> currentNode = list.Head;

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(currentNode.Value == expected[i]);
                currentNode = currentNode.Next;
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 5, 7, 3 })]
        public void AddLast(int[] toAdd, int[] expected)
        {
            GenericLinkedList<int> list = new();

            for (int i = 0; i < toAdd.Length; i++) list.AddLast(toAdd[i]);

            Node<int> currentNode = list.Head;

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(currentNode.Value == expected[i]);
                currentNode = currentNode.Next;
            }
        }
        // TODO: make sure this test is valid code
        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 3, 7, 5 })]
        public void AddBefore(int[] toAdd, int[] expected)
        {
            GenericLinkedList<int> list = new();

            list.AddFirst(toAdd[0]);

            for (int i = 1; i < toAdd.Length; i++) list.AddBefore(list.Head, toAdd[i]);

            Node<int> currentNode = list.Head;

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(currentNode.Value == expected[i]);
                currentNode = currentNode.Next;
            }
        }
        // TODO: modify add after to be able to work with an empty list
        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 5, 3, 7 })]
        public void AddAfter(int[] toAdd, int[] expected)
        {
            GenericLinkedList<int> list = new();

            list.AddFirst(toAdd[0]);

            for (int i = 1; i < toAdd.Length; i++) list.AddAfter(list.Head, toAdd[i]);

            Node<int> currentNode = list.Head;

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(currentNode.Value == expected[i]);
                currentNode = currentNode.Next;
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 7, 3 }, new int[] { 5 })]
        public void Remove(int[] toAdd, int[] toRemove, int[] expected)
        {
            GenericLinkedList<int> list = new();

            for (int i = 0; i < toAdd.Length; i++) list.AddLast(toAdd[i]);

            for (int i = 0; i < toRemove.Length; i++) list.Remove(toRemove[i]);

            Node<int> currentNode = list.Head;

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(currentNode.Value == expected[i]);
                currentNode = currentNode.Next;
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 7, 9 }, new bool[] { true, false })]
        public void Search(int[] toAdd, int[] toSearch, bool[] expected)
        {
            GenericLinkedList<int> list = new();

            for (int i = 0; i < toAdd.Length; i++) list.AddLast(toAdd[i]);

            Node<int>[] nodes = new Node<int>[toSearch.Length];
            for (int i = 0; i < toSearch.Length; i++) nodes[i] = list.Search(toSearch[i]);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True((nodes[i] != null) == expected[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 7, 67676767 }, new bool[] { true, false })]
        public void ContainsValue(int[] toAdd, int[] toSearch, bool[] expected)
        {
            GenericLinkedList<int> list = new();

            for (int i = 0; i < toAdd.Length; i++) list.AddLast(toAdd[i]);

            bool[] results = new bool[toSearch.Length];
            for (int i = 0; i < toSearch.Length; i++) results[i] = list.Contains(toSearch[i]);

            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(results[i] == expected[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, true)]
        public void ContainsNode(int[] toAdd, bool expected)
        {
            GenericLinkedList<int> list = new();

            for (int i = 0; i < toAdd.Length; i++) list.AddLast(toAdd[i]);

            Assert.True(list.Contains(list.Head) == expected);
        }
    }
}
