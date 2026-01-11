using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    public class AVLTreeTest
    {

        private bool IsValidAVLTree(AVLTree<int> tree)
        {
            throw new NotImplementedException(); // ykw im kinda lazy lowkey
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 8, 4 })]
        [InlineData(new int[] { 1, 3, 2, 4 })] // substitute for acbd in the example gif on the wiki
        [InlineData(new int[] { 1, 3, 2 })] // double rotation test
        public void Insert(int[] valuesToInsert)
        {
            AVLTree<int> tree = new AVLTree<int>();

            for (int i = 0; i < valuesToInsert.Length; i++)
            {
                tree.Insert(valuesToInsert[i]);
            }

            for (int i = 0; i < valuesToInsert.Length; i++)
            {
                Assert.True(tree.Contains(valuesToInsert[i]));
            }
        }

        [Theory]
        [InlineData(new int[] { 5, 7, 8, 4 }, new int[] { 7 })]
        public void Remove(int[] valuesToInsert, int[] valuesToRemove) // chatgpt my beeloved
        { // woww this is literally the same as the generic tree test lmao i should make a base class for these tests later :D :D :D :D :D :D :D :D :D :D :D yes :D :D :D :D :D :D :D  :D :D :D
            AVLTree<int> tree = new AVLTree<int>();
            for (int i = 0; i < valuesToInsert.Length; i++)
            {
                tree.Insert(valuesToInsert[i]);
            }
            for (int i = 0; i < valuesToRemove.Length; i++)
            {
                tree.Remove(valuesToRemove[i]);
            }
            for (int i = 0; i < valuesToRemove.Length; i++)
            {
                Assert.True(!tree.Contains(valuesToRemove[i]));
            }
            for (int i = 0; i < valuesToInsert.Length; i++)
            {
                if (!valuesToRemove.Contains(valuesToInsert[i]))
                    Assert.True(tree.Contains(valuesToInsert[i]));
            }
        }

        [Theory]
        [InlineData(new int[] { 8, 5, 7, 2, 11, 13, 9 }, new int[] { 7, 5, 2, 11, 8, 9, 13 })]
        [InlineData(new int[] { 5 }, new int[] { 5 })]
        public void PreOrderTraverse(int[] valuesToInsert, int[] expectedValues)
        {
            AVLTree<int> tree = new AVLTree<int>();

            for (int i = 0; i < valuesToInsert.Length; i++)
            {
                tree.Insert(valuesToInsert[i]);
            }

            int[] values = tree.Traverse();

            for (int i = 0; i < values.Length; i++)
                Assert.True(values[i] == expectedValues[i]);
        }
    }
}
