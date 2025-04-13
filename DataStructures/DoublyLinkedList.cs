using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class DoublyLinkedNode<T> where T : IComparable<T>
    {
        public T Value;
        public DoublyLinkedNode<T> Next;
        public DoublyLinkedNode<T> Previous;

        public DoublyLinkedNode(T value)
            : this(value, null, null) { }

        public DoublyLinkedNode(T value, DoublyLinkedNode<T> next)
            : this(value, next, null) { }

        public DoublyLinkedNode(T value, DoublyLinkedNode<T> next, DoublyLinkedNode<T> previous)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        public DoublyLinkedNode<T> Head { get; private set; }
        public int Count { get; private set; }

        public DoublyLinkedNode<T> AddFirst(T value) // add a new head at the beginning of the list
        {
            if (Head != null)
            {
                Head = new DoublyLinkedNode<T>(value, Head, Head.Previous);
            }
            else
            {
                Head = new DoublyLinkedNode<T>(value);
                Head.Next = Head;
                Head.Previous = Head;
            }

            Count++;

            return Head;
        }

        public DoublyLinkedNode<T> AddBefore(DoublyLinkedNode<T> DoublyLinkedNode, T value) // add a new DoublyLinkedNode before any specified (and extant) DoublyLinkedNode
        {
            DoublyLinkedNode<T> nodeToAdd;
            if (DoublyLinkedNode.Previous == null)
            {
                nodeToAdd = new DoublyLinkedNode<T>(value, Head, DoublyLinkedNode);
            }
            else
            {
                nodeToAdd = new DoublyLinkedNode<T>(value, DoublyLinkedNode, DoublyLinkedNode.Previous);
            }
            Search(DoublyLinkedNode).Previous = nodeToAdd;

            Count++;

            return nodeToAdd;
        }

        public DoublyLinkedNode<T> AddAfter(DoublyLinkedNode<T> DoublyLinkedNode, T value)  // add a new DoublyLinkedNode after any specified (and extant) DoublyLinkedNode
        {
            DoublyLinkedNode<T> nodeToAdd;
            if (DoublyLinkedNode.Next == null)
            {
                nodeToAdd = new DoublyLinkedNode<T>(value, Head, DoublyLinkedNode);
            }
            else
            {
                nodeToAdd = new DoublyLinkedNode<T>(value, DoublyLinkedNode.Next, DoublyLinkedNode);
            }
            Search(DoublyLinkedNode).Next = nodeToAdd;

            Count++;

            return nodeToAdd;
        }

        public bool RemoveFirst() // remove the first DoublyLinkedNode
        {
            if (Head == null) return false;

            Head = Head.Next;
            Count--;
            return true;
        }

        public bool Remove(T value)// find and remove a DoublyLinkedNode containing the given value
        {
            DoublyLinkedNode<T> node = Search(value);

            if (node == null) return false;

            if (node.Previous != null) node.Previous.Next = node.Next;
            if (node.Next != null) node.Next.Previous = node.Previous;
            Count--;

            return true;
        }

        public void Clear() // delete every DoublyLinkedNode in the linked list
        {
            Head = null;
            Count = 0;
        }

        public DoublyLinkedNode<T> Search(T value) // search for a given value and return a DoublyLinkedNode that contains it, return null if none is found
        {
            if (Head == null) return null;

            DoublyLinkedNode<T> currentDoublyLinkedNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentDoublyLinkedNode.Value.CompareTo(value) == 0) return currentDoublyLinkedNode;
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }

            return null;
        }

        public DoublyLinkedNode<T> Search(DoublyLinkedNode<T> node) // search for a given value and return a DoublyLinkedNode that contains it, return null if none is found
        {
            if (Head == null) return null;

            DoublyLinkedNode<T> currentDoublyLinkedNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentDoublyLinkedNode == node) return currentDoublyLinkedNode;
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }

            return null;
        }

        public bool Contains(T value) => Search(value) != null; // search for a given value and return if you found it.

        public bool Contains(DoublyLinkedNode<T> DoublyLinkedNode) // search for a given DoublyLinkedNode and return if you found it.
        {
            if (Head == null) return false;

            DoublyLinkedNode<T> currentDoublyLinkedNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentDoublyLinkedNode == DoublyLinkedNode) return true;
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }

            return false;
        }
    }
}
