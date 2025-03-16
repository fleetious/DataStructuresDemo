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
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 5, 7, 3 })]
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
    }
}
