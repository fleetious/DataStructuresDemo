using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures
{
    public class LinkedListNode<T> where T : IComparable<T>
    {
        public T Value;
        public LinkedListNode<T> Next;

        public LinkedListNode(T value) { Value = value; }
        public LinkedListNode(T value, LinkedListNode<T> next)
        {
            Value = value;
            Next = next;
        }
    }
    public class GenericLinkedList<T> where T : IComparable<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }
        public int Count { get; private set; }

        public void AddFirst(T value) // add a new head at the beginning of the list
        {
            Head = new LinkedListNode<T>(value, Head != null ? Head : Tail);

            if(Count == 0) { Tail = new LinkedListNode<T>(value); }

            Count++;
        }

        public void AddLast(T value) // add a new tail at the end of the list
        { // dont ask me why this works
            if (Tail != null)
            {
                if (Head != null)
                {
                    getNodeBeforeNode(Tail).Next = new LinkedListNode<T>(Tail.Value, new LinkedListNode<T>(value)); // this makes tail a default node instead of a tail node
                    Tail = new LinkedListNode<T>(value);
                }
                else
                {
                    Head = new LinkedListNode<T>(Tail.Value);
                    Tail = new LinkedListNode<T>(value);
                    Head.Next = Tail;
                }
            }
            else
            {
                Tail = new LinkedListNode<T>(value);
            }
            Count++;
        }

        public void AddBefore(LinkedListNode<T> node, T value) // add a new node before any specified (and extant) node
        {
            if (node == Head) { AddFirst(value); return; }

            getNodeBeforeNode(node).Next = new LinkedListNode<T>(value, node);

            Count++;
        }

        public void AddAfter(LinkedListNode<T> node, T value)  // add a new node after any specified (and extant) node
        {
            LinkedListNode<T> nodeToAddTo = getNode(node);
            if (nodeToAddTo == Tail) { AddLast(value); return; }

            getNode(node).Next = new LinkedListNode<T>(value, nodeToAddTo.Next);
        }

        public bool RemoveFirst() // remove the first node
        {
            if (Head == null) return false;

            Head = Head.Next;
            Count--;
            return true;
        }

        public bool RemoveLast() // remove the last node
        {
            Tail = getNodeBeforeNode(Tail);

            if (Tail == null)
            {
                Head = Head.Next;
                Count--;
                return true;
            }

            Tail.Next = null;
            Count--;
            return true;
        }

        public bool Remove(T value)// find and remove a node containing the given value
        {
            LinkedListNode<T> node = Search(value);
            LinkedListNode<T> beforeNode = getNodeBeforeNode(node);

            if (beforeNode == null)
            {
                if(node != Head) return false;

                Count--;
                Head = node.Next;
                return true;
            }

            beforeNode.Next = node.Next;

            if(node == Tail) Tail = beforeNode;

            Count--;

            return true;
        }

        public void Clear() // delete every node in the linked list
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public LinkedListNode<T> Search(T value) // search for a given value and return a node that contains it, return null if none is found
        {
            if (Head == null) return null;

            LinkedListNode<T> currentNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.Value.CompareTo(value) == 0) return currentNode;
                currentNode = currentNode.Next;
            }

            return null;
        }

        public bool Contains(T value) => Search(value) != null; // search for a given value and return if you found it.

        public bool Contains(LinkedListNode<T> node) // search for a given node and return if you found it.
        {
            if (Head == null) return false;

            LinkedListNode<T> currentNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentNode == node) return true;
                currentNode = currentNode.Next;
            }

            return false;
        }

        private LinkedListNode<T> getNodeBeforeNode(LinkedListNode<T> node)
        {
            if (Head == null) return null;
            if (node == Head) return null;

            LinkedListNode<T> currentNode = Head;
            for (int i = 0; i < Count - 1; i++)
            {
                if (currentNode.Next.Value.Equals(node.Value)) return currentNode;
                currentNode = currentNode.Next;
            }

            return null;
        }

        private LinkedListNode<T> getNode(LinkedListNode<T> node)
        {
            if (Head == null) return null;
            if (node == Head) return Head;
            if (node == Tail) return Tail;

            LinkedListNode<T> currentNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.Next == node) return currentNode.Next;
                currentNode = currentNode.Next;
            }

            return null;
        }
    }
}
