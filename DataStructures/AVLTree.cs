using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    //public void Insert(T value)
    //{
    //    RecursiveInsert(value, Root);
    //}
    //private void RecursiveInsert(T value, BSTNode<T> node)
    //{
    //    if (node == null)
    //    {
    //        node = new BSTNode<T>(value);
    //        return;
    //    }

    //    if (node.Value.CompareTo(value) < 0)
    //    {
    //        RecursiveInsert(value, node.Right);
    //    }
    //    else
    //    {
    //        RecursiveInsert(value, node.Left);
    //    }
    //}

    public class AVLTree<T> where T : IComparable<T>
    {
        public class Node // rename to BinarySearchTreeLeaf or smth after making tree
        {
            public Node Left;
            public Node Right;

            public int Height;
            public int Balance;

            public T Value;

            public Node(T value) : this(value, null, null) { }
            public Node(T value, Node left, Node right)
            {
                Value = value;
                Left = left;
                Right = right;
            }
        }

        public Node Root;

        public AVLTree() : this(null) { }

        public AVLTree(Node root)
        {
            Root = root;
        }

        public void Insert(T value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                return;
            }

            RecursiveInsert(value, Root);
        }

        // yoo what if we just use search to find the node and then in remove we handle the childrenn
        public Node Remove(T value)
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value) => Search(value) != null;

        public Node Search(T value) => RecursiveSearch(value, Root);

        private Node RecursiveInsert(T value, Node currentNode)
        {
            if (currentNode.Value.CompareTo(value) < 0 && currentNode.Right != null)
            {
                return RecursiveInsert(value, currentNode.Right);
            }
            else if (currentNode.Left != null)
            {
                return RecursiveInsert(value, currentNode.Left);
            }

            if (currentNode.Value.CompareTo(value) < 0)
            {
                currentNode.Right = new Node(value);
            }
            else
            {
                currentNode.Left = new Node(value);
            }

            return currentNode;
        }

        // think of this similar to insert, go down tree and find the node ykyk
        private Node RecursiveSearch(T value, Node currentNode)
        {
            throw new NotImplementedException();
        }

        private T[] RecursiveTraversal() // params are TBD
        {
            throw new NotImplementedException();
        }
    }
}
