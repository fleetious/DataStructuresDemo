using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Edge<T> where T : IComparable<T>
    {
        public DirectedVertex<T> Start;
        public DirectedVertex<T> End;
        public float Cost;

        public Edge(DirectedVertex<T> start, DirectedVertex<T> end, float cost)
        {
            Start = start;
            End = end;
            Cost = cost;
        }
    }

    public class DirectedVertex<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public List<Edge<T>> Edges;

        public DirectedVertex(T value)
        {
            Value = value;
            Edges = new List<Edge<T>>();
        }
    }

    public class DirectedGraph<T> where T : IComparable<T>
    {
        public IReadOnlyList<DirectedVertex<T>> Vertices { get { return vertices; } }
        public IReadOnlyList<Edge<T>> Edges;

        private List<DirectedVertex<T>> vertices;

        public DirectedGraph()
        {
            vertices = new List<DirectedVertex<T>>();
        }

        public bool AddVertex(DirectedVertex<T> vertex)
        {
            if (Search(vertex.Value) != null)
            {
                return false;
            }

            vertices.Add(vertex);
            return true;
        }

        public bool RemoveVertex(DirectedVertex<T> vertex)
        {
            if (vertex == null)
            {
                return false;
            }

            for (int i = 0; i < vertex.Edges.Count; i++)
            {
                DirectedVertex<T> target = vertex.Edges[i].End;

                target.Edges.Remove(GetEdge(target, vertex));
            }

            return vertices.Remove(vertex);
        }

        public bool AddEdge(DirectedVertex<T> a, DirectedVertex<T> b, float distance)
        {
            if (!vertices.Contains(a) || !vertices.Contains(b))
            {
                return false;
            }

            a.Edges.Add(new Edge<T>(a, b, distance));
            b.Edges.Add(new Edge<T>(b, a, distance));

            return true;
        }

        public bool RemoveEdge(DirectedVertex<T> a, DirectedVertex<T> b)
        {
            if (!vertices.Contains(a) || !vertices.Contains(b))
            {
                return false;
            }

            Edge<T> aToB = GetEdge(a, b);
            if (aToB == null) return false;

            Edge<T> bToA = GetEdge(b, a);
            if (bToA == null) return false;

            a.Edges.Remove(aToB);
            b.Edges.Remove(bToA);

            return true;
        }

        public DirectedVertex<T> Search(T value)
        {
            if (value == null)
            {
                return null;
            }

            for (int i = 0; i < vertices.Count; i++)
            {
                if (vertices[i].Value.CompareTo(value) == 0)
                {
                    return vertices[i];
                }
            }

            return null;
        }

        public Edge<T> GetEdge(DirectedVertex<T> a, DirectedVertex<T> b)
        {
            if (!vertices.Contains(a) || !vertices.Contains(b)) return null;

            for(int i = 0; i < a.Edges.Count; i++)
            {
                if (a.Edges[i].End == b)
                {
                    return a.Edges[i];
                }
            }

            return null;
        }
    }
}

/*

void AddVertex(Vertex<T> vertex)
    // - Returns true if the addition succeeded, false otherwise
    //
    // - It should only succeed if the vertex is not null and it hasn't already been added to the graph.

bool RemoveVertex(Vertex<T> vertex)
    // - Returns true if the removal succeeded, false otherwise
    //
    // - It should only succeed if the vertex exists in your graph and you remove all edges/connections to it.

bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
    // - Returns true if the addition succeeded, false otherwise
    //
    // - It should only succeed if both vertices are not null, exist in the graph, and the edge doesn't
    //   already exist.

bool RemoveEdge(Vertex<T> a, Vertex<T> b)
    // - Returns true if the removal succeeded, false otherwise
    //
    // - It should only succeed if both vertices are not null, exist in the list, and an edge to remove exists

Vertex<T> Search(T value)
    // - Returns the vertex with the given value, or null if the vertex doesn't exist in the graph.

Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
    // - Returns the edge that connects the two given vertices, or null if the vertex doesn't exist in the graph.

*/