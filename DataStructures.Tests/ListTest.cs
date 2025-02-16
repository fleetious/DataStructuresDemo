using System;
using Xunit;
using DataStructures;

namespace DataStructures.Tests;

public class ListTest
{
    private BadList<int> CreateRandomList(int size)
    {
        BadList<int> list = new();
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            list.Add(rand.Next());
        }
        return list;
    }

    [Fact]
    public void EmptyTest()
    {
        var list = new BadList<int>();

        Assert.True(list.Count == 0);

        bool result = list.RemoveAt(2);

        Assert.False(result);
        Assert.True(list.Count == 0);
    }

    // Apparently I can't do generics in xunit :sob:
    [Theory]
    [InlineData(new int[] { 1, 2, 3 })]
    [InlineData(new int[] { 1, 2, 3, 5, 6 })]
    [InlineData(new int[] { -345, 5678, -542534, 875 })]
    public void Add(int[] nums)
    {
        var list = new BadList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            list.Add(nums[i]);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            Assert.Equal(list[i], nums[i]);
        }

        Assert.True(nums.Length == list.Count);
    }

    [Theory]
    [InlineData(7, new int[] { 1, 2, 3 })]
    public void RemoveAt(int size, int[] nums)
    {
        var list = CreateRandomList(size);

        for (int i = 0; i < nums.Length; i++)
        {
            list.RemoveAt(nums[i]);
        }

        Assert.Equal(size - nums.Length, list.Count);
    }

    [Theory]    
    [InlineData(new int[] {5, 6, 7, 8, 9, 6}, new int[] {8, 5})]
    [InlineData(new int[] { 5, 6, 7, 8, 9, 6 }, new int[] { 5 })]
    [InlineData(new int[] { 5, 6, 7, 8, 9, 6 }, new int[] { 8, 5, 9, 7 })]
    public void RemoveValue(int[] nums, int[] valuesToRemove)
    {
        var list = new BadList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            list.Add(nums[i]);
        }

        for (int i = 0; i < valuesToRemove.Length; i++)
        {
            list.RemoveValue(valuesToRemove[i]);
        }

        for(int i = 0; i < valuesToRemove.Length; i++)
        {
            Assert.False(list.Contains(valuesToRemove[i]));
        }
        Assert.Equal(nums.Length - valuesToRemove.Length, list.Count);
    }
}