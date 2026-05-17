using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    using Xunit;

    public class UnionFindTest
    {
        [Fact]
        public void InitialState_EachNodeIsOwnParent()
        {
            var uf = new UnionFind<int>(new int[] { 0, 1, 2, 3, 4 });

            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(i, uf.Find(i));
            }
        }

        [Fact]
        public void Union_ConnectsNodes()
        {
            var uf = new UnionFind<int>(new int[] { 0, 1, 2, 3, 4 });

            uf.Union(0, 1);
            uf.Union(1, 2);

            Assert.True(uf.AreConnected(0, 2));
            Assert.False(uf.AreConnected(0, 3));
        }

        [Fact]
        public void Union_SameSet_ReturnsFalse()
        {
            var uf = new UnionFind<int>(new int[] { 0, 1, 2 });

            Assert.True(uf.Union(0, 1));
            Assert.False(uf.Union(0, 1));
        }

        [Fact]
        public void MultipleComponents_WorkCorrectly()
        {
            var uf = new UnionFind<int>(new int[] { 0, 1, 2, 3, 4, 5 });

            uf.Union(0, 1);
            uf.Union(2, 3);
            uf.Union(4, 5);

            Assert.True(uf.AreConnected(0, 1));
            Assert.True(uf.AreConnected(2, 3));
            Assert.True(uf.AreConnected(4, 5));

            Assert.False(uf.AreConnected(0, 2));
            Assert.False(uf.AreConnected(1, 5));
        }

        [Fact]
        public void PathCompression_FlattensTree()
        {
            var uf = new UnionFind<int>(new int[] { 0, 1, 2, 3 });

            uf.Union(0, 1);
            uf.Union(1, 2);

            int root1 = uf.Find(2);
            int root2 = uf.Find(0);

            Assert.Equal(root1, root2);
        }
    }
}
