using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures;

namespace DataStructures.Tests
{
    public class GenericQueuesTest
    {
        [Theory]
        [InlineData(new int[] { 5, 7, 3 }, new int[] { 5, 7, 3 })]
        public void LinkedListQueue(int[] toAdd, int[] expected)
        {
            GenericLinkedListQueue<int> queue = new();
            for (int i = 0; i < toAdd.Length; i++) queue.Enqueue(toAdd[i]);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(queue.Dequeue() == expected[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 7, 4, 2 }, new int[] { 7, 7, 7 })]
        public void LinkedListPeek(int[] toAdd, int[] expected)
        {
            GenericLinkedListQueue<int> queue = new();
            for (int i = 0; i < toAdd.Length; i++)
            {
                queue.Enqueue(toAdd[i]);
                Assert.True(queue.Peek() == expected[i]);
            }
        }
    }
}