using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataStructures;

namespace DataStructures.Tests
{
    public class BinaryHeapTreeTest
    {
        private BinaryHeapTree<int> GetNewTree()
        {
            return new BinaryHeapTree<int>();
        }

        [Theory]
        [InlineData(new int[] { 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 })]
        public void Insert(int[] values)
        {
            BinaryHeapTree<int> tree = GetNewTree();

            for(int i = 0; i < values.Length; i++)
            {
                tree.Insert(values[i]);
            }
        }

        [Theory]
        [InlineData(new int[] { 0 }, 1)]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 }, 2)]
        public void Pop(int[] values, int removes)
        {
            BinaryHeapTree<int> tree = GetNewTree();

            for (int i = 0; i < values.Length; i++)
            {
                tree.Insert(values[i]);
            }

            for (int i = 0; i < removes; i++)
            {
                int value = tree.Pop();

                Assert.True(!tree.Contains(value));
            }
        }
    }
}
