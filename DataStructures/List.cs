namespace DataStructures
{
    internal class List<T>
    {
        private T[] array;

        public int Count
        {
            get;
            private set;
        }

        public List()
        {
            array = new T[1];
        }

        public void Add(T item)
        {
            if(Count == array.Length) ExpandArray();
            
            array[Count] = item;
            Count++;
        }

        public void RemoveAt(int index)
        {
            if (Count < 2)
            {
                Console.Clear();
                Console.WriteLine("ERROR: Removal of an element will cause array to be empty");
                return;
            }

            MoveDownArray(index, Count);
            Count--;
        }
        private void MoveDownArray(int from, int to)
        {
            for(int i = from; i < to - 1; i++)
            {
                array[i] = array[i + 1];
            }
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
