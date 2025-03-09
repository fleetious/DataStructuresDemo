namespace DataStructures
{
    public class GenericList<T>
    {
        private T[] array;

        public int Count
        {
            get;
            private set;
        }

        public GenericList()
        {
            array = new T[1];
        }

        public void Add(T item)
        {
            if (Count == array.Length) ExpandArray();

            array[Count] = item;
            Count++;
        }

        public bool RemoveAt(int index)
        {
            if (Count == 0)
            {
                return false;
            }
            MoveDownArray(index, Count, 1);

            return true;
        }

        public bool RemoveValue(T value)
        {
            if (Count == 0)
            {
                return false;
            }

            for (int i = Count - 1; i > -1; i--)
            {
                if (array[i].Equals(value))
                {
                    MoveDownArray(i, Count, 1);
                    return true;
                }
            }

            return false;
        }

        public void Insert(T item, int index)
        {
            if (index >= array.Length) ExpandArray();
            if (index < Count) MoveDownArray(index + 1, Count, -1); // -1 moves all the values in the array UP by one index

            array[index] = item;
            Count = index;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(item)) return true;
            }
            return false;
        }
        private void MoveDownArray(int from, int to, int increment) // TODO: make this private
        {
            Count--;
            for (int i = from; i < to - increment; i++)
            {
                array[i] = array[i + increment];
            }
        }

        private void ExpandArray()
        {
            T[] newArray = new T[array.Length * 2];
            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }
       
        
        
        // THIS NOT MY CODE!!! https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/indexers/
        public T this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;

            }
        }
    }
}
