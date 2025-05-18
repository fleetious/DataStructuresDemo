using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class DoublyLinkedListNode<T> where T : IComparable<T>
    {
        public T Value;
        public DoublyLinkedListNode<T> Next;
        public DoublyLinkedListNode<T> Previous;

        public DoublyLinkedListNode(T value)
            : this(value, null, null) { }

        public DoublyLinkedListNode(T value, DoublyLinkedListNode<T> next)
            : this(value, next, null) { }

        public DoublyLinkedListNode(T value, DoublyLinkedListNode<T> next, DoublyLinkedListNode<T> previous)
        {
            Value = value;
            Next = next;
            Previous = previous;
        }
    }
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; }
        public int Count { get; private set; }

        public DoublyLinkedListNode<T> AddFirst(T value) // add a new head at the beginning of the list
        {
            if (Head != null)
            {
                Head = new DoublyLinkedListNode<T>(value, Head, Head.Previous);
                Head.Next.Previous = Head; // head.next and head.previous are references to the original head and tail, so we need to update them to point to the new head (i love autocomplete comments)
                Head.Previous.Next = Head;
            }
            else
            {
                Head = new DoublyLinkedListNode<T>(value);
                Head.Next = Head;
                Head.Previous = Head;
            }

            Count++;

            return Head;
        }

        public DoublyLinkedListNode<T> AddBefore(DoublyLinkedListNode<T> DoublyLinkedNode, T value) // add a new DoublyLinkedListNode before any specified (and extant) DoublyLinkedListNode
        {
            DoublyLinkedListNode<T> nodeToAdd = new DoublyLinkedListNode<T>(value, DoublyLinkedNode, DoublyLinkedNode.Previous);
            DoublyLinkedNode.Previous.Next = nodeToAdd;
            DoublyLinkedNode.Previous = nodeToAdd;

            if(DoublyLinkedNode == Head) Head = nodeToAdd; // if the new node is the new head, update the head reference (autocomplete comment)

            Count++;

            return nodeToAdd;
        }

        public DoublyLinkedListNode<T> AddAfter(DoublyLinkedListNode<T> DoublyLinkedNode, T value)  // add a new DoublyLinkedListNode after any specified (and extant) DoublyLinkedListNode
        {
            DoublyLinkedListNode<T> nodeToAdd = new DoublyLinkedListNode<T>(value, DoublyLinkedNode.Next, DoublyLinkedNode);
            DoublyLinkedNode.Next.Previous = nodeToAdd;
            DoublyLinkedNode.Next = nodeToAdd;

            Count++;

            return nodeToAdd;
        }

        public bool RemoveFirst() // remove the first DoublyLinkedListNode
        {
            if (Head == null) return false;

            Head = Head.Next;
            Count--;
            return true;
        }

        public bool Remove(T value)// find and remove a DoublyLinkedListNode containing the given value
        {
            DoublyLinkedListNode<T> node = Search(value);

            if (node == null) return false;

            if (node.Previous != null) node.Previous.Next = node.Next;
            if (node.Next != null) node.Next.Previous = node.Previous;
            Count--;

            return true;
        }

        public void Clear() // delete every DoublyLinkedListNode in the linked list
        {
            Head = null;
            Count = 0;
        }

        public DoublyLinkedListNode<T> Search(T value) // search for a given value and return a DoublyLinkedListNode that contains it, return null if none is found
        {
            if (Head == null) return null;

            DoublyLinkedListNode<T> currentDoublyLinkedNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentDoublyLinkedNode.Value.CompareTo(value) == 0) return currentDoublyLinkedNode;
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }

            return null;
        }

        public DoublyLinkedListNode<T> Search(DoublyLinkedListNode<T> node) // search for a given value and return a DoublyLinkedListNode that contains it, return null if none is found
        {
            if (Head == null) return null;

            DoublyLinkedListNode<T> currentDoublyLinkedNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentDoublyLinkedNode == node) return currentDoublyLinkedNode;
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }

            return null;
        }

        public bool Contains(T value) => Search(value) != null; // search for a given value and return if you found it.

        public bool Contains(DoublyLinkedListNode<T> DoublyLinkedNode) // search for a given DoublyLinkedListNode and return if you found it.
        {
            if (Head == null) return false;

            DoublyLinkedListNode<T> currentDoublyLinkedNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentDoublyLinkedNode == DoublyLinkedNode) return true;
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }

            return false;
        }
    }
}
