using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Vertex<T> where T : IComparable<T>
    {
        public T Value { get; set; }
        public List<Vertex<T>> Edges;

        public Vertex(T value)
        {
            Value = value;
            Edges = new List<Vertex<T>>();
        }
    }

    public class Graph<T> where T : IComparable<T>
    {
        public List<Vertex<T>> Vertices { get; private set; }

        public Graph()
        {
            Vertices = new List<Vertex<T>>();
        }

        /*
        bool AddVertex(Vertex<T> vertex)
            // - Returns true if the addition succeeded, false otherwise
            //
            // - It should only succeed if the vertex is not null and it
            //   hasn't already been added to the graph.

        bool RemoveVertex(Vertex<T> vertex)
            // - Returns true if the removal succeeded, false otherwise
            //
            // - It should only succeed if the vertex exists in your graph
            //   and you remove all edges/connections to it.

        bool AddEdge(Vertex<T> a, Vertex<T> b)
            // - Returns true if the addition succeeded, false otherwise
            //
            // - It should only succeed if both vertices are not null and
            //   exist in the graph. Remember to make the connection mutual.

        bool RemoveEdge(Vertex<T> a, Vertex<T> b)
            // - Returns true if the removal succeeded, false otherwise
            //
            // - It should only succeed if both vertices are not null, exist
            //   in the list, and are each other's neighbor.

        Vertex<T> Search(T value)
            // - Returns the vertex with the given value, or null if the
            //   vertex doesn't exist in the graph.
        */

        public bool AddVertex(Vertex<T> vertex)
        {
            if(Search(vertex.Value) != null)
            {
                return false;
            }

            Vertices.Add(vertex);
            return true;
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if(vertex == null)
            {
                return false;
            }

            for(int i = 0; i < Vertices.Count; i++)
            {
                Vertices[i].Edges.Remove(vertex);
            }

            return Vertices.Remove(vertex);
        }
        
        public bool AddEdge(Vertex<T> a, Vertex<T> b)
        {
            if(a == null || b == null)
            {
                return false;
            }

            if(!Vertices.Contains(a) || !Vertices.Contains(b))
            {
                return false;
            }

            a.Edges.Add(b);
            b.Edges.Add(a);

            return true;
        }

        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            if (!Vertices.Contains(a) || !Vertices.Contains(b))
            {
                return false;
            }

            if(!a.Edges.Contains(b) || !b.Edges.Contains(a))
            {
                return false;
            }

            a.Edges.Remove(b);
            b.Edges.Remove(a);

            return true;
        }

        public Vertex<T> Search(T value)
        {
            if (value == null)
            {
                return null;
            }

            for (int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i].Value.CompareTo(value) == 0)
                {
                    return Vertices[i];
                }
            }

            return null;
        }
    }
}
