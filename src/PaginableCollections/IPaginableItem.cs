namespace PaginableCollections
{
    public interface IPaginableItem
    {
        int ItemNumber { get; }
        int PageNumber { get; }
        int ItemCountPerPage { get; }
    }

    public interface IPaginableItem<T> : IPaginableItem
    {
        T Item { get; }
    }
}