using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class BinaryHeapTree<T> where T : IComparable<T>
    {
        private T[] values;
        private int 

        public BinaryHeapTree(T[] values)
        {
            this.values = values;
        }

        public void Insert(T value)
        {
            if(values == null)
            {
                values = new T[1];
                values[0] = value;
                return;
            }

            if()
        }
    }
}
