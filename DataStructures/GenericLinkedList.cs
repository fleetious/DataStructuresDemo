using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataStructures
{
    public class Node<T> where T : IComparable<T>
    {
        public T Value;
        public Node<T> Next;

        public Node(T value) { Value = value; }
        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }
    }
    public class GenericLinkedList<T> where T : IComparable<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }

        public void AddFirst(T value) // add a new head at the beginning of the list
        {
            Head = new Node<T>(value, Head != null ? Head : Tail);

            if(Count == 0) { Tail = new Node<T>(value); }

            Count++;
        }

        public void AddLast(T value) // add a new tail at the end of the list
        { // dont ask me why this works
            if (Tail != null)
            {
                if (Head != null)
                {
                    getNodeBeforeNode(Tail).Next = new Node<T>(Tail.Value, new Node<T>(value)); // this makes tail a default node instead of a tail node
                    Tail = new Node<T>(value);
                }
                else
                {
                    Head = new Node<T>(Tail.Value);
                    Tail = new Node<T>(value);
                    Head.Next = Tail;
                }
            }
            else
            {
                Tail = new Node<T>(value);
            }
            Count++;
        }

        public void AddBefore(Node<T> node, T value) // add a new node before any specified (and extant) node
        {
            if (node == Head) { AddFirst(value); return; }

            getNodeBeforeNode(node).Next = new Node<T>(value, node);

            Count++;
        }

        public void AddAfter(Node<T> node, T value)  // add a new node after any specified (and extant) node
        {
            Node<T> nodeToAddTo = getNode(node);
            if (nodeToAddTo == Tail) { AddLast(value); return; }

            getNode(node).Next = new Node<T>(value, nodeToAddTo.Next);
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
                if(Head == null) return false;
                
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
            Node<T> node = Search(value);
            Node<T> beforeNode = getNodeBeforeNode(node);

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

        public Node<T> Search(T value) // search for a given value and return a node that contains it, return null if none is found
        {
            if (Head == null) return null;

            Node<T> currentNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.Value.CompareTo(value) == 0) return currentNode;
                currentNode = currentNode.Next;
            }

            return null;
        }

        public bool Contains(T value) => Search(value) != null; // search for a given value and return if you found it.

        public bool Contains(Node<T> node) // search for a given node and return if you found it.
        {
            if (Head == null) return false;

            Node<T> currentNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentNode == node) return true;
                currentNode = currentNode.Next;
            }

            return false;
        }

        private Node<T> getNodeBeforeNode(Node<T> node)
        {
            if (Head == null) return null;
            if (node == Head) return null;

            Node<T> currentNode = Head;
            for (int i = 0; i < Count - 1; i++)
            {
                if (currentNode.Next.Value.Equals(node.Value)) return currentNode;
                currentNode = currentNode.Next;
            }

            return null;
        }

        private Node<T> getNode(Node<T> node)
        {
            if (Head == null) return null;
            if (node == Head) return Head;
            if (node == Tail) return Tail;

            Node<T> currentNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.Next == node) return currentNode.Next;
                currentNode = currentNode.Next;
            }

            return null;
        }
    }
}
