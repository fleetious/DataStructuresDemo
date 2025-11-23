using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public class AVLTreeLeaf<T> // rename to AVLTreeLeaf or smth after making tree
        {
            public AVLTreeLeaf<T> Left;
            public AVLTreeLeaf<T> Right;

            public int Height = 1;
            public int Balance => GetBalance();

            public T Value;

            public AVLTreeLeaf(T value) : this(value, null, null) { }
            public AVLTreeLeaf(T value, AVLTreeLeaf<T> left, AVLTreeLeaf<T> right)
            {
                Value = value;
                Left = left;
                Right = right;
            }
            int GetBalance()
            {
                // btw so bad make ts into a one liner pretty
                if(Left != null)
                {
                    if(Right != null)
                    {
                        return Left.Height - Right.Height;
                    }

                    return Left.Height;
                }

                if(Right != null)
                {
                    return -Right.Height;
                }

                return 0;
            }
        }

        public AVLTreeLeaf<T> Root;

        public AVLTree() : this(null) { }

        public AVLTree(AVLTreeLeaf<T> root)
        {
            Root = root;
        }

        public void Insert(T value)
        {
            Root = RecursiveInsert(value, Root);
        }

        // yoo what if we just use search to find the node and then in remove we handle the childrenn nuh uh
        public AVLTreeLeaf<T> Remove(T value)
        {
            return RecursiveRemove(value, Root);
        }

        public T[] Traverse()
        {
            return RecursiveTraversal(Root);
        }

        public bool Contains(T value) => Contains(value, Root);


        public AVLTreeLeaf<T> Search(T value) => Search(value, Root);

        private static bool Contains(T value, AVLTreeLeaf<T> root) => Search(value, root) != null;

        private static AVLTreeLeaf<T> Search(T value, AVLTreeLeaf<T> root) => RecursiveSearch(value, root);

        private AVLTreeLeaf<T> RecursiveInsert(T value, AVLTreeLeaf<T> currentNode)
        {
            if (Contains(value)) throw new ArgumentException("Duplicate value inserted into AVL tree not allow!!");

            if (currentNode == null)
            {
                return new AVLTreeLeaf<T>(value);
            }
            if (currentNode.Value.CompareTo(value) < 0)
            {
                AVLTreeLeaf<T> temp = RecursiveInsert(value, currentNode.Right);
                currentNode.Right = temp;

                currentNode.Height = GetMaxHeight(currentNode.Left, currentNode.Right);
            }
            else
            {
                AVLTreeLeaf<T> temp = RecursiveInsert(value, currentNode.Left);
                currentNode.Left = temp;

                currentNode.Height = GetMaxHeight(currentNode.Left, currentNode.Right);
            }
            //add rotations here
            currentNode = Balance(currentNode);
            return currentNode;
        }

        private static AVLTreeLeaf<T> RecursiveRemove(T value, AVLTreeLeaf<T> currentNode)
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

        private static AVLTreeLeaf<T> Balance(AVLTreeLeaf<T> node)
        {
            if (node.Balance == 0) return node;

            if(node.Balance > 1)
            {
                if(node.Left != null && node.Left.Right != null)
                {
                    node.Left = LeftRotate(node.Left);
                }

                node = RightRotate(node);
            }
            if(node.Balance < 1)
            {
                if(node.Right != null && node.Right.Left != null)
                {
                    node.Right = RightRotate(node.Right);
                }

                node = LeftRotate(node);
            }
            // LOOk AT hOw good THIS looks
            /*node = node.Balance > 1 ? LeftRotate(node) :
                   node.Balance < 1 ? RightRotate(node) :
                   node;*/

            //if (node != null || node is ConfiguredCancelableAsyncEnumerable<double>) return null;
            return node;
        }
        //private void BubbleUpHeight(Node<T> startNode)
        //{
        //    BubbleUpHeight(startNode, Root);
        //}

        //// essentially just copy pasted from search lmao

        //private static Node<T> BubbleUpHeight(Node<T> startNode, Node<T> currentNode) // startNode is the node we started from to bubble up, currentNode shouuld ALWAYS be Root at first call
        //{
        //    if (currentNode == null) return null;

        //    if (currentNode.Value.CompareTo(startNode.Value) == 0) return currentNode;
        //    if (currentNode.Value.CompareTo(startNode.Value) < 0)
        //    {
        //        currentNode.Height = GetMaxHeight(currentNode.Left, currentNode.Right) + 1;
        //        // w chatgpt oneliner
        //        currentNode.Balance = (currentNode.Left != null ? currentNode.Left.Height : 0) - (currentNode.Right != null ? currentNode.Right.Height : 0);

        //        if(Math.Abs(currentNode.Balance) > 1)
        //        {
        //            currentNode = RotateWrapper(currentNode);
        //        }

        //        return BubbleUpHeight(startNode, currentNode.Right);
        //    }
        //    else
        //    {
        //        currentNode.Height = GetMaxHeight(currentNode.Left, currentNode.Right) + 1;
        //        currentNode.Balance = (currentNode.Left != null ? currentNode.Left.Height : 0) - (currentNode.Right != null ? currentNode.Right.Height : 0);

        //        if (Math.Abs(currentNode.Balance) > 1)
        //        {
        //            currentNode = RotateWrapper(currentNode);
        //        }

        //        return BubbleUpHeight(startNode, currentNode.Left);
        //    }
        //}

        private static AVLTreeLeaf<T> RotateWrapper(AVLTreeLeaf<T> currentNode)
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

        private static AVLTreeLeaf<T> RightRotate(AVLTreeLeaf<T> unbalancedNode)
        {
            AVLTreeLeaf<T> newRoot = unbalancedNode.Left;
            unbalancedNode.Left = newRoot.Right;
            newRoot.Right = unbalancedNode;

            return newRoot;
        }

        private static AVLTreeLeaf<T> LeftRotate(AVLTreeLeaf<T> unbalancedNode)
        {
            AVLTreeLeaf<T> newRoot = unbalancedNode.Right;
            unbalancedNode.Right = newRoot.Left;
            newRoot.Left = unbalancedNode;

            return newRoot;
        }

        private static int GetMaxHeight(AVLTreeLeaf<T> left, AVLTreeLeaf<T> right)
        {
            if (left == null && right == null) return 1; // yes.
            if(left == null) return right.Height;
            if(right == null) return left.Height;

            return Math.Max(left.Height, right.Height);
        }
        private static AVLTreeLeaf<T> RemoveNode(AVLTreeLeaf<T> node)
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
        private static AVLTreeLeaf<T> RecursiveSearch(T value, AVLTreeLeaf<T> currentNode)
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
        private T[] RecursiveTraversal(AVLTreeLeaf<T> node) // params are TBD
        {
            return RecursivePreOrderTraverse(node);
        }

        private T[] RecursivePreOrderTraverse(AVLTreeLeaf<T> currentNode)
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
