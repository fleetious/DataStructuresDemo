using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public interface IUnionFind<T>
    {
        // Returns the set that p belongs to
        int Find(T p);

        // Connects p and q — returns true if successful, false otherwise
        bool Union(T p, T q);

        // Returns true if p and q are connected, false otherwise
        bool AreConnected(T p, T q);
    }

    public class QuickFind<T> : IUnionFind<T>
    {
        private int[] Groups;
        private Dictionary<T, int> data;
        public QuickFind(T[] data)
        {
            this.data = data.ToDictionary(x => x, x => Array.IndexOf(data, x));
            Groups = new int[data.Length];
            for (int i = 0; i < Groups.Length; i++)
            {
                Groups[i] = i;
            }
        }

        public bool AreConnected(T p, T q) => p != null && q != null && Find(p) == Find(q);

        public bool Union(T p, T q)
        {
            if(p == null || q == null || AreConnected(p, q))
            {
                return false;
            }

            for (int i = 0; i < data.Count; i++)
            {
                if (Groups[i] == Find(q))
                {
                    Groups[i] = Find(p);
                }
            }

            return true;
        }

        public int Find(T p) => Groups[data[p]];
    }

    public class QuickUnion<T> : IUnionFind<T>
    {
        private int[] Parents;
        private Dictionary<T, int> data;
        public QuickUnion(T[] data)
        {
            this.data = data.ToDictionary(x => x, x => Array.IndexOf(data, x));
            Parents = new int[data.Length];
            for (int i = 0; i < Parents.Length; i++)
            {
                Parents[i] = i;
            }
        }

        public bool AreConnected(T p, T q) => p != null && q != null && Find(p) == Find(q);

        public bool Union(T p, T q)
        {
            if (p == null || q == null || AreConnected(p, q))
            {
                return false;
            }

            Parents[data[q]] = data[p];

            return true;
        }

        public int Find(T p)
        {
            if (p == null)
            {
                return -1;
            }

            int Q = data[p];
            while (Q != Parents[Q])
            {
                Q = Parents[Q];
            }

            return Q;
        }
    }

    public class UnionFind<T> : IUnionFind<T> // EVERYTHING WORKSSSSSSSSSS
    {
        private int[] Groups;
        private Dictionary<T, int> data;
        public UnionFind(T[] data)
        {
            this.data = data.ToDictionary(x => x, x => Array.IndexOf(data, x));
            Groups = new int[data.Length];
            for (int i = 0; i < Groups.Length; i++)
            {
                Groups[i] = i;
            }
        }

        public bool AreConnected(T p, T q) => p != null && q != null && Find(p) == Find(q);

        public bool Union(T p, T q)
        {
            if (p == null || q == null || AreConnected(p, q))
            {
                return false;
            }

            for (int i = 0; i < data.Count; i++)
            {
                if (Groups[i] == Find(q))
                {
                    Groups[i] = Find(p);
                }
            }

            return true;
        }

        public int Find(T p) => Groups[data[p]];
    }
}
