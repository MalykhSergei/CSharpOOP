using System;
using System.Text;

namespace ListTask
{
    public class LinkedList<T>
    {
        private ListItem<T> head;

        public int Count { get; private set; }

        private void CheckListIsEmpty()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Index = {index}. It must have range [0; {Count})");
            }
        }

        public T GetFirst()
        {
            CheckListIsEmpty();

            return head.Value;
        }

        private ListItem<T> GetListItem(int index)
        {
            CheckIndex(index);

            ListItem<T> item = head;

            for (int i = 0; i < index; i++)
            {
                item = item.Next;
            }

            return item;
        }

        public void Add(T value)
        {
            Insert(Count, value);
        }

        public T this[int index]
        {
            get
            {
                return GetListItem(index).Value;
            }
            set
            {
                ListItem<T> item = GetListItem(index);

                item.Value = value;
            }
        }

        public T RemoveByIndex(int index)
        {
            CheckIndex(index);

            if (index == 0)
            {
                return RemoveFirst();
            }

            ListItem<T> previousItem = GetListItem(index - 1);
            ListItem<T> removingItem = previousItem.Next;
            previousItem.Next = removingItem.Next;

            Count--;

            return removingItem.Value;
        }

        public void AddFirst(T value)
        {
            head = new ListItem<T>(value, head);
            Count++;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Index = {index}. It must have range [0; {Count}]");
            }

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            ListItem<T> previousItem = GetListItem(index - 1);
            previousItem.Next = new ListItem<T>(value, previousItem.Next);

            Count++;
        }

        public bool RemoveByValue(T value)
        {
            if (head == null)
            {
                return false;
            }

            if (Equals(head.Value, value))
            {
                RemoveFirst();

                return true;
            }

            for (ListItem<T> item = head; item.Next != null; item = item.Next)
            {
                if (Equals(item.Next.Value, value))
                {
                    item.Next = item.Next.Next;
                    Count--;

                    return true;
                }
            }

            return false;
        }

        public T RemoveFirst()
        {
            CheckListIsEmpty();

            T value = head.Value;

            head = head.Next;
            Count--;

            return value;
        }

        public void Reverse()
        {
            if (head == null || Count == 1)
            {
                return;
            }

            ListItem<T> item = head;
            ListItem<T> previousNext = null;

            while (item != null)
            {
                ListItem<T> temp = item.Next;

                item.Next = previousNext;
                previousNext = item;
                item = temp;
            }

            head = previousNext;
        }

        public LinkedList<T> Copy()
        {
            LinkedList<T> listCopy = new LinkedList<T>();

            if (head == null)
            {
                return listCopy;
            }

            ListItem<T> item = head;

            ListItem<T> newItem = new ListItem<T>(item.Value);
            listCopy.head = newItem;

            while (item.Next != null)
            {
                newItem.Next = new ListItem<T>(item.Next.Value);
                newItem = newItem.Next;
                item = item.Next;
            }

            listCopy.Count = Count;

            return listCopy;
        }

        public override string ToString()
        {
            if (head == null)
            {
                return "[]";
            }

            ListItem<T> item = head;

            StringBuilder sb = new StringBuilder();

            sb.Append("[");
            sb.Append(item.Value);

            for (int i = 0; i < Count - 1; i++)
            {
                item = item.Next;

                sb.Append(", ");
                sb.Append(item.Value);
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
