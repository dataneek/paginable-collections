namespace PaginableCollections
{
    public class PaginableItem<T> : IPaginableItem<T>
    {
        private PaginableItem() { }

        public PaginableItem(T item, int itemNumber, int pageNumber, int itemCountPerPage)
        {
            Item = item;
            ItemNumber = itemNumber;
            PageNumber = pageNumber;
            ItemCountPerPage = itemCountPerPage;
        }

        public T Item { get; private set; }
        public int ItemNumber { get; private set; }
        public int PageNumber { get; private set; }
        public int ItemCountPerPage { get; private set; }
    }
}