using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures;

namespace DataStructures.Tests
{
    public class GenericStacksTest
    {
        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 3, 7, 5 })]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { 5 }, new int[] { 5 })]
        public void LinkedListPush(int[] toAdd, int[] expected)
        {
            GenericLinkedListStack<int> queue = new();
            for (int i = 0; i < toAdd.Length; i++) queue.Push(toAdd[i]);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(queue.Pop() == expected[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 7, 4, 2 }, new int[] { 7, 4, 2 })]
        public void LinkedListPeek(int[] toAdd, int[] expected)
        {
            GenericLinkedListStack<int> queue = new();
            for (int i = 0; i < toAdd.Length; i++)
            {
                queue.Push(toAdd[i]);
                Assert.True(queue.Peek() == expected[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 3, 7, 5 })]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { 5 }, new int[] { 5 })]
        public void ArrayPush(int[] toAdd, int[] expected)
        {
            GenericArrayStack<int> queue = new();
            for (int i = 0; i < toAdd.Length; i++) queue.Push(toAdd[i]);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(queue.Pop() == expected[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 7, 4, 2 }, new int[] { 7, 4, 2 })]
        public void ArrayPeek(int[] toAdd, int[] expected)
        {
            GenericArrayStack<int> queue = new();
            for (int i = 0; i < toAdd.Length; i++)
            {
                queue.Push(toAdd[i]);
                Assert.True(queue.Peek() == expected[i]);
            }
        }
    }
}