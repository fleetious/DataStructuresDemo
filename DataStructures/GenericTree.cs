using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// need to do (in order)
// 1. insert
// 2. remove
// 3. traversal

namespace DataStructures
{
    public class Leaf<T> where T : IComparable<T> // rename after done making the tree
    {
        public Leaf<T> Left;
        public Leaf<T> Right;

        public T Value;

        public Leaf(T value) : this(value, null, null) { }
        public Leaf(T value, Leaf<T> left, Leaf<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }

    public class GenericTree<T> where T : IComparable<T>
    {
        public Leaf<T> Root { get; private set; }

        public int Depth { get; private set; }

        public GenericTree(T value)
        {
            Root = new Leaf<T>(value);
            Depth = 1;
        }

        public

        private void Traverse(bool[] path) // not work.. as good the intend
        {
            //int pathLength = (int)Math.Ceiling(Math.Log2(path));
            Leaf<T> currentNode = Root;

            for (int i = 0; i < path.Length; i++)
                currentNode = path[i] ? currentNode.Right : currentNode.Left;
                //currentNode = (path = path & (path << (pathLength - i))) == 0 ? currentNode.Left : currentNode.Right;

            return currentNode;
        }
    }
}
