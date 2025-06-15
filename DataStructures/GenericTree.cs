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
    public class Leaf<T> // rename after done making the tree
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

        public void Insert(T value)
        {
            Leaf<T> currentLeaf = Root;
            int currentDepth = 1;
            while(true)
            {
                int compareValue = currentLeaf.Value.CompareTo(value);

                if (compareValue == 0) throw new Exception("bro u cant do this");

                if(compareValue < 0)
                {
                    if(currentLeaf.Right == null)
                    {
                        currentLeaf.Right = new Leaf<T>(value);
                        break;
                    }

                    currentLeaf = currentLeaf.Right;
                }
                else // at this point compareTo has evaluated to less than 0
                {
                    if(currentLeaf.Left == null)
                    {
                        currentLeaf.Left = new Leaf<T>(value);
                        break;
                    }

                    currentLeaf = currentLeaf.Left;
                }

                currentDepth++;
            }
            // node has already been added here
            if (currentDepth == Depth) Depth++;
        }

        public bool Remove(T value)
        {
            Leaf<T> currentLeaf = Root;
            while (true)
            {
                int valueCompare = currentLeaf.Value.CompareTo(value);

                if (currentLeaf.Right != null && currentLeaf.Right.Value.CompareTo(value) == 0)
                {
                    currentLeaf.Right = null;
                    return true;
                }
                else if (currentLeaf.Left != null && currentLeaf.Left.Value.CompareTo(value) == 0)
                {
                    currentLeaf.Left = null;
                    return true;
                }
                else if (valueCompare >= 0 && currentLeaf.Right != null)
                    currentLeaf = currentLeaf.Right;
                else if (valueCompare < 0 && currentLeaf.Left != null)
                    currentLeaf = currentLeaf.Left;
                else
                    return false;
            }
        }

        public bool Contains(T value)
            => Search(value) != null;

        public Leaf<T> Search(T value)
        {
            Leaf<T> currentLeaf = Root;
            while (true)
            {
                int valueCompare = currentLeaf.Value.CompareTo(value);

                if (currentLeaf.Right != null && currentLeaf.Right.Value.CompareTo(value) == 0)
                {
                    return currentLeaf.Right;
                }
                else if (currentLeaf.Left != null && currentLeaf.Left.Value.CompareTo(value) == 0)
                {
                    return currentLeaf.Left;
                }
                else if (valueCompare >= 0 && currentLeaf.Right != null)
                    currentLeaf = currentLeaf.Right;
                else if (valueCompare < 0 && currentLeaf.Left != null)
                    currentLeaf = currentLeaf.Left;
                else
                    return null;
            }
        }

        public List<T> Traverse()
        { // TESTS NOT DONE YET
            LinkedList<Leaf<T>> path = new();
            HashSet<Leaf<T>> visited = new();
            List<T> values = new();
            path.AddLast(Root);
            while(path.Count != 0)
            {
                visited.Add(path.First.Value);
                if(path.First.Value.Left != null && !visited.Contains(path.First.Value.Left))
                {
                    path.AddFirst(path.First.Value.Left);
                    continue;
                }
                if(path.First.Value.Right != null && !visited.Contains(path.First.Value.Right))
                {
                    path.AddFirst(path.First.Value.Right);
                    continue;
                }
                // for future reference: path.First.Value is the leaf, not the value
                values.Add(path.First.Value.Value);
                path.RemoveFirst();
            }
            
            return values;
        }
    }
}
