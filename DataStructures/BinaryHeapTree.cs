using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryHeapTree<T> where T : IComparable<T>
    {
        public int Count { get => count; }

        private Comparer<T> comparer = Comparer<T>.Default;

        private T[] values;
        private int count = 0;
        private int level = 0;

        public BinaryHeapTree() : this(Comparer<T>.Default) { }

        public BinaryHeapTree(Comparer<T> comparer)
        {
            values = new T[1];
            this.comparer = comparer;
        }

        public void Insert(T value)
        {
            if(values == null)
            {
                values = new T[1];
                values[0] = value;
                return;
            }

            if (count >= values.Length) ResizeArrayUp();

            values[count] = value;

            HeapifyUp(count);

            count++;
        }

        public T Pop()
        {
            if (values == null || count == 0) throw new InvalidOperationException("Heap is empty");
            
            T value = values[0];
            values[0] = values[count - 1];
            count--;
            HeapifyDown(0);
            return value;
        }

        public T Search(T value)
        {
            if (values == null || count == 0) return default(T);
            for (int i = 0; i < count; i++)
            {
                if (values[i].Equals(value)) return value;
            }
            return default(T);
        }

        public bool Contains(T value)
        {
            return !Search(value).Equals(default(T));
        }

        private void HeapifyUp(int index)
        {
            if (values == null) return;
            if(index <= 0) return;

            T value = values[index];
            int parentIndex = GetParentIndex(index);

            if (comparer.Compare(value, values[parentIndex]) > 0)
            {
                Swap(ref values[index], ref values[parentIndex]);
            }

            HeapifyUp(parentIndex);
        }

        private void HeapifyDown(int index)
        {
            if (values == null) return;
            if (index >= count) return;

            T value = values[index];
            int leftChildIndex = GetLeftChildIndex(index);
            int rightChildIndex = leftChildIndex + 1;
            
            int toSwapIndex = -1;

            if (isIndexValid(rightChildIndex) && comparer.Compare(value, values[rightChildIndex]) < 0)
            {
                toSwapIndex = rightChildIndex;
            }
            else if (isIndexValid(leftChildIndex) && comparer.Compare(value, values[leftChildIndex]) > 0)
            {
                toSwapIndex = leftChildIndex;
            }

            if (toSwapIndex == -1) return;

            Swap(ref values[index], ref values[toSwapIndex]);
            HeapifyDown(toSwapIndex);
        }

        private bool isIndexValid(int index)
        {
            return index >= 0 && index < count;
        }

        private int GetParentIndex(int childIndex)
        { /* rip my implementation
            int childDelta = values.Length - childIndex; // delta to top of level
            int parentDelta = (int)Math.Floor((double)childDelta / 2); // delta to top of level
            int childLevelBottom = values.Length - (int)Math.Pow(2, level);
            
            return childLevelBottom - parentDelta; */

            return (int)Math.Floor((double)(childIndex - 1) / 2);
        }

        private int GetLeftChildIndex(int parentIndex)
        {
            return (int)Math.Floor((double)parentIndex * 2 + 1);
        }

        private void Swap(ref T item1, ref T item2) // stole from wiki
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }

        private void ResizeArrayUp()
        {
            level++;
            T[] temp = new T[values.Length + (int)Math.Pow(2, level)];

            for(int i = 0; i < values.Length; i++)
            {
                temp[i] = values[i];
            }

            values = temp;
        }
    }
}
