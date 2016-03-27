namespace PaginableCollections
{
    using System;
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
    }
}