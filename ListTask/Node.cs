namespace ListTask
{
    public class Node<T>
    {
        public Node<T> Next { get; set; }

        public T Value { get; set; }

        public Node(T value)
        {
            Next = null;
            Value = value;
        }

        public Node(T value, Node<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
