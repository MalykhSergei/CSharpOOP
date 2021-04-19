using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private const int DefaultArrayLength = 10;

        private readonly List<T>[] lists;
        private int changesCount;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable() : this(DefaultArrayLength)
        {

        }

        public HashTable(int arrayLength)
        {
            if (arrayLength < 1)
            {
                throw new ArgumentException($"{nameof(arrayLength)} = {arrayLength}. It must be greater than 0", nameof(arrayLength));
            }

            lists = new List<T>[arrayLength];
        }

        private int GetIndex(T item)
        {
            if (item == null)
            {
                return 0;
            }

            return Math.Abs(item.GetHashCode() % lists.Length);
        }

        public void Add(T item)
        {
            int index = GetIndex(item);

            if (lists[index] == null)
            {
                lists[index] = new List<T> { item };
            }
            else
            {
                lists[index].Add(item);
            }

            Count++;
            changesCount++;
        }

        public void Clear()
        {
            if (Count > 0)
            {
                Array.Clear(lists, 0, Count);

                Count = 0;
                changesCount++;
            }
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            return lists[index] != null && lists[index].Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Array is empty");
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"{nameof(arrayIndex)} = {arrayIndex}. Index outside the bounds of the array");
            }

            if (arrayIndex + Count > array.Length)
            {
                throw new ArgumentException("Insufficient size of the transmitted array");
            }

            int i = arrayIndex;

            foreach (T item in this)
            {
                array[i] = item;
                i++;
            }
        }

        public bool Remove(T item)
        {
            int index = GetIndex(item);

            if (lists[index] == null)
            {
                return false;
            }

            if (lists[index].Remove(item))
            {
                Count--;
                changesCount++;

                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int initialChangesCount = changesCount;

            foreach (List<T> list in lists)
            {
                if (list != null)
                {
                    foreach (T item in list)
                    {
                        if (initialChangesCount != changesCount)
                        {
                            throw new InvalidOperationException("The hash table was changed during iteration");
                        }

                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < lists.Length; i++)
            {
                sb.Append(i).Append(": ");

                if (lists[i] == null)
                {
                    sb.Append("null");
                }
                else
                {
                    sb.Append(string.Join(", ", lists[i]));
                }

                sb.Append(Environment.NewLine);
            }

            sb.Remove(sb.Length - 1, 1);

            return sb.ToString();
        }
    }
}
