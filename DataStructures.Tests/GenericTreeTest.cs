using System;
using Xunit;
using DataStructures;

namespace DataStructures.Tests;

public class GenericTreeTest
{
    private bool IsValidTree(GenericTree<int> tree)
    {
        List<BSTNode<int>> leaves = new();
        leaves.Add(tree.Root);
        for (int i = 0; i < tree.Depth; i++)
        {
            for (int j = 1; j < leaves.Count; j++)
            {
                if (leaves[i].Left != null && !leaves.Contains(leaves[i].Left))
                    leaves.Insert(j - 1, leaves[i].Left);
                if (leaves[i].Right != null && !leaves.Contains(leaves[i].Right))
                    leaves.Insert(j, leaves[i].Right);
            }
        }

        for (int i = 1; i < leaves.Count; i++)
            Assert.True(leaves[i - 1].Value < leaves[i].Value);

        return true;
    }

    [Theory]
    [InlineData(new int[] { 5, 6, 7, 8, 9 }, new int[] { 5 })]
    [InlineData(new int[] { 5, 6, 7 }, new int[] { 7 })]
    [InlineData(new int[] { 5, 3, 4, 2 }, new int[] { 3 })]
    public void RemoveValue(int[] nums, int[] valuesToRemove)
    {
        GenericTree<int> tree = new GenericTree<int>(nums[0]);

        for (int i = 1; i < nums.Length; i++)
            tree.Insert(nums[i]);

        for (int i = 0; i < valuesToRemove.Length; i++)
            tree.Remove(valuesToRemove[i]);

        for (int i = 0; i < valuesToRemove.Length; i++)
            Assert.True(!tree.Contains(valuesToRemove[i]));

        Assert.True(IsValidTree(tree));
    }

    [Theory]
    [InlineData(new int[] { 8, 5, 7, 2, 11, 13, 9 })]
    [InlineData(new int[] { 5 })]
    public void Insert(int[] valuesToInsert)
    {
        GenericTree<int> tree = new GenericTree<int>(valuesToInsert[0]);

        for (int i = 1; i < valuesToInsert.Length; i++)
        {
            tree.Insert(valuesToInsert[i]);
        }

        for (int i = 0; i < valuesToInsert.Length; i++)
            Assert.True(tree.Contains(valuesToInsert[i]));

        Assert.True(IsValidTree(tree));
    }

    [Theory]
    [InlineData(new int[] { 8, 5, 7, 2, 11, 13, 9 })]
    [InlineData(new int[] { 5 })]
    public void InOrderTraverse(int[] valuesToInsert)
    {
        GenericTree<int> tree = new GenericTree<int>(valuesToInsert[0]);

        for (int i = 1; i < valuesToInsert.Length; i++)
        {
            tree.Insert(valuesToInsert[i]);
        }

        List<int> values = tree.Traverse(TreeTraversalMethod.InOrderTraversal);

        for (int i = 1; i < values.Count; i++)
            Assert.True(values[i - 1] < values[i]);
    }

    [Theory]
    [InlineData(new int[] { 8, 5, 7, 2, 11, 13, 9 }, new int[] { 8, 5, 11, 2, 7, 9, 13 })]
    [InlineData(new int[] { 5 }, new int[] { 5 })]
    public void LevelOrderTraverse(int[] valuesToInsert, int[] expectedValues)
    {
        GenericTree<int> tree = new GenericTree<int>(valuesToInsert[0]);

        for (int i = 1; i < valuesToInsert.Length; i++)
        {
            tree.Insert(valuesToInsert[i]);
        }

        List<int> values = tree.Traverse(TreeTraversalMethod.LevelOrderTraversal);

        for (int i = 0; i < values.Count; i++)
            Assert.True(values[i] == expectedValues[i]);
    }

    [Theory]
    [InlineData(new int[] { 8, 5, 7, 2, 11, 13, 9 }, new int[] { 8, 5, 2, 7, 11, 9, 13 })]
    [InlineData(new int[] { 5 }, new int[] { 5 })]
    public void PreOrderTraverse(int[] valuesToInsert, int[] expectedValues)
    {
        GenericTree<int> tree = new GenericTree<int>(valuesToInsert[0]);

        for (int i = 1; i < valuesToInsert.Length; i++)
        {
            tree.Insert(valuesToInsert[i]);
        }

        List<int> values = tree.Traverse(TreeTraversalMethod.PreOrderTraversal);

        for (int i = 0; i < values.Count; i++)
            Assert.True(values[i] == expectedValues[i]);
    }

    [Theory]
    [InlineData(new int[] { 8, 5, 7, 2, 11, 13, 9 }, new int[] { 8, 11, 13, 9, 5, 7, 2 })]
    [InlineData(new int[] { 5 }, new int[] { 5 })]
    public void PostOrderTraverse(int[] valuesToInsert, int[] expectedValues)
    {
        GenericTree<int> tree = new GenericTree<int>(valuesToInsert[0]);

        for (int i = 1; i < valuesToInsert.Length; i++)
        {
            tree.Insert(valuesToInsert[i]);
        }

        List<int> values = tree.Traverse(TreeTraversalMethod.PostOrderTraversal);

        for (int i = 0; i < values.Count; i++)
            Assert.True(values[i] == expectedValues[i]);
    }
}