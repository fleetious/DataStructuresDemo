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
        [Theory]
        [InlineData(new int[] { 0 })]
        [InlineData(new int[] { 0, 1, 2, 3, 4, 5 })]
        public void Insert(int[] values)
        {
            BinaryHeapTree<int> tree = new BinaryHeapTree<int>();

            for(int i = 0; i < values.Length; i++)
            {
                tree.Insert(values[i]);
            }
        }
    }
}
