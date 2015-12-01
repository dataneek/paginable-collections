namespace PaginableCollections
{
    using System;
    using System.Linq;

    public static class PaginableExtensions
    {
        public static IPaginable<T> ToPaginable<T>(this IQueryable<T> queryable, int pageNumber, int itemCountPerPage)
        {
            return new QueryableBasedPaginable<T>(queryable, pageNumber, itemCountPerPage);
        }
    }
}