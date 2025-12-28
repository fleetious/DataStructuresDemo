using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class SkipListNode<T> where T : IComparable<T>
    {
        public T Value; // Value of the node
        public SkipListNode<T> Next; // Rightward connection
        public SkipListNode<T> Down; // Downward connection
        public int Height { get; } // Vertical height of the node

        public SkipListNode(T value, int height)
        {
            Value = value;
            Height = height;
        }
        public SkipListNode(T value, SkipListNode<T> down, int height)
        {
            Value = value;
            Height = height;
            Down = down;
        }
    }

    public class SkipList<T> where T : IComparable<T> // im js gonna be honest skip lists are completely impossible to visualize in my head so imma just leave this untested for now and come back to it later when i have more brain power to figure it out
    {
        public SkipList()
        {
            Head = new SkipListNode<T>(default(T), 1);
        }
        public SkipListNode<T> Head { get; private set; }

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
                SkipListNode<T> newHead = new SkipListNode<T>(default(T), Head, height);
                Head = newHead;
            }

            Insert(value, Head, height);
        }
        // idk how to link nodes above height 0
        public static SkipListNode<T> Insert(T value, SkipListNode<T> node, int height) // praying this works :pray:
        {
            if (node == null)
            {
                return node;
            }
            if (node.Next == null || value.CompareTo(node.Next.Value) < 0)
            {
                SkipListNode<T> temp = Insert(value, node.Down, height);

                if (node    .Height <= height)
                {
                    var newNode = new SkipListNode<T>(value, temp, node.Height);
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

        private SkipListNode<T> CreateNode(T value, int height, SkipListNode<T> prev, SkipListNode<T> next)
        {
            if (height == 0)
            {
                return null;
            }
            SkipListNode<T> node = new SkipListNode<T>(value, CreateNode(value, height - 1, prev.Down, next.Down), height);
            prev.Next = node;
            node.Next = next;
            return node;
        }

        public bool Remove(T value)
        {
            return Remove(value, Head);
        }
        public static bool Remove(T value, SkipListNode<T> node) // praying this works :pray:
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

        public SkipListNode<T> Search(T value)
        {
            return Search(value, Head);
        }

        public static SkipListNode<T> Search(T value, SkipListNode<T> node)
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
