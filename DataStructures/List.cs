namespace DataStructures
{
    internal class List<T>
    {
        private T[] array;
        private HashSet<T> hashSet; // for fast this.Contains lookups

        public int Count
        {
            get;
            private set;
        }

        public List()
        {
            array = new T[1];
            hashSet = new ();
        }

        public void Add(T item)
        {
            if(Count == array.Length) ExpandArray();
            
            hashSet.Add(item);
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
            hashSet.Remove(array[index]);
            MoveDownArray(index, Count, 1);
            Count--;
        }

        public void Insert(T item, int index)
        {
            if(Count == array.Length) ExpandArray();
            if(index < Count) MoveDownArray(index, Count, -1); // -1 moves all the values in the array UP by one index
            
            hashSet.Add(item);
            array[index] = item;
            Count++;
        }

        public bool Contains(T item)
        {
            return hashSet.Contains(item);
        }
        private void MoveDownArray(int from, int to, int increment)
        {
            for(int i = from; i < to - increment; i++)
            {
                array[i] = array[i + increment];
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
