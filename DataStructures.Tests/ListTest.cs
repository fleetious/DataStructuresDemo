using System;
using Xunit;
using DataStructures;

namespace DataStructures.Tests;

public class ListTest
{
    private GenericList<int> CreateRandomList(int size)
    {
        GenericList<int> list = new();
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
        var list = new GenericList<int>();

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
        var list = new GenericList<int>();

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
    [InlineData(new int[] {5, 6, 7, 8, 9, 6}, new int[] {8, 5}, new int[] { 6, 7, 9, 6 })]
    [InlineData(new int[] { 5, 6, 7, 8, 9, 6 }, new int[] { 5 }, new int[] { 6, 7, 8, 9, 6 })]
    [InlineData(new int[] { 5, 6, 7, 8, 9, 6 }, new int[] { 8, 5, 9, 7 }, new int[] { 6, 6 })]
    [InlineData(new int[] { 654, 765, 987, 124, 87689, 98709 }, new int[] { 8, 5, 9, 7 }, new int[] { 654, 765, 987, 124, 87689, 98709 })]
    [InlineData(new int[] { 1 }, new int[] { 1, 2, 3 }, new int[] { })]
    public void RemoveValue(int[] nums, int[] valuesToRemove, int[] resultArray)
    {
        var list = new GenericList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            list.Add(nums[i]);
        }

        for (int i = 0; i < valuesToRemove.Length; i++)
        {
            list.RemoveValue(valuesToRemove[i]);
        }

        for (int i = 0; i < list.Count; i++)
        {
            Assert.True(list[i] == resultArray[i]);
        }
    }

    [Theory] // TODO: UNITTTTT TESTTTTT
    [InlineData(new int[] { 5, 6, 7, 8, 9, 6 }, 3, new int[] { 8, 5 }, new int[] { 6, 7, 9, 6 })]
    [InlineData(new int[] { 5, 6, 7, 8, 9, 6 }, 3, new int[] { 5 }, new int[] { 6, 7, 8, 9, 6 })]
    public void Insert(int[] nums, int[] valuesToInsert, int[] resultArray)
    {
        var list = new GenericList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            list.Add(nums[i]);
        }

        for (int i = 0; i < valuesToInsert.Length; i++)
        {
            list.Insert(valuesToInsert[i], (new Random()).Next(0, 5));
        }

        for (int i = 0; i < list.Count; i++)
        {
            Assert.True(list[i] == resultArray[i]);
        }
    }

    //[Theory]
    //[InlineData(new int[] { 5, 6, 7, 8, 9 }, 0, new int[] { 6, 7, 8, 9 })]
    //[InlineData(new int[] { 5, 6, 7, 8, 9 }, 1, new int[] { 5, 7, 8, 9 })]
    //[InlineData(new int[] { 4, 7, 8, 21, 7658, 876887 }, 4, new int[] { 4, 7, 8, 21, 7658 })]
    //[InlineData(new int[] { 765, 8765, 43, 12, -5 }, 2, new int[] { 765, 8765, 12, -5 })]
    //public void MoveDownArray(int[] nums, int startIndex, int[] resultArray)
    //{
    //    var list = new BadList<int>();

    //    for (int i = 0; i < nums.Length; i++)
    //    {
    //        list.Add(nums[i]);
    //    }

    //    list.MoveDownArray(startIndex, list.Count, 1);

    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        Assert.True(list[i] == resultArray[i]);
    //    }
    //}
}