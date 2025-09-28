using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    public class AVLTreeTest
    {
        [Theory]
        [InlineData(new int[] { 5, 7, 8, 4 })]
        public void Insert(int[] valuesToInsert)
        {
            AVLTree<int> tree = new AVLTree<int>();

            for (int i = 0; i < valuesToInsert.Length; i++)
            {
                tree.Insert(valuesToInsert[i]);
            }
        }
    }
}
