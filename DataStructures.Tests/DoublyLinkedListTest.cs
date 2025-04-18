﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures;

namespace DataStructures.Tests
{
    public class DoublyLinkedListTest
    {
        private bool isCircularList(DoublyLinkedList<int> list)
        {
            return list.Head.Previous.Next == list.Head;
        }

        private bool isValidDoubleCircularList(DoublyLinkedList<int> list, int[] expected)
        { 
            
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
            Assert.True(isCircularList(list));
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 3, 7, 5 })]
        public void AddFirst(int[] toAdd, int[] expected)
        {
            DoublyLinkedList<int> list = new();

            for (int i = 0; i < toAdd.Length; i++) list.AddFirst(toAdd[i]);

            DoublyLinkedNode<int> currentDoublyLinkedNode = list.Head;

            Assert.True(isCircularList(list));
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(currentDoublyLinkedNode.Value == expected[i]);
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }
        }

        // TODO: make sure this test is valid code
        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 3, 7, 5 })]
        public void AddBefore(int[] toAdd, int[] expected)
        {
            DoublyLinkedList<int> list = new();

            list.AddFirst(toAdd[0]);

            for (int i = 1; i < toAdd.Length; i++) list.AddBefore(list.Head, toAdd[i]);

            DoublyLinkedNode<int> currentDoublyLinkedNode = list.Head;

            Assert.True(isCircularList(list));
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(currentDoublyLinkedNode.Value == expected[i]);
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }
        }
        // TODO: modify add after to be able to work with an empty list
        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 5, 3, 7 })]
        public void AddAfter(int[] toAdd, int[] expected)
        {
            DoublyLinkedList<int> list = new();

            list.AddFirst(toAdd[0]);

            for (int i = 1; i < toAdd.Length; i++) list.AddAfter(list.Head, toAdd[i]);

            DoublyLinkedNode<int> currentDoublyLinkedNode = list.Head;

            Assert.True(isCircularList(list));
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(currentDoublyLinkedNode.Value == expected[i]);
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 7, 3 }, new int[] { 5 })]
        public void Remove(int[] toAdd, int[] toRemove, int[] expected)
        {
            DoublyLinkedList<int> list = new();

            DoublyLinkedNode<int> currentNode = list.AddFirst(toAdd[0]);
            for (int i = 1; i < toAdd.Length; i++) currentNode = list.AddAfter(currentNode, toAdd[i]);

            for (int i = 0; i < toRemove.Length; i++) list.Remove(toRemove[i]);

            DoublyLinkedNode<int> currentDoublyLinkedNode = list.Head;

            Assert.True(isCircularList(list));
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(currentDoublyLinkedNode.Value == expected[i]);
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 7, 9 }, new bool[] { true, false })]
        public void Search(int[] toAdd, int[] toSearch, bool[] expected)
        {
            DoublyLinkedList<int> list = new();

            DoublyLinkedNode<int> currentDoublyLinkedNode = list.AddFirst(toAdd[0]);
            for (int i = 1; i < toAdd.Length; i++) currentDoublyLinkedNode = list.AddAfter(currentDoublyLinkedNode, toAdd[i]);

            DoublyLinkedNode<int>[] nodes = new DoublyLinkedNode<int>[toSearch.Length];
            for (int i = 0; i < toSearch.Length; i++) nodes[i] = list.Search(toSearch[i]);

            Assert.True(isCircularList(list));
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

            DoublyLinkedNode<int> currentDoublyLinkedNode = list.AddFirst(toAdd[0]);
            for (int i = 1; i < toAdd.Length; i++) currentDoublyLinkedNode = list.AddAfter(currentDoublyLinkedNode, toAdd[i]);

            bool[] results = new bool[toSearch.Length];
            for (int i = 0; i < toSearch.Length; i++) results[i] = list.Contains(toSearch[i]);

            Assert.True(isCircularList(list));
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

            DoublyLinkedNode<int> currentDoublyLinkedNode = list.AddFirst(toAdd[0]);
            for (int i = 1; i < toAdd.Length; i++) currentDoublyLinkedNode = list.AddAfter(currentDoublyLinkedNode, toAdd[i]);

            Assert.True(isCircularList(list));
            Assert.True(list.Contains(list.Head) == expected);
        }
    }
}
