using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures;

namespace DataStructures.Tests
    {
        public class GenericDequeTest
    {
            [Theory]
            [InlineData(new int[] { 5, 7, 3 }, new int[] { 3, 7, 5 })]
            [InlineData(new int[] { }, new int[] { })]
            [InlineData(new int[] { 5 }, new int[] { 5 })]
            public void StackPush(int[] toAdd, int[] expected)
            {
                IStack<int> queue = new GenericDeque<int>();
                for (int i = 0; i < toAdd.Length; i++) queue.Push(toAdd[i]);
                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.True(queue.Pop() == expected[i]);
                }
            }

            [Theory]
            [InlineData(new int[] { 7, 4, 2 }, new int[] { 7, 4, 2 })]
            public void StackPeek(int[] toAdd, int[] expected)
            {
                IStack<int> queue = new GenericDeque<int>();
                for (int i = 0; i < toAdd.Length; i++)
                {
                    queue.Push(toAdd[i]);
                    Assert.True(queue.Peek() == expected[i]);
                }
            }

            [Theory]
            [InlineData(new int[] { 5, 7, 3 }, new int[] { 5, 7, 3 })]
            [InlineData(new int[] { }, new int[] { })]
            [InlineData(new int[] { 5 }, new int[] { 5 })]
            public void QueueQueue(int[] toAdd, int[] expected)
            {
                IQueue<int> queue = new GenericDeque<int>();
                for (int i = 0; i < toAdd.Length; i++) queue.Enqueue(toAdd[i]);
                for (int i = 0; i < expected.Length; i++)
                {
                    Assert.True(queue.Dequeue() == expected[i]);
                }
            }

            [Theory]
            [InlineData(new int[] { 7, 4, 2 }, new int[] { 7, 7, 7 })]
            public void QueuePeek(int[] toAdd, int[] expected)
            {
                IQueue<int> queue = new GenericDeque<int>();
                for (int i = 0; i < toAdd.Length; i++)
                {
                    queue.Enqueue(toAdd[i]);
                    Assert.True(queue.Peek() == expected[i]);
                }
            }
    }
}