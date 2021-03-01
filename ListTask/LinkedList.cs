using System;
using System.Text;

namespace ListTask
{
    public class LinkedList<T>
    {
        private Node<T> head = null;
        private Node<T> lastNode = null;
        private int size = 0;

        public int Size => size;

        public Node<T> Head => head;

        public Node<T> LastNode => lastNode;

        public LinkedList() { }

        public LinkedList(Node<T> head, int size)
        {
            this.head = head;
            this.size = size;
        }

        private void CheckListIsEmpty()
        {
            if (head == null)
            {
                throw new NullReferenceException("List is empty!");
            }
        }

        private void CheckIndex(int index)
        {
            if (index < 0 || index >= Size)
            {
                throw new ArgumentException($"Index = {index}. It must have range [0; {Size})", nameof(index));
            }
        }

        public void Add(T value)
        {
            Node<T> newNode = new Node<T>(value);

            size++;

            if (head == null)
            {
                head = newNode;
            }
            else
            {
                lastNode.Next = newNode;
            }

            lastNode = newNode;
        }

        public T GetFirstElement()
        {
            return head.Value;
        }

        public Node<T> GetNode(int index)
        {
            CheckListIsEmpty();
            CheckIndex(index);

            int count = -1;

            for (Node<T> p = head; p != null; p = p.Next)
            {
                count++;

                if (count == index)
                {
                    return p;
                }
            }

            return null;
        }

        public T this[int index]
        {
            get
            {
                CheckListIsEmpty();
                CheckIndex(index);

                return GetNode(index).Value;
            }
        }

        public T SetValue(int index, T value)
        {
            CheckListIsEmpty();
            CheckIndex(index);

            Node<T> node = GetNode(index);

            T oldValue = node.Value;
            node.Value = value;

            return oldValue;
        }

        public T RemoveElement(int index)
        {
            CheckListIsEmpty();
            CheckIndex(index);

            if (index == 0)
            {
                T removeNodeValue = head.Value;
                head = head.Next;
                size--;

                return removeNodeValue;
            }

            Node<T> previousNode = GetNode(index - 1);
            Node<T> removeNode = previousNode.Next;
            previousNode.Next = removeNode.Next;

            if (index == size - 1)
            {
                lastNode = previousNode;
            }

            size--;

            return removeNode.Value;
        }

        public void AddFirstElement(T value)
        {
            if (head == null)
            {
                head = new Node<T>(value);
                lastNode = head;
            }
            else
            {
                head = new Node<T>(value, head);
            }

            size++;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > size)
            {
                throw new ArgumentException($"Index = {index}. It must have range [0; {size}]", nameof(index));
            }

            if (index == 0)
            {
                AddFirstElement(value);
                return;
            }

            if (index == size)
            {
                lastNode.Next = new Node<T>(value, null);
            }
            else
            {
                Node<T> previousNode = GetNode(index - 1);
                previousNode.Next = new Node<T>(value, previousNode.Next);
            }

            size++;
        }

        public bool RemoveNode(T value)
        {
            int count = 0;

            for (Node<T> p = head; p != null; p = p.Next)
            {
                if (Equals(p.Value, value))
                {
                    RemoveElement(count);

                    return true;
                }

                count++;
            }

            return false;
        }

        public T RemoveFirstElement()
        {
            CheckListIsEmpty();

            T value = head.Value;
            head = head.Next;

            size--;

            return value;
        }

        public void Reverse()
        {
            int i = 0;
            Node<T> node = head;
            Node<T> nextNode = head.Next;
            lastNode = head;

            while (i < size)
            {
                if (i == size - 1)
                {
                    head.Next = null;
                    head = node;

                    break;
                }
                else
                {
                    Node<T> previousNode = node;
                    node = nextNode;
                    nextNode = node.Next;
                    node.Next = previousNode;

                    i++;
                }
            }
        }

        public LinkedList<T> Copy()
        {
            LinkedList<T> list = new LinkedList<T>();

            Node<T> node = head;

            int i = 0;

            while (i < size)
            {
                list.Add(node.Value);
                node = node.Next;

                i++;
            }

            return list;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;

            Node<T> node = head;

            while (i < size)
            {
                sb.Append(node.Value);
                sb.Append(Environment.NewLine);
                node = node.Next;

                i++;
            }

            return sb.ToString();
        }
    }
}
