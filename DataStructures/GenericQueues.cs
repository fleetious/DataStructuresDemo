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
        private int count;
        public int Count { get { return count; } }
        public GenericArrayQueue(int size = 8) => data = new T[size];

        public void Enqueue(T value)
        {
            PushForwardData();
            data[count++] = value;
        }
        public T Dequeue()
        {
            T value = data[--count];
            PullBackData();
            return value;
        }

        private void PushForwardData()
        {
            if(count == data.Length - 1) Resize();
            for (int i = data.Length; i > 0; i--) data[i] = data[i - 1];
        }
        private void PullBackData()
        {
            for (int i = 0; i < data.Length - 1; i++) data[i] = data[i + 1];
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
