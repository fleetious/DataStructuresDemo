using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    public class SkipListTest // i chatgpt test becaues 
    {
        [Theory]
        [InlineData(5)]
        [InlineData(5, 10)]
        [InlineData(5, 10, 15)]
        [InlineData(5, 10, 15, 20)]
        [InlineData(5, 10, 15, 20, 25)]
        [InlineData(5, 10, 15, 20, 25, 30)]
        [InlineData(5, 10, 15, 20, 25, 35, 40)]
        [InlineData(5, 10, 15, 20, 25, 35, 40, 45)]
        [InlineData(5, 10, 15, 20, 25, 35, 40, 45, 50)]
        public void Insert_Values_ShouldLinkInOrder(params int[] values)
        {
            for (int i = 0; i < 1e+4; i++)
            {
                var skip = new SkipList<int>();  // Create an instance of SkipList

                for(int j = 0; j < values.Length; j++)
                {
                    skip.Insert(values[j]);  // Use the instance to insert :sob: brooooo
                }

                SkipListNode<int> currentNode = skip.Head;
                for (int j = 0; j < values.Length; j++)
                {
                    currentNode = currentNode.Next;
                    Assert.Equal(values[j], currentNode.Value);
                }
            }
        }

        [Fact]
        public void Insert_Duplicate_ShouldThrow()
        {
            var skip = new SkipList<int>();  // Create an instance of SkipList
            skip.Insert(5);  // Use the instance to insert

            Assert.Throws<Exception>(() => skip.Insert(5));  // Use the instance to insert
        }

        [Theory]
        [InlineData(5)]
        [InlineData(5, 10)]
        [InlineData(5, 10, 15)]
        [InlineData(5, 10, 15, 20)]
        [InlineData(5, 10, 15, 20, 25)]
        [InlineData(5, 10, 15, 20, 25, 30)]
        [InlineData(5, 10, 15, 20, 25, 35, 40)]
        [InlineData(5, 10, 15, 20, 25, 35, 40, 45)]
        [InlineData(5, 10, 15, 20, 25, 35, 40, 45, 50)]
        public void Remove_ShouldRemoveNode(params int[] values)
        {
            for (int i = 0; i < 1e+4; i++)
            {
                var skip = new SkipList<int>();  // Create an instance of SkipList

                for (int j = 0; j < values.Length; j++)
                {
                    skip.Insert(values[j]);  // Use the instance to insert :sob: brooooo
                }

                int indexToRemove = new Random().Next(0, values.Length);
                skip.Remove(values[indexToRemove]);

                if(indexToRemove > 0 && indexToRemove < values.Length - 1)
                {
                    Assert.Equal(skip.Search(values[indexToRemove - 1]).Next, skip.Search(values[indexToRemove + 1]));
                }
            }
        }

        [Fact]
        public void Remove_NonExisting_ShouldThrow()
        {
            var skip = new SkipList<int>();  // Create an instance of SkipList
            skip.Insert(5);  // Use the instance to insert

            Assert.False(skip.Remove(99));  // Use the instance to remove
        }
    }
}
