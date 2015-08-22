namespace GenericList
{
    using System;
    using System.Linq;

    public class GenericList<T> where T : IComparable<T>
    {
        private const int InitiateCapacity = 16;

        private int capacity;
        private int currentIndex;
        private T[] elements;

        public GenericList(int capacity = InitiateCapacity)
        {
            this.currentIndex = 0;
            this.Capacity = capacity;
            this.elements = new T[this.Capacity];
        }

        public T this[int i]
        {
            get
            {
                return this.elements[i];
            }

            set
            {
                this.elements[i] = value;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return this.currentIndex == 0;
            }
        }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("value", "Capacity can't be negative number");
                }

                this.capacity = value;
            }
        }

        public void Add(T element)
        {
            if (this.currentIndex == this.Capacity)
            {
                this.ResizeInnerArray();
            }

            this.elements[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void RemoveAt(int index)
        {
            for (int i = index; i < this.currentIndex - 1; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }

            this.elements[this.currentIndex - 1] = default(T);
            this.currentIndex--;
        }

        public void InsertAt(int index, T element)
        {
            if (index > this.currentIndex || index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "Index is out of range");
            }

            if (this.currentIndex == this.Capacity)
            {
                this.ResizeInnerArray();
            }

            for (int i = this.currentIndex; i > index; i--)
            {
                this.elements[i] = this.elements[i - 1];
            }

            this.elements[index] = element;
            this.currentIndex++;
        }

        public void Clear()
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                this.elements[i] = default(T);
            }

            this.currentIndex = 0;
        }

        public int IndexOf(T element)
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.currentIndex; i++)
            {
                if (this.elements[i].Equals(element))
                {
                    return true;
                }
            }

            return false;
        }

        public T Min()
        {
            T min = this.elements[0];
            for (int i = 1; i < this.currentIndex; i++)
            {
                if (this.elements[i].CompareTo(min) < 0)
                {
                    min = this.elements[i];
                }
            }

            return min;
        }

        public T Max()
        {
            T max = this.elements[0];
            for (int i = 1; i < this.currentIndex; i++)
            {
                if (this.elements[i].CompareTo(max) > 0)
                {
                    max = this.elements[i];
                }
            }

            return max;
        }

        public override string ToString()
        {
            return string.Join(", ", this.elements.Take(this.currentIndex));
        }

        private void ResizeInnerArray()
        {
            this.Capacity *= 2;
            var tempElements = new T[this.Capacity];
            for (int i = 0; i < this.elements.Length; i++)
            {
                tempElements[i] = this.elements[i];
            }

            this.elements = tempElements;
        }
    }
}