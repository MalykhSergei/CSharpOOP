namespace ListTask
{
    public partial class LinkedList<T>
    {
        private class ListItem<E>
        {
            public ListItem<E> Next { get; set; }

            public E Value { get; set; }

            public ListItem() { }

            public ListItem(E value)
            {
                Value = value;
            }

            public ListItem(E value, ListItem<E> next)
            {
                Value = value;
                Next = next;
            }
        }
    }
}
