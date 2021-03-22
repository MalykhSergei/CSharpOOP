namespace ListTask
{
    class ListItem<T>
    {
        public ListItem<T> Next { get; set; }

        public T Value { get; set; }

        public ListItem(T value)
        {
            Value = value;
        }

        public ListItem(T value, ListItem<T> next)
        {
            Value = value;
            Next = next;
        }
    }
}
