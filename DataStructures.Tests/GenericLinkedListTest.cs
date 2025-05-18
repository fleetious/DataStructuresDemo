namespace DataStructures.Tests;

public class GenericLinkedListTest
{
    [Theory]
    [InlineData(new int[] { 1, 2, 3 })]
    [InlineData(new int[] { 1, 2, 3, 5, 6 })]
    [InlineData(new int[] { -345, 5678, -542534, 875 })]
    public void Add(int[] nums)
    {
        var list = new GenericLinkedList<int>();

        for (int i = 0; i < nums.Length; i++)
        {
            list.AddLast(nums[i]);
        }

        LinkedListNode<int> currentNode = list.Head;
        for (int i = 0; i < nums.Length; i++)
        {
            Assert.Equal(currentNode.Value, nums[i]);
            currentNode = currentNode.Next;
        }

        Assert.True(nums.Length == list.Count);
    }
}