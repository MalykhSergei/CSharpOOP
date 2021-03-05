using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    class ArrayList<T> : IList<T>
    {
        private T[] array;
        private int count;
        private int changesCount;

        public ArrayList() : this(100) { }

        public ArrayList(int capacity)
        {
            array = new T[capacity];
        }

        public int Count => count;

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get
            {
                if ((index < 0) || (index >= count))
                {
                    throw new ArgumentException($"Index = {index}. It must be in range (0; {count}]", nameof(index));
                }

                return array[index];
            }
            set
            {
                if ((index < 0) || (index >= count))
                {
                    throw new ArgumentException($"Index = {index}. It must be in range (0; {count})", nameof(index));
                }

                array[index] = value;
            }
        }

        public int IndexOf(T item)
        {
            for (int i = 0; i < count; i++)
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
            if ((index < 0) || (index > count))
            {
                throw new ArgumentException($"Index = {index}. It must be in range (0; {count})", nameof(index));
            }

            if (count >= array.Length)
            {
                IncreaseCapacity();
            }

            Array.Copy(array, index, array, destinationIndex: index + 1, length: count - index);

            array[index] = item;

            count++;
            changesCount++;
        }

        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= count))
            {
                throw new ArgumentException($"Index = {index}. It must be in range (0; {count})", nameof(index));
            }

            Array.Copy(array, index + 1, array, index, count - index - 1);

            count--;
            changesCount++;
        }

        public void Add(T item)
        {
            if (count >= array.Length)
            {
                IncreaseCapacity();
            }

            array[count] = item;

            count++;
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
            count = 0;
            changesCount++;
        }

        public bool Contains(T item)
        {
            foreach (T e in array)
            {
                if (Equals(e, item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if ((arrayIndex < 0) || (arrayIndex >= array.Length))
            {
                throw new ArgumentException($"Index = {arrayIndex}. It must be in range (0; {count})", nameof(arrayIndex));
            }

            Array.Copy(this.array, 0, array, arrayIndex, count);
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

            for (int i = 0; i < count; i++)
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
            if (array.Length != count)
            {
                T[] trimArray = new T[count];
                CopyTo(trimArray, 0);
                array = new T[count];

                Array.Copy(trimArray, array, count);
            }
        }

        public void EnsureCapacity(int newCapacity)
        {
            if (array.Length < newCapacity)
            {
                T[] newArray = array;
                array = new T[newCapacity];

                Array.Copy(newArray, array, count);
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(array[0]);

            for (int i = 1; i < count; i++)
            {
                sb.Append(", ");
                sb.Append(array[i]);
            }

            return sb.ToString();
        }
    }
}