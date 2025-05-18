using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class GenericLinkedListQueue<T> where T : IComparable<T>
    {
        private GenericLinkedList<T> data;
        public int Count { get { return data.Count; } }
        public GenericLinkedListQueue() => data = new GenericLinkedList<T>();
        
        public void Enqueue(T value) => data.AddFirst(value);
        public T Dequeue()
        {
            T value = data.Tail.Value;
            data.RemoveLast();
            return value;
        }
        public T Peek() => data.Tail.Value;
        public void Clear() => data.Clear();
        public bool IsEmpty() => data.Count == 0;
    }

    public class GenericArrayQueue<T> where T : IComparable<T>
    {
        private T[] data;
        private int count = 0;
        public int Count { get { return count; } }

        private int Head
        {
            set
            {
                Head = Head < count ? value : 0;
            }
            get
            {
                return Head;
            }
        }
        private int Tail
        {
            set
            {
                Tail = Tail < count ? value : 0;
            }
            get
            {
                return Tail;
            }
        }
        public GenericArrayQueue(int size = 8) => data = new T[size];

        public void Enqueue(T value)
        {
            if(count == data.Length) Resize();

            data[Tail++] = value;
            count++;
        }
        public T Dequeue()
        {
            if (count == 0) throw new InvalidOperationException("Queue is empty"); // auto complet code pls no buly

            T value = data[Head++];
            count--;
            return value;
        }
        private void Resize()
        {
            T[] newData = new T[data.Length * 2];
            for (int i = 0; i < data.Length; i++) newData[i] = data[i];
            data = newData;
        }

        public T Peek() => data[count - 1];
        public void Clear()
        {
            data = new T[data.Length];
            count = 0;
        }
        public bool IsEmpty() => count == 0;
    }
}
