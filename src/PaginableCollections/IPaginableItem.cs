namespace PaginableCollections
{
    public interface IPaginableItem<T>
    {
        T Item { get; }
        int ItemNumber { get; }
    }
}