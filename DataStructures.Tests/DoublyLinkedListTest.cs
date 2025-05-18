using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures;

namespace DataStructures.Tests
{
    public class DoublyLinkedListTest
    {
        private static bool IsValidDoubleCircularList(DoublyLinkedList<int> list, int[] expected)
        {
            DoublyLinkedListNode<int> previous = list.Head.Previous;
            DoublyLinkedListNode<int> current = list.Head;

            Assert.True(list.Count == expected.Length);

            for (int i = 0; i < list.Count; i++)
            {
                Assert.True(current.Previous == previous);
                Assert.True(previous.Next == current);
                Assert.True(current.Value == expected[i]);

                previous = current;
                current = current.Next;
            }

            Assert.True(current == list.Head);
            Assert.True(previous == list.Head.Previous);
            Assert.True(previous.Next == current);

            return true;
        }

        [Fact]
        public void Empty()
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            Assert.Null(list.Head);
            Assert.True(list.Count == 0);
        }

        [Fact]
        public void AddFirstOne()
        { 
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();

            list.AddFirst(5);

            Assert.True(list.Head == list.Head.Next);
            Assert.True(list.Head == list.Head.Previous);
            Assert.True(list.Count == 1);
            Assert.True(IsValidDoubleCircularList(list, new int[] { 5 }));
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 3, 7, 5 })]
        public void AddFirst(int[] toAdd, int[] expected)
        {
            DoublyLinkedList<int> list = new();

            for (int i = 0; i < toAdd.Length; i++) list.AddFirst(toAdd[i]);

            DoublyLinkedListNode<int> currentDoublyLinkedNode = list.Head;

            Assert.True(IsValidDoubleCircularList(list, expected));
        }

        // TODO: make sure this test is valid code
        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 3, 7, 5 })]
        public void AddBefore(int[] toAdd, int[] expected)
        {
            DoublyLinkedList<int> list = new();

            list.AddFirst(toAdd[0]);

            for (int i = 1; i < toAdd.Length; i++) list.AddBefore(list.Head, toAdd[i]);

            DoublyLinkedListNode<int> currentDoublyLinkedNode = list.Head;

            Assert.True(IsValidDoubleCircularList(list, expected));
        }
        // TODO: modify add after to be able to work with an empty list
        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 5, 3, 7 })]
        public void AddAfter(int[] toAdd, int[] expected)
        {
            DoublyLinkedList<int> list = new();

            list.AddFirst(toAdd[0]);

            for (int i = 1; i < toAdd.Length; i++) list.AddAfter(list.Head, toAdd[i]);

            DoublyLinkedListNode<int> currentDoublyLinkedNode = list.Head;

            Assert.True(IsValidDoubleCircularList(list, expected));
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 7, 3 }, new int[] { 5 })]
        public void Remove(int[] toAdd, int[] toRemove, int[] expected)
        {
            DoublyLinkedList<int> list = new();

            DoublyLinkedListNode<int> currentNode = list.AddFirst(toAdd[0]);
            for (int i = 1; i < toAdd.Length; i++) currentNode = list.AddAfter(currentNode, toAdd[i]);

            for (int i = 0; i < toRemove.Length; i++) list.Remove(toRemove[i]);

            DoublyLinkedListNode<int> currentDoublyLinkedNode = list.Head;

            Assert.True(IsValidDoubleCircularList(list, expected));
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 7, 9 }, new bool[] { true, false })]
        public void Search(int[] toAdd, int[] toSearch, bool[] expected)
        {
            DoublyLinkedList<int> list = new();

            DoublyLinkedListNode<int> currentDoublyLinkedNode = list.AddFirst(toAdd[0]);
            for (int i = 1; i < toAdd.Length; i++) currentDoublyLinkedNode = list.AddAfter(currentDoublyLinkedNode, toAdd[i]);

            DoublyLinkedListNode<int>[] nodes = new DoublyLinkedListNode<int>[toSearch.Length];
            for (int i = 0; i < toSearch.Length; i++) nodes[i] = list.Search(toSearch[i]);

            Assert.True(IsValidDoubleCircularList(list, toAdd));
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True((nodes[i] != null) == expected[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 7, 67676767 }, new bool[] { true, false })]
        public void ContainsValue(int[] toAdd, int[] toSearch, bool[] expected)
        {
            DoublyLinkedList<int> list = new();

            DoublyLinkedListNode<int> currentDoublyLinkedNode = list.AddFirst(toAdd[0]);
            for (int i = 1; i < toAdd.Length; i++) currentDoublyLinkedNode = list.AddAfter(currentDoublyLinkedNode, toAdd[i]);

            bool[] results = new bool[toSearch.Length];
            for (int i = 0; i < toSearch.Length; i++) results[i] = list.Contains(toSearch[i]);

            Assert.True(IsValidDoubleCircularList(list, toAdd));
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(results[i] == expected[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, true)]
        public void ContainsDoublyLinkedNode(int[] toAdd, bool expected)
        {
            DoublyLinkedList<int> list = new();

            DoublyLinkedListNode<int> currentDoublyLinkedNode = list.AddFirst(toAdd[0]);
            for (int i = 1; i < toAdd.Length; i++) currentDoublyLinkedNode = list.AddAfter(currentDoublyLinkedNode, toAdd[i]);

            Assert.True(IsValidDoubleCircularList(list, toAdd));
            Assert.True(list.Contains(list.Head) == expected);
        }
    }
}
