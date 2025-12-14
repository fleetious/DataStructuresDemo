using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class SortedDoublyLinkedList<T> where T : IComparable<T> // i cannot be bothered to implement tests for this right now so imma just leave it like this for now and come back later to finish it at some point in the future
    {
        public DoublyLinkedListNode<T> Head { get; private set; } = new DoublyLinkedListNode<T>(default(T));
        public int Count { get; private set; }

        public DoublyLinkedListNode<T> Insert(DoublyLinkedListNode<T> DoublyLinkedNode, T value) // add a new DoublyLinkedListNode before any specified (and extant) DoublyLinkedListNode
        {
            DoublyLinkedListNode<T> current = Head;

            while (current.Next != null && current.Value.CompareTo(current.Next.Value) > 0)
            {
                current = current.Next;
            }

            ConnectNodes(current, new DoublyLinkedListNode<T>(value), null);
            return current.Next;
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

            while (currentDoublyLinkedNode.Next != null && currentDoublyLinkedNode.Value.CompareTo(value) < 0)
            {
                currentDoublyLinkedNode = currentDoublyLinkedNode.Next;
            }

            if (currentDoublyLinkedNode.Value.CompareTo(value) == 0) return currentDoublyLinkedNode;

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

        private void ConnectNodes(DoublyLinkedListNode<T> previous, DoublyLinkedListNode<T> newNode, DoublyLinkedListNode<T> next)
        {
            previous.Next = newNode;
            newNode.Previous = previous;

            if (next != null)
            {
                newNode.Next = next;
                next.Previous = previous;
            }
        }
    }
}
