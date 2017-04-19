namespace PaginableCollections
{
    public class PaginableItem<T> : IPaginableItem<T>
    {
        private PaginableItem() { }

        public PaginableItem(T item, int itemNumber)
        {
            this.Item = item;
            this.ItemNumber = itemNumber;
        }

        public T Item { get; private set; }
        public int ItemNumber { get; private set; }
    }
}