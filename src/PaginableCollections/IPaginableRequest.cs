namespace PaginableCollections
{
    public interface IPaginableRequest
    {
        int PageNumber { get; }
        int ItemCountPerPage { get; }
    }
}