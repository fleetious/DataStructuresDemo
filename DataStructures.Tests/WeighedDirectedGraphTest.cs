using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Tests
{
    public class DirectedGraphTest
    {
        [Fact]
        public void AddVertex()
        {
            DirectedGraph<int> graph = new DirectedGraph<int>();

            graph.AddVertex(new DirectedVertex<int>(5));
            Assert.True(graph.AddVertex(new DirectedVertex<int>(8)));
            Assert.True(graph.Search(5) != null);
            Assert.True(graph.Search(8) != null);
        }

        [Fact]
        public void AddVertexInDirectedGraph()
        {
            DirectedGraph<int> graph = new DirectedGraph<int>();

            graph.AddVertex(new DirectedVertex<int>(5));
            Assert.False(graph.AddVertex(new DirectedVertex<int>(5)));
            Assert.True(graph.Search(5) != null);
        }

        [Theory]
        [InlineData(7, true, 5, 7, 2, 8)]
        [InlineData(4, false, 5, 7, 2, 8)]
        public void RemoveVertex(int toRemove, bool expected, params int[] v)
        {
            DirectedGraph<int> graph = new DirectedGraph<int>();

            for (int i = 0; i < v.Length; i++)
            {
                graph.AddVertex(new DirectedVertex<int>(v[i]));
            }

            Assert.True(graph.RemoveVertex(graph.Search(toRemove)) == expected);

            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == toRemove)
                {
                    Assert.True(graph.Search(v[i]) == null);
                    continue;
                }

                Assert.True(graph.Search(v[i]) != null);
            }
        }

        [Theory]
        [InlineData(7, true, 5, 7, 2, 8)]
        [InlineData(4, false, 5, 7, 2, 8)]
        public void RemoveVertexWithEdge(int toRemove, bool expected, params int[] v)
        {
            DirectedGraph<int> graph = new DirectedGraph<int>();

            for (int i = 0; i < v.Length; i++)
            {
                graph.AddVertex(new DirectedVertex<int>(v[i]));
                graph.AddEdge(graph.Vertices[0], graph.Vertices[i], 1);
            }

            Assert.True(graph.RemoveVertex(graph.Search(toRemove)) == expected);

            for (int i = 0; i < v.Length; i++)
            {
                if (v[i] == toRemove)
                {
                    Assert.True(graph.Search(v[i]) == null);
                    continue;
                }
                DirectedVertex<int> ver = graph.Search(v[i]);
                Assert.True(ver != null);

                for (int j = 0; j < ver.Edges.Count; j++)
                {
                    Assert.True(ver.Edges[j].End.Value != toRemove);
                }
            }
        }

        [Fact]
        public void RemoveEdge()
        {
            DirectedGraph<int> graph = new DirectedGraph<int>();

            graph.AddVertex(new DirectedVertex<int>(5));
            graph.AddVertex(new DirectedVertex<int>(8));

            graph.AddEdge(graph.Vertices[0], graph.Vertices[1], 1);

            Assert.True(graph.RemoveEdge(graph.Vertices[0], graph.Vertices[1]));

            Assert.True(graph.Vertices[0].Edges.Count == 0);
            Assert.True(graph.Vertices[1].Edges.Count == 0);
        }

        [Fact]
        public void RemoveEdgeNotInDirectedGraph()
        {
            DirectedGraph<int> graph = new DirectedGraph<int>();

            graph.AddVertex(new DirectedVertex<int>(5));
            graph.AddVertex(new DirectedVertex<int>(8));

            graph.AddEdge(graph.Vertices[0], graph.Vertices[1], 1);

            Assert.False(graph.RemoveEdge(graph.Vertices[0], new DirectedVertex<int>(8)));

            Assert.True(graph.Vertices[0].Edges[0].Start == graph.Vertices[0]);
            Assert.True(graph.Vertices[0].Edges[0].End == graph.Vertices[1]);
            Assert.True(graph.Vertices[1].Edges[0].Start == graph.Vertices[1]);
            Assert.True(graph.Vertices[1].Edges[0].End == graph.Vertices[0]);
        }

        [Fact]
        public void AddEdge()
        {
            DirectedGraph<int> graph = new DirectedGraph<int>();

            graph.AddVertex(new DirectedVertex<int>(5));
            graph.AddVertex(new DirectedVertex<int>(8));

            Assert.True(graph.AddEdge(graph.Vertices[0], graph.Vertices[1], 1));

            Assert.True(graph.Vertices[0].Edges[0].Start == graph.Vertices[0]);
            Assert.True(graph.Vertices[0].Edges[0].End == graph.Vertices[1]);
            Assert.True(graph.Vertices[1].Edges[0].Start == graph.Vertices[1]);
            Assert.True(graph.Vertices[1].Edges[0].End == graph.Vertices[0]);
        }

        [Fact]
        public void AddEdgeNotInDirectedGraph()
        {
            DirectedGraph<int> graph = new DirectedGraph<int>();

            graph.AddVertex(new DirectedVertex<int>(5));

            Assert.False(graph.AddEdge(graph.Vertices[0], new DirectedVertex<int>(8), 1));

            Assert.True(graph.Vertices[0].Edges.Count == 0);
        }
    }
}
