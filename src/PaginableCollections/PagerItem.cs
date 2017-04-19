namespace PaginableCollections
{
    public class PagerItem: IPagerItem
    {
        public PagerItem(int pageNumber, int totalPageCount)
        {
            this.PageNumber = pageNumber;
            this.TotalPageCount = totalPageCount;
        }

        public int PageNumber { get; private set; }
        public int TotalPageCount { get; private set; }

        public bool IsFirstPage => PageNumber == 1;
        public bool IsLastPage => PageNumber >= TotalPageCount;

        public bool HasPreviousPage => PageNumber > 1;
        public bool HasNextPage => PageNumber < TotalPageCount;
    }
}