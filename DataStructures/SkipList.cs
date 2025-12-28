using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class SkipList<T> where T : IComparable<T> // im js gonna be honest skip lists are completely impossible to visualize in my head so imma just leave this untested for now and come back to it later when i have more brain power to figure it out
    {
        public class Node<T> where T : IComparable<T>
        {
            public T Value; // Value of the node
            public Node<T> Next; // Rightward connection
            public Node<T> Down; // Downward connection
            public int Height { get; } // Vertical height of the node

            public Node(T value, int height)
            {
                Value = value;
                Height = height;
            }
            public Node(T value, Node<T> down, int height)
            {
                Value = value;
                Height = height;
                Down = down;
            }
        }
        public SkipList()
        {
            Head = new Node<T>(default(T), 1);
        }
        public Node<T> Head { get; private set; }

        public void Insert(T value)
        {
            if(Contains(value))
            {
                throw new Exception("Duplicate values are not allowed in SkipList.");
            }

            //get height
            Random rand = new Random(5);
            int height = 1;
            while (rand.Next(2) == 1 && height < Head.Height + 1)
            {
                height++;
            }

            //increase head height if needed
            if (height > Head.Height)
            {
                Node<T> newHead = new Node<T>(default(T), Head, height);
                Head = newHead;
            }

            Insert(value, Head, height);
        }
        // idk how to link nodes above height 0
        public static Node<T> Insert(T value, Node<T> node, int height) // praying this works :pray:
        {
            if (node == null)
            {
                return node;
            }
            if (node.Next == null || value.CompareTo(node.Next.Value) < 0)
            {
                Node<T> temp = Insert(value, node.Down, height);

                if (node    .Height <= height)
                {
                    var newNode = new Node<T>(value, temp, node.Height);
                    newNode.Next = node.Next;
                    node.Next = newNode;
                    return newNode;
                }
            }
            else
            {
                return Insert(value, node.Next, height);
            }


            throw new Exception("Duplicate values are not allowed in SkipList."); // ty chatgpt for writing the error message :teary_eyed: :pray:
        }

        private Node<T> CreateNode(T value, int height, Node<T> prev, Node<T> next)
        {
            if (height == 0)
            {
                return null;
            }
            Node<T> node = new Node<T>(value, CreateNode(value, height - 1, prev.Down, next.Down), height);
            prev.Next = node;
            node.Next = next;
            return node;
        }

        public bool Remove(T value)
        {
            return Remove(value, Head);
        }
        public static bool Remove(T value, Node<T> node) // praying this works :pray:
        {
            if (node == null)
            {
                return false;
            }

            if (node.Next == null)
            {
                return Remove(value, node.Down);
            }

            int com = value.CompareTo(node.Next.Value);
            if (com < 0)
            {
                return Remove(value, node.Down);
            }
            else if (com > 0)
            {
                return Remove(value, node.Next);
            }
            else if (com == 0)
            {
                node.Next = node.Next.Next;
                Remove(value, node.Down);
                return true;
            }

            throw new Exception("Could not find node to remove.");
        }

        public bool Contains(T value)
        {
            return Search(value) != null;
        }

        public Node<T> Search(T value)
        {
            return Search(value, Head);
        }

        public static Node<T> Search(T value, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Next == null)
            {
                return Search(value, node.Down);
            }

            int com = value.CompareTo(node.Next.Value);

            if (com < 0)
            {
                return Search(value, node.Down);
            }
            else if (com > 0)
            {
                return Search(value, node.Next);
            }
            else if (com == 0)
            {
                return node.Next;
            }

            throw new Exception("Could not find node."); // ty gpt for writing the error message :teary_eyed: :pray: and it even did the emojis woww
        }
    }
}
