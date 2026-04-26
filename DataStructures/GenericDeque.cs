using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class GenericDeque<T> : IStack<T>, IQueue<T> where T : IComparable<T>
    {
        private GenericLinkedList<T> data;
        public int Count { get { return data.Count; } }

        public GenericDeque() => data = new GenericLinkedList<T>();

        public void PushLast(T value) => data.AddLast(value);
        public T PopLast()
        {
            T value = data.Tail.Value;

            if (Count != 0) data.RemoveLast();

            return value;
        }
        public T PeekLast() => data.Tail != null ? data.Tail.Value : default;

        public void PushFirst(T value) => data.AddFirst(value);
        public T PopFirst()
        {
            T value = data.Tail.Value;

            if (Count != 0) data.RemoveFirst();

            return value;
        }
        public T PeekFirst() => data.Head != null ? data.Head.Value : default; 

        public void Clear() => data.Clear();
        
        // wrappers
        public void Push(T value) => PushLast(value);
        public T Pop() => PopLast();
        T IStack<T>.Peek() => PeekLast();

        public void Enqueue(T value) => PushFirst(value);
        public T Dequeue() => PopLast();
        T IQueue<T>.Peek() => PeekLast();

    }
}
