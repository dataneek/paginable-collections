namespace PaginableCollections
{
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static IPaginable<T> ToPaginable<T>(this IEnumerable<T> enumerable, int pageNumber, int itemCountPerPage)
        {
            return 
                enumerable
                    .AsQueryable()
                    .ToPaginable(pageNumber, itemCountPerPage);
        }

        public static IPaginable<T> ToPaginable<T>(this IEnumerable<T> enumerable, IPaginableRequest paginableRequest)
        {
            return
                enumerable
                    .ToPaginable(paginableRequest.PageNumber, paginableRequest.ItemCountPerPage);
        }

        public static IPaginable<T> ToPaginable<T>(this IEnumerable<T> enumerable, int pageNumber, int itemCountPerPage, int totalItemCount)
        {
            //# If enumerable is EF Queryable instance, a '.ToList()' will force it to execute the SQL.
            return new StaticPaginable<T>(enumerable.ToList(), pageNumber, itemCountPerPage, totalItemCount);
        }
    }
}