namespace PaginableCollections
{
    public class PaginableItem<T> : IPaginableItem<T>
    {
        private PaginableItem() { }

        public PaginableItem(T item, int itemNumber)
        {
            Item = item;
            ItemNumber = itemNumber;
        }

        public T Item { get; private set; }
        public int ItemNumber { get; private set; }
    }
}