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
        public class Node<T> // rename to BinarySearchTreeLeaf or smth after making tree
        {
            public Node<T> Left;
            public Node<T> Right;

            public int Height;
            public int Balance;

            public T Value;

            public Node(T value) : this(value, null, null) { }
            public Node(T value, Node<T> left, Node<T> right)
            {
                Value = value;
                Left = left;
                Right = right;
            }
        }

        public Node<T> Root;

        public AVLTree() : this(null) { }

        public AVLTree(Node<T> root)
        {
            Root = root;
        }

        public void Insert(T value)
        {
            Root = RecursiveInsert(value, Root);
        }

        // yoo what if we just use search to find the node and then in remove we handle the childrenn nuh uh
        public Node<T> Remove(T value)
        {
            Node<T> node = RecursiveSearch(value, Root);
            Node<T> parent = node; if (node == null) throw new InvalidOperationException("Value not found in tree"); // ily chatgpt

            Node<T> leftChild = node.Left; Node<T> rightChild = node.Right;


            node = null;
            if (leftChild != null)
                Insert(leftChild.Value); if (rightChild != null)
            {
                Insert(rightChild.Value);


            }

            return parent;
        }

        public bool Contains(T value) => Search(value) != null;

        public Node<T> Search(T value) => RecursiveSearch(value, Root);

        private static Node<T> RecursiveInsert(T value, Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return new Node<T>(value);
            }
            if (currentNode.Value.CompareTo(value) < 0)
            {
                Node<T> temp = RecursiveInsert(value, currentNode.Right);
                currentNode.Right = temp;
            }
            else
            {
                Node<T> temp = RecursiveInsert(value, currentNode.Left);
                currentNode.Left = temp;
            }
            //add rotations here
            return currentNode;
        }

        private static Node<T> RecursiveRemove(T value, Node<T> currentNode)
        {
            if (currentNode == null) return null;

            if (currentNode.Value.CompareTo(value) == 0)
            {
                currentNode = Remove(currentNode);
                return currentNode;
            }
            else if (currentNode.Value.CompareTo(value) < 0)
            {
                currentNode.Right = RecursiveRemove(value, currentNode.Right);
            }
            else
            {
                currentNode.Left = RecursiveRemove(value, currentNode.Left);
            }

            return currentNode;

            // this is wrong lmao it made much more sense in my head at 2 am lmao actually i think it was just incomplete but idk how to finish it lmao lol
            //if (currentNode == null) return null;

            //if (currentNode.Value.CompareTo(value) == 0) return currentNode = null;
            //if (currentNode.Value.CompareTo(value) < 0)
            //{
            //    return RecursiveSearch(value, currentNode.Right);
            //}
            //else
            //{
            //    return RecursiveSearch(value, currentNode.Left);
            //}
        }
        static Node<T> Remove(Node<T> node)
        {
            
        }
        // think of this similar to insert, go down tree and find the node ykyk
        private Node<T> RecursiveSearch(T value, Node<T> currentNode)
        {
            if (currentNode == null) return null;

            if (currentNode.Value.CompareTo(value) == 0) return currentNode;
            if (currentNode.Value.CompareTo(value) < 0)
            {
                return RecursiveSearch(value, currentNode.Right);
            }
            else
            {
                return RecursiveSearch(value, currentNode.Left);
            }
        }
        // tex said u dont have to do level order traversal so imma not do it !!
        private T[] RecursiveTraversal(Node<T> node) // params are TBD
        {
            throw new NotImplementedException();
        }
    }
}
