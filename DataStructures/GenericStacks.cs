using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class GenericLinkedListStack<T> where T : IComparable<T>
    {
        private GenericLinkedList<T> data;
        public int Count { get { return data.Count; } }

        public GenericLinkedListStack() => data = new GenericLinkedList<T>();

        public void Push(T value) => data.AddLast(value);
        public T Pop()
        {
            T value = data.Tail.Value;

            if(Count != 0) data.RemoveLast();

            return value;
        }
        public T Peek() => data.Tail.Value;
        public void Clear() => data.Clear();
        public bool IsEmpty() => data.Count == 0;
    }

    public class GenericArrayStack<T> where T : IComparable<T>
    {
        private T[] data;
        private int count;
        public int Count { get { return count; } }
        public GenericArrayStack(int size = 8)
        {
            data = new T[size];
            count = 0;
        }

        public void Push(T value)
        {
            if (count == data.Length) Resize();
            data[count++] = value;
        }
        
        public T Pop()
        {
            if(count == 0) throw new InvalidOperationException("Stack is empty");
            return data[--count];
        }

        public T Peek()
        {
            if(count == 0) throw new InvalidOperationException("Stack is empty");
            return data[count - 1];
        }

        private void Resize()
        {
            T[] newData = new T[data.Length * 2];
            for (int i = 0; i < data.Length; i++) newData[i] = data[i];
            data = newData;
        }

        public void Clear() => count = 0;
        public bool IsEmpty() => count == 0;
    }
}
