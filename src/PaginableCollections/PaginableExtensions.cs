namespace PaginableCollections
{
    using System;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>
    public static class PaginableExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="pageNumber"></param>
        /// <param name="itemCountPerPage"></param>
        /// <returns></returns>
        public static IPaginable<T> ToPaginable<T>(this IQueryable<T> queryable, int pageNumber, int itemCountPerPage)
        {
            return new QueryableBasedPaginable<T>(queryable, pageNumber, itemCountPerPage);
        }
    }
}