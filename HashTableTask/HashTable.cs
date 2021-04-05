using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HashTableTask
{
    public class HashTable<T> : ICollection<T>
    {
        private List<T>[] lists;
        private int changesCount;
        private const int defaultArrayLenght = 10;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable()
        {
            lists = new List<T>[defaultArrayLenght];
        }

        public HashTable(int arrayLenght)
        {
            if (arrayLenght < 1)
            {
                throw new ArgumentException($"{nameof(arrayLenght)} = 0. It must be greater than 0");
            }

            lists = new List<T>[arrayLenght];
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
            if (Count != 0)
            {
                for (int i = 0; i < lists.Length; i++)
                {
                    lists[i] = null;
                }

                changesCount++;
            }

            Count = 0;
        }

        public bool Contains(T item)
        {
            int index = GetIndex(item);

            if (lists[index] != null)
            {
                return lists[index].Contains(item);
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Array is empty");
            }
            else if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Index outside the bounds of the array");
            }
            else if (arrayIndex + Count > array.Length)
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
            int initialChanges = changesCount;

            foreach (var list in lists)
            {
                if (list != null)
                {
                    foreach (T item in list)
                    {
                        if (initialChanges != changesCount)
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
            if (lists.Length == 0)
            {
                throw new ArgumentException("Hashtable is empty!", nameof(Count));
            }

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

                if (i != lists.Length - 1)
                {
                    sb.Append(Environment.NewLine);
                }
            }

            return sb.ToString();
        }
    }
}
