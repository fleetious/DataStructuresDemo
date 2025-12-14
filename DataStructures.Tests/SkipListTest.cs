using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    public class SkipListTest
    {
        // Helper to create a basic skip.Head node since your SkipList doesn't initialize it
       

        [Fact]
        public void Insert_ShouldInsertNodeOnBaseLevel()
        {
            var skip = new SkipList<int>();  // Create an instance of SkipList
            

            skip.Insert(10);  // Use the instance to insert

            var inserted = skip.Search(10);  // Use the instance to search
            Assert.NotNull(inserted);
            Assert.Equal(10, inserted.Value);
            Assert.Equal(inserted, skip.Head.Next);
        }

        [Fact]
        public void Insert_TwoValues_ShouldLinkInOrder()
        {
            var skip = new SkipList<int>();  // Create an instance of SkipList
            

             skip.Insert(5);  // Use the instance to insert
             skip.Insert(10);  // Use the instance to insert

            Assert.Equal(5, skip.Head.Next.Value);
            Assert.Equal(10, skip.Head.Next.Next.Value);
        }

        [Fact]
        public void Insert_Duplicate_ShouldThrow()
        {
            var skip = new SkipList<int>();  // Create an instance of SkipList
            skip.Insert(5);  // Use the instance to insert

            Assert.Throws<Exception>(() => skip.Insert(5));  // Use the instance to insert
        }

        [Fact]
        public void Remove_ShouldRemoveNode()
        {
            var skip = new SkipList<int>();  // Create an instance of SkipList
           

             skip.Insert(5);  // Use the instance to insert
             skip.Insert(10);  // Use the instance to insert

            var removed = skip.Remove(5);  // Use the instance to remove

            Assert.Equal(true,removed);
            Assert.Equal(10, skip.Head.Next.Value);
        }

        [Fact]
        public void Remove_NonExisting_ShouldThrow()
        {
            var skip = new SkipList<int>();  // Create an instance of SkipList
            skip.Insert(5);  // Use the instance to insert

            Assert.Throws<Exception>(() => skip.Remove(99));  // Use the instance to remove
        }
    }
}
