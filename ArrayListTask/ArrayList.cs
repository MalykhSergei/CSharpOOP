using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayListTask
{
    public class ArrayList<T> : IList<T>
    {
        private const int DefaultCapacity = 4;

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
                    throw new ArgumentOutOfRangeException(nameof(value),
                        $"{nameof(value)} = {value}, {nameof(Count)} = {Count}. The new list size must be greater than the number of items");
                }

                Array.Resize(ref array, value);
            }
        }

        public ArrayList() : this(DefaultCapacity) { }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), $"{nameof(capacity)} = {capacity}. It must be greater than or equal to 0");
            }

            array = new T[capacity];
        }

        private void CheckIndex(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"{nameof(index)} = {index}. Index must be greater than or equal 0");
            }

            if (index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"{nameof(index)} = {index}. Index must be less than {Count}");
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
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"{nameof(index)} = {index}. Index must be greater than or equal to 0");
            }

            if (index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"{nameof(index)} = {index}. Index must be less than or equal to {Count}");
            }

            if (Count == Capacity)
            {
                IncreaseCapacity();
            }

            Array.Copy(array, index, array, index + 1, Count - index);

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
            Insert(Count, item);
        }

        private void IncreaseCapacity()
        {
            if (array.Length == 0)
            {
                Capacity = DefaultCapacity;

                return;
            }

            Capacity *= 2;
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(array, 0, Count);

                Count = 0;
                changesCount++;
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array is null");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"{nameof(arrayIndex)} is less than 0");
            }

            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException($"The length of the array = {array.Length}. It must be less than {Count + arrayIndex} - the number of items in the list plus the initial index of the array",
                    $"{nameof(arrayIndex)}, {nameof(array)}");
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
            int initialChangesCount = changesCount;

            for (int i = 0; i < Count; i++)
            {
                if (changesCount != initialChangesCount)
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
            Capacity = Count;
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "[]";
            }

            StringBuilder sb = new StringBuilder();

            sb.Append("[");

            foreach (T item in array)
            {
                if (item == null)
                {
                    sb.Append("null");
                }
                else
                {
                    sb.Append(item);
                }

                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);

            return sb.Append("]").ToString();
        }
    }
}