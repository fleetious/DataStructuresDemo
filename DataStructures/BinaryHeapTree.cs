using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class BinaryHeapTree<T> where T : IComparable<T>
    {
        private T[] values;
        private int count = 0;
        private int level = 0;

        public BinaryHeapTree()
        {
            values = new T[1];
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

        private void HeapifyUp(int index)
        {
            if (values == null) return;
            if(index == 0) return;

            T value = values[index];
            int parentIndex = GetParentIndex(index);

            if (value.CompareTo(values[parentIndex]) > 0)
            {
                Swap(ref values[index], ref values[parentIndex]);
            }

            HeapifyUp(parentIndex);
        }

        private int GetParentIndex(int childIndex)
        {
            int childDelta = values.Length - childIndex; // delta to top of level
            int parentDelta = (int)Math.Floor((double)childDelta / 2); // delta to top of level
            int childLevelBottom = values.Length - (int)Math.Pow(2, level);
            
            return childLevelBottom - parentDelta;
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
