using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Node<T>
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
    class LinkedList<T>
    {
        public Node<T> Head { get; private set; }
        public Node<T> Tail { get; private set; }
        public int Count { get; private set; }

        public void AddFirst(T value) // add a new head at the beginning of the list
        {
            Head = new Node<T>(value, Head);

            Count++;
        }

        public void AddLast(T value) // add a new tail at the end of the list
        {
            Tail.Next = new Node<T>(value);
            Tail = Tail.Next;

            Count++;
        }

        public void AddBefore(Node<T> node, T value) // add a new node before any specified (and extant) node
        { // IS THIS VALID CODEEE
            getNodeBeforeNode(node).Next = new Node<T>(value, node);

            Count++;
        }

        public void AddAfter(Node<T> node, T value)  // add a new node after any specified (and extant) node
        {
            throw new NotImplementedException();
        }

        public bool RemoveFirst() // remove the first node
        {
            throw new NotImplementedException();
        }

        public bool RemoveLast() // remove the last node
        {
            throw new NotImplementedException();
        }

        public bool Remove(T value)// find and remove a node containing the given value
        {
            throw new NotImplementedException();
        }

        public void Clear() // delete every node in the linked list
        {
            throw new NotImplementedException();
        }

        public Node<T> Search(T value) // search for a given value and return a node that contains it, return null if none is found
        {
            throw new NotImplementedException();
        }

        public bool Contains(T value) // search for a given value and return if you found it.
        {
            throw new NotImplementedException();
        }

        public bool Contains(Node<T> node) // search for a given node and return if you found it.
        {
            throw new NotImplementedException();
        }

        private Node<T> getNodeBeforeNode(Node<T> node)
        {
            Node<T> currentNode = Head;
            for (int i = 0; i < Count; i++)
            {
                if (currentNode.Next == node) return currentNode;
                currentNode = currentNode.Next;
            }

            return Tail;
        }
    }
}
