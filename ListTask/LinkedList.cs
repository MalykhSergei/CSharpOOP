using System;
using System.Text;

namespace ListTask
{
    class LinkedList<T>
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
            CheckListIsEmpty();

            return head.Value;
        }

        private ListItem<T> GetNode(int index)
        {
            CheckIndex(index);

            if (index == Count - 1)
            {
                return lastNode;
            }

            ListItem<T> node = head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node;
        }

        public void Add(T value)
        {
            ListItem<T> newNode = new ListItem<T>(value);

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                lastNode.Next = newNode;
            }

            lastNode = newNode;

            Count++;
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index);

                return GetNode(index).Value;
            }
            set
            {
                CheckIndex(index);

                ListItem<T> node = GetNode(index);

                node.Value = value;
            }
        }

        public T RemoveByIndex(int index)
        {
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
                Add(value);

                return;
            }

            ListItem<T> node = GetNode(index - 1);
            ListItem<T> newNode = new ListItem<T>(value)
            {
                Next = node.Next
            };

            node.Next = newNode;

            Count++;
        }

        public bool RemoveByValue(T value)
        {
            if (Count == 0)
            {
                return false;
            }

            ListItem<T> node = head;

            for (int i = 0; i < Count; i++)
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
            if (head == null)
            {
                return;
            }

            ListItem<T> node = head;
            ListItem<T> previousNext = null;

            while (node != null)
            {
                ListItem<T> temp = node.Next;

                node.Next = previousNext;
                previousNext = node;
                node = temp;
            }

            head = previousNext;
        }

        public LinkedList<T> Copy()
        {
            LinkedList<T> copyList = new LinkedList<T>();

            if (head == null)
            {
                return copyList;
            }

            ListItem<T> node = head;

            ListItem<T> newNode = new ListItem<T>(node.Value);
            copyList.head = newNode;

            while (node.Next != null)
            {
                newNode.Next = new ListItem<T>(node.Next.Value);
                newNode = newNode.Next;
                node = node.Next;
            }

            copyList.Count = Count;

            return copyList;
        }

        public override string ToString()
        {
            if (head == null)
            {
                return "[]";
            }

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
