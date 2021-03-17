using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    class ArrayList<T> : IList<T>
    {
        private T[] array;
        private int changesCount;

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return array.Length;
            }
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException("The new list size must be greater than the number of items");
                }

                if (value != Count)
                {
                    T[] temp = array;
                    array = new T[value];
                    Array.Copy(temp, array, Count);
                }
            }
        }

        public ArrayList() : this(10) { }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException($"Capacity = {capacity}. It must be greater than or equal to 0", nameof(capacity));
            }

            if (capacity == 0)
            {
                array = new T[0];
            }
            else
            {
                array = new T[capacity];
            }
        }

        private void CheckIndex(int index)
        {
            if ((index < 0) || (index >= Count))
            {
                throw new ArgumentOutOfRangeException($"Index = { index }.Index must be in range(0; {Count})", nameof(index));
            }
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return array[index];
            }
            set
            {
                CheckIndex(index);

                array[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Equals(array[i], item))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            if ((index < 0) || (index > Count))
            {
                throw new ArgumentException($"Index = {index}. It must be in range (0; {Count})", nameof(index));
            }

            if (Count >= array.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(array, index, array, destinationIndex: index + 1, length: Count - index);

            array[index] = item;

            Count++;
            changesCount++;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index);

            Array.Copy(array, index + 1, array, index, Count - index - 1);

            array[Count - 1] = default;

            Count--;
            changesCount++;
        }

        public void Add(T item)
        {
            if (Count >= array.Length)
            {
                IncreaseCapacity();
            }

            array[Count] = item;

            Count++;
            changesCount++;
        }

        private void IncreaseCapacity()
        {
            T[] old = array;
            array = new T[old.Length * 2];
            Array.Copy(old, 0, array, 0, old.Length);
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(array, 0, Count);

                Count = 0;
            }

            changesCount++;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is empty");
            }

            if (arrayIndex < 0 || arrayIndex + Count > array.Length)
            {
                throw new ArgumentOutOfRangeException("The index is outside the list", nameof(arrayIndex));
            }

            Array.Copy(this.array, 0, array, arrayIndex, Count);
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);

            if (index != -1)
            {
                RemoveAt(index);

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int currentChangesCount = changesCount;

            for (int i = 0; i < Count; i++)
            {
                if (changesCount != currentChangesCount)
                {
                    throw new InvalidOperationException("You cannot change the number of items in the collection during the iterator pass");
                }

                yield return array[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void TrimToSize()
        {
            if (Count != Capacity)
            {
                T[] oldCapacity = array;
                array = new T[Count];
                Array.Copy(oldCapacity, array, Count);
            }
        }

        public void EnsureCapacity(int newCapacity)
        {
            if (array.Length < newCapacity)
            {
                T[] newArray = array;
                array = new T[newCapacity];

                Array.Copy(newArray, array, Count);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            for (int i = 0; i < Count; ++i)
            {
                sb.Append(array[i]).Append(",");
            }

            if (Count > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }

            return sb.Append("]").ToString();
        }
    }
}