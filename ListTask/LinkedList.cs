using System;
using System.Text;

namespace ListTask
{
    public partial class LinkedList<T>
    {
        private ListItem<T> head;
        private ListItem<T> lastNode;

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
            if (head == null)
            {
                throw new ArgumentNullException("List is empty");
            }

            return head.Value;
        }

        private ListItem<T> GetNode(int index)
        {
            CheckListIsEmpty();
            CheckIndex(index);

            int i = 0;

            ListItem<T> node = head;

            if (index == Count - 1)
            {
                return lastNode;
            }

            while (i < index)
            {
                node = node.Next;
                i++;
            }

            return node;
        }

        public void Add(T value)
        {
            ListItem<T> node = head;
            ListItem<T> tempNode = new ListItem<T>();

            if (head == null)
            {
                AddFirst(value);
            }
            else
            {
                tempNode.Value = value;
                tempNode.Next = null;

                while (node.Next != null)
                {
                    node = node.Next;
                }

                node.Next = tempNode;

                Count++;
            }
        }

        public T this[int index]
        {
            get
            {
                CheckListIsEmpty();
                CheckIndex(index);

                return GetNode(index).Value;
            }
            set
            {
                CheckListIsEmpty();
                CheckIndex(index);

                ListItem<T> node = GetNode(index);

                node.Value = value;
            }
        }

        public T RemoveByIndex(int index)
        {
            CheckListIsEmpty();
            CheckIndex(index);

            if (index == 0)
            {
                return RemoveFirst();
            }

            ListItem<T> previousNode = GetNode(index - 1);
            ListItem<T> removingNode = previousNode.Next;
            previousNode.Next = removingNode.Next;

            if (index == Count - 1)
            {
                lastNode = previousNode;
            }

            Count--;

            return removingNode.Value;
        }

        public void AddFirst(T value)
        {
            if (head == null)
            {
                head = new ListItem<T>(value);
                lastNode = head;
            }
            else
            {
                head = new ListItem<T>(value, head);
            }

            Count++;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new ArgumentException($"Index = {index}. It must have range [0; {Count}]", nameof(index));
            }

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            if (index == Count)
            {
                ListItem<T> lastItem = lastNode;
                lastItem.Next = new ListItem<T>(value, null);
            }
            else
            {
                ListItem<T> previousNode = GetNode(index - 1);
                previousNode.Next = new ListItem<T>(value, previousNode.Next);
            }

            Count++;
        }

        public bool RemoveByValue(T value)
        {
            ListItem<T> node = head;

            int i = 0;

            while (i < Count)
            {
                if (Equals(node.Value, value))
                {
                    if (i == 0)
                    {
                        head = head.Next;
                    }
                    else
                    {
                        ListItem<T> previousNode = GetNode(i - 1);
                        previousNode.Next = node.Next;
                    }

                    Count--;

                    return true;
                }

                i++;

                node = node.Next;
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
            ListItem<T> node = head;
            ListItem<T> previousNext = null;

            while (node != null)
            {
                ListItem<T> temp = node.Next;

                node.Next = previousNext;
                previousNext = node;
                head = node;
                node = temp;
            }
        }

        public LinkedList<T> Copy()
        {
            LinkedList<T> list = new LinkedList<T>();

            int count = 0;

            for (ListItem<T> p = head; p != null; p = p.Next)
            {
                list.Add(p.Value);

                count++;
            }

            return list;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            ListItem<T> node = head;

            sb.Append("[");
            sb.Append(head.Value);
            node = node.Next;

            for (int i = 1; i < Count; i++)
            {
                sb.Append(", ");
                sb.Append(node.Value);
                node = node.Next;
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
