namespace PaginableCollections
{
    public interface IPagerItem
    {
        int PageNumber { get; }
        int TotalPageCount { get; }

        bool IsFirstPage { get; }
        bool IsLastPage { get; }

        bool HasPreviousPage { get; }
        bool HasNextPage { get; }
    }
}