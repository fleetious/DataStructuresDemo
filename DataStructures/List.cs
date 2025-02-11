using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    internal class List<T>
    {
        private T[] array;

        public int Count
        {
            get;
            private set;
        } = 0;

        public List()
        {
            
        }

        public void Add(T item)
        {
            
        }
        
        private void ExpandArray()
        {
            T[] newArray = new T[array.Length * 2];
            for(int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }
        
        // THIS NOT MY CODE!!! https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/
        public T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }
    }
}
