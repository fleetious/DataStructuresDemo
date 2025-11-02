using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
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

            public int Height = 1;
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
            return RecursiveRemove(value, Root);
        }

        public T[] Traverse()
        {
            return RecursiveTraversal(Root);
        }

        public bool Contains(T value) => Search(value) != null;

        public Node<T> Search(T value) => RecursiveSearch(value, Root);

        private Node<T> RecursiveInsert(T value, Node<T> currentNode)
        {
            if (currentNode == null)
            {
                return new Node<T>(value);
            }
            if (currentNode.Value.CompareTo(value) < 0)
            {
                Node<T> temp = RecursiveInsert(value, currentNode.Right);
                currentNode.Right = temp;

                BubbleUpHeight(currentNode.Right);
            }
            else
            {
                Node<T> temp = RecursiveInsert(value, currentNode.Left);
                currentNode.Left = temp;

                BubbleUpHeight(currentNode.Left);
            }
            //add rotations here
            return currentNode;
        }

        private static Node<T> RecursiveRemove(T value, Node<T> currentNode)
        {
            if (currentNode == null) return null;

            if (currentNode.Value.CompareTo(value) == 0)
            {
                currentNode = RemoveNode(currentNode);
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

        private void BubbleUpHeight(Node<T> startNode)
        {
            BubbleUpHeight(startNode, Root);
        }

        // essentially just copy pasted from search lmao
        private static Node<T> BubbleUpHeight(Node<T> startNode, Node<T> currentNode) // startNode is the node we started from to bubble up, currentNode shouuld ALWAYS be Root at first call
        {
            if (currentNode == null) return null;

            if (currentNode.Value.CompareTo(startNode.Value) == 0) return currentNode;
            if (currentNode.Value.CompareTo(startNode.Value) < 0)
            {
                currentNode.Height = GetMaxHeight(currentNode.Left, currentNode.Right) + 1;
                // w chatgpt oneliner
                currentNode.Balance = (currentNode.Left != null ? currentNode.Left.Height : 0) - (currentNode.Right != null ? currentNode.Right.Height : 0);

                if(Math.Abs(currentNode.Balance) > 1)
                {
                    currentNode = RotateWrapper(currentNode);
                }

                return BubbleUpHeight(startNode, currentNode.Right);
            }
            else
            {
                currentNode.Height = GetMaxHeight(currentNode.Left, currentNode.Right) + 1;
                currentNode.Balance = (currentNode.Left != null ? currentNode.Left.Height : 0) - (currentNode.Right != null ? currentNode.Right.Height : 0);

                if (Math.Abs(currentNode.Balance) > 1)
                {
                    currentNode = RotateWrapper(currentNode);
                }

                return BubbleUpHeight(startNode, currentNode.Left);
            }
        }

        private static Node<T> RotateWrapper(Node<T> currentNode)
        {
            if(currentNode.Balance < 0)
            {
               return LeftRotate(currentNode);
            }
            else // already checked if tree is unbalanced earlier
            {
                return RightRotate(currentNode);
            }
        }

        private static Node<T> RightRotate(Node<T> unbalancedNode)
        {
            Node<T> newRoot = unbalancedNode.Left;
            unbalancedNode.Left = newRoot.Right;
            newRoot.Right = unbalancedNode;

            return newRoot;
        }

        private static Node<T> LeftRotate(Node<T> unbalancedNode)
        {
            Node<T> newRoot = unbalancedNode.Right;
            unbalancedNode.Right = newRoot.Left;
            newRoot.Left = unbalancedNode;

            return newRoot;
        }

        private static int GetMaxHeight(Node<T> left, Node<T> right)
        {
            //if (left == null && right == null) return 1; bandaid fix
            if(left == null) return right.Height;
            if(right == null) return left.Height;

            return Math.Max(left.Height, right.Height);
        }
        private static Node<T> RemoveNode(Node<T> node)
        {
            if (node == null) return null;

            if(node.Right != null)
            {
                return node.Right;
            }
            else if (node.Left != null)
            {
                return node.Left;
            }

            return null;
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
            return RecursivePreOrderTraverse(node);
        }

        private T[] RecursivePreOrderTraverse(Node<T> currentNode)
        {
            List<T> values = new List<T>();

            if(currentNode == null)
            {
                return null;
            }

            values.Add(currentNode.Value);

            if (currentNode.Left != null && !values.Contains(currentNode.Left.Value))
            {
                values.AddRange(RecursivePreOrderTraverse(currentNode.Left));
            }
            if (currentNode.Right != null && !values.Contains(currentNode.Right.Value))
            {
                values.AddRange(RecursivePreOrderTraverse(currentNode.Right));
            }

            return values.ToArray();
        }
    }
}
