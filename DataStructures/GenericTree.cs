using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

// need to do (in order)
// 1. insert
// 2. remove
// 3. Traverse

namespace DataStructures
{
    public class Leaf<T> // rename to BinarySearchTreeLeaf or smth after making tree
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

            if (currentLeaf.Value.CompareTo(value) == 0)
                currentLeaf = FindNewBranch(currentLeaf);

            while (true)
            {
                int valueCompare = currentLeaf.Value.CompareTo(value);

                if (currentLeaf.Right != null && currentLeaf.Right.Value.CompareTo(value) == 0)
                {
                    currentLeaf.Right.Value = FindNewBranch(currentLeaf.Right).Value;
                    return true;
                }
                else if (currentLeaf.Left != null && currentLeaf.Left.Value.CompareTo(value) == 0)
                {
                    currentLeaf.Left.Value = FindNewBranch(currentLeaf.Left).Value;
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

        private Leaf<T> FindNewBranch(Leaf<T> branch)
        {
            Leaf<T> currentLeaf = branch;
            if(branch.Left != null)
            {
                while(currentLeaf.Right != null)
                    currentLeaf = currentLeaf.Right;
            }
            else if (branch.Right != null)
            {
                while (currentLeaf.Left != null)
                    currentLeaf = currentLeaf.Left;
            }
            else
            {
                return null;
            }

            return currentLeaf;
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
        // Method 1: in order
        // Method 2: level order
        // Method 3: pre order
        // Method 4: post order
        public List<T> Traverse(int traverse_method = 1)
        {
            switch(traverse_method)
            {
                case 1: return InOrderTraverse();
                case 2: return LevelOrderTraverse();
                case 3: return PreOrderTraverse();
                case 4: return PostOrderTraverse();
                default: throw new ArgumentOutOfRangeException("traverse_method");
            }
        }

        private List<T> InOrderTraverse()
        {
            if (Root == null) return new List<T>();

            Stack<Leaf<T>> path = new();
            HashSet<Leaf<T>> visited = new();
            List<T> values = new();
            path.Push(Root);
            while (path.Count != 0)
            {
                if (path.Peek().Left != null && !visited.Contains(path.Peek().Left))
                {
                    path.Push(path.Peek().Left);
                    continue;
                }
                if (path.Peek().Right != null && !visited.Contains(path.Peek().Right))
                {
                    values.Add(path.Peek().Value); // adds parent
                    visited.Add(path.Peek());
                    path.Push(path.Peek().Right);
                    continue;
                }

                // for future reference: path.Peek() is the leaf, not the value
                values.Add(path.Peek().Value);
                visited.Add(path.Peek());

                while (path.Count != 0 && visited.Contains(path.Peek()))
                {
                    path.Pop();
                }
            }

            return values;
        }

        private List<T> LevelOrderTraverse()
        {
            if (Root == null) return new List<T>();

            List<T> values = new();
            Queue<Leaf<T>> visited = new();
            Queue<Leaf<T>> toVisit = new();

            toVisit.Enqueue(Root);

            while (toVisit.Count > 0)
            {
                Leaf<T> currentlyVisiting = toVisit.Peek();
                // handle visitor values
                if (currentlyVisiting.Left != null)
                    toVisit.Enqueue(currentlyVisiting.Left);
                if (currentlyVisiting.Right != null)
                    toVisit.Enqueue(currentlyVisiting.Right);
                values.Add(currentlyVisiting.Value);

                visited.Enqueue(toVisit.Dequeue());
            }

            return values;
        }
        
        private List<T> PreOrderTraverse()
        {
            if (Root == null) return new List<T>();
            
            List<T> values = new();
            Stack<Leaf<T>> toVisit = new();

            toVisit.Push(Root);
            values.Add(Root.Value);

            while(toVisit.Count > 0)
            {
                Leaf<T> currentlyVisiting = toVisit.Peek();
                // fix this dumb formatting plzz!!
                if(currentlyVisiting.Left != null && !values.Contains(currentlyVisiting.Left.Value))
                {
                    toVisit.Push(currentlyVisiting.Left);
                    values.Add(currentlyVisiting.Left.Value);
                }
                else if(currentlyVisiting.Right != null && !values.Contains(currentlyVisiting.Right.Value))
                {
                    toVisit.Push(currentlyVisiting.Right);
                    values.Add(currentlyVisiting.Right.Value);
                }
                else
                {
                    toVisit.Pop();
                }
            }
            
            return values;
        }

        private List<T> PostOrderTraverse()
        {
            if (Root == null) return new List<T>();

            List<T> values = new();
            Stack<Leaf<T>> toVisit = new();

            toVisit.Push(Root);
            values.Add(Root.Value);

            while (toVisit.Count > 0)
            {
                Leaf<T> currentlyVisiting = toVisit.Peek();
                // fix this dumb formatting plzz!!
                if (currentlyVisiting.Right != null && !values.Contains(currentlyVisiting.Right.Value))
                {
                    toVisit.Push(currentlyVisiting.Right);
                    values.Add(currentlyVisiting.Right.Value);
                }
                else if (currentlyVisiting.Left != null && !values.Contains(currentlyVisiting.Left.Value))
                {
                    toVisit.Push(currentlyVisiting.Left);
                    values.Add(currentlyVisiting.Left.Value);
                }
                else
                {
                    toVisit.Pop();
                }
            }

            return values;
        }
    }
}
