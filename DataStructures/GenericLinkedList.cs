using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node<T>
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
    public class GenericLinkedList<T>
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
            if (node == Tail) { AddLast(value); return; }

            getNodeBeforeNode(node).Next = new Node<T>(value, node);

            Count++;
        }

        public void AddAfter(Node<T> node, T value)  // add a new node after any specified (and extant) node
        {
            Node<T> beforeNode = getNodeBeforeNode(node);

            if (beforeNode == Tail) { AddLast(value); return; }
            if (beforeNode == Head) { Head.Next = new Node<T>(value, Head.Next); return; }

            if (beforeNode == null) return;

            beforeNode.Next.Next = new Node<T>(value, beforeNode.Next.Next);
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
            if (Tail == null) return false;

            Tail = getNodeBeforeNode(Tail);
            Tail.Next = null;
            Count--;
            return true;
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
            if (Head == null) return Tail;

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
