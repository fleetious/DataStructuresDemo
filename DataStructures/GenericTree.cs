using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

// need to do (in order)
// 1. insert
// 2. remove
// 3. Traverse

namespace DataStructures
{
    public enum TreeTraversalMethod
    {
        InOrderTraversal,
        LevelOrderTraversal,
        PreOrderTraversal,
        PostOrderTraversal
    }

    public class BSTNode<T> // rename to BinarySearchTreeLeaf or smth after making tree
    {
        public BSTNode<T> Left;
        public BSTNode<T> Right;

        public T Value;

        public BSTNode(T value) : this(value, null, null) { }
        public BSTNode(T value, BSTNode<T> left, BSTNode<T> right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }

    public class GenericTree<T> where T : IComparable<T>
    {
        public BSTNode<T> Root { get; private set; }

        public int Depth { get; private set; }

        public GenericTree(T value)
        {
            Root = new BSTNode<T>(value);
            Depth = 1;
        }


        public void Insert(T value)
        {
            BSTNode<T> currentLeaf = Root;
            int currentDepth = 1;
            while (true)
            {
                int compareValue = currentLeaf.Value.CompareTo(value);

                if (compareValue == 0) throw new Exception("bro u cant do this");

                if (compareValue < 0)
                {
                    if (currentLeaf.Right == null)
                    {
                        currentLeaf.Right = new BSTNode<T>(value);
                        break;
                    }

                    currentLeaf = currentLeaf.Right;
                }
                else // at this point compareTo has evaluated to less than 0
                {
                    if (currentLeaf.Left == null)
                    {
                        currentLeaf.Left = new BSTNode<T>(value);
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
            BSTNode<T> currentLeaf = Root;

            if (currentLeaf.Value.CompareTo(value) == 0 && Depth == 1)
                throw new InvalidOperationException("cant make the tree epmty bro r u srs rn hy would u even want to do ts");

            while (true)
            {
                int valueCompare = currentLeaf.Value.CompareTo(value);

                if (currentLeaf.Right != null && currentLeaf.Right.Value.CompareTo(value) == 0)
                {
                    while (HasChildren(currentLeaf.Right) && currentLeaf.Right != null)
                    {
                        currentLeaf = currentLeaf.Right;
                        currentLeaf.Value = FindNewBranch(currentLeaf).Value;
                    }
                    return true;
                }
                else if (currentLeaf.Left != null && currentLeaf.Left.Value.CompareTo(value) == 0)
                {
                    while(HasChildren(currentLeaf.Left) && currentLeaf.Left != null)
                    {
                        currentLeaf = currentLeaf.Left;
                        currentLeaf.Value = FindNewBranch(currentLeaf).Value;
                    }
                    
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

        private bool HasChildren(BSTNode<T> node)
        {
            return node.Left != null || node.Right != null;
        }

        private BSTNode<T> FindNewBranch(BSTNode<T> branch)
        {
            BSTNode<T> currentLeaf = branch;
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
        // TODO: fix search bruo
        public BSTNode<T> Search(T value)
        {
            BSTNode<T> currentLeaf = Root;

            if(currentLeaf.Value.CompareTo(value) == 0)
            {
                return Root;
            }

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
                else if (valueCompare >= 0)
                    currentLeaf = currentLeaf.Right;
                else if (valueCompare < 0)
                    currentLeaf = currentLeaf.Left;
                else
                    return null;
            }
        }
        // Method 1: in order
        // Method 2: level order
        // Method 3: pre order
        // Method 4: post order
        public List<T> Traverse(TreeTraversalMethod traverse_method)
        {
            switch(traverse_method)
            {
                case TreeTraversalMethod.InOrderTraversal: return InOrderTraverse();
                case TreeTraversalMethod.LevelOrderTraversal: return LevelOrderTraverse();
                case TreeTraversalMethod.PreOrderTraversal: return PreOrderRecursive();
                case TreeTraversalMethod.PostOrderTraversal: return PostOrderTraverse();
                default: throw new ArgumentOutOfRangeException("traverse_method");
            }
        }

        private List<T> InOrderTraverse()
        {
            if (Root == null) return new List<T>();

            Stack<BSTNode<T>> path = new();
            HashSet<BSTNode<T>> visited = new();
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
            Queue<BSTNode<T>> visited = new();
            Queue<BSTNode<T>> toVisit = new();

            toVisit.Enqueue(Root);

            while (toVisit.Count > 0)
            {
                BSTNode<T> currentlyVisiting = toVisit.Peek();
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
            Stack<BSTNode<T>> toVisit = new();

            toVisit.Push(Root);
            values.Add(Root.Value);

            while(toVisit.Count > 0)
            {
                BSTNode<T> currentlyVisiting = toVisit.Peek();
                // fix this dumb formatting plzz!!
                if(currentlyVisiting.Left != null && !values.Contains(currentlyVisiting.Left.Value))
                {
                    toVisit.Push(currentlyVisiting.Left);
                    values.Add(currentlyVisiting.Left.Value);
                }
                if(currentlyVisiting.Right != null && !values.Contains(currentlyVisiting.Right.Value))
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

        public List<T> PreOrderRecursive() => PreOrderTraverseRecursion(Root);

        private List<T> PreOrderTraverseRecursion(BSTNode<T> curr)
        {
            if (Root == null) return new List<T>();

            List<T> values = [];

            values.Add(curr.Value);

            if (curr.Left != null)
            {
                values.AddRange(PreOrderTraverseRecursion(curr.Left));
            }
            if (curr.Right != null)
            {
                values.AddRange(PreOrderTraverseRecursion(curr.Right));
            }

            return values;
        }

        private List<T> PostOrderTraverse()
        {
            if (Root == null) return new List<T>();

            List<T> values = new();
            Stack<BSTNode<T>> toVisit = new();

            toVisit.Push(Root);
            values.Add(Root.Value);

            while (toVisit.Count > 0)
            {
                BSTNode<T> currentlyVisiting = toVisit.Peek();
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
