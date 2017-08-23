namespace PaginableCollections
{
    using System.Collections.Generic;
    using System.Linq;

    public static class PaginableExtensions
    {
        /// <summary>
        /// Convert queryable to paginable.
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

        /// <summary>
        /// Convert queryable to paginable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="paginableInfo"></param>
        /// <returns></returns>
        public static IPaginable<T> ToPaginable<T>(this IQueryable<T> queryable, IPaginableRequest paginableRequest)
        {
            return queryable.ToPaginable(paginableRequest.PageNumber, paginableRequest.ItemCountPerPage);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paginable"></param>
        /// <param name="maximumPageNumberCount"></param>
        /// <returns></returns>
        public static IPager ToPager(this IPaginable paginable, int maximumPageNumberCount)
        {
            return new StaticPager(paginable, maximumPageNumberCount);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="pageNumber"></param>
        /// <param name="itemCountPerPage"></param>
        /// <returns></returns>
        internal static IEnumerable<IPaginableItem<T>> ToPaginableItemList<T>(this IEnumerable<T> t, int pageNumber, int itemCountPerPage)
        {
            var offset = (pageNumber - 1) * itemCountPerPage;
            var list = t as IList<T> ?? t.ToList();
            for (var i = 0; i < list.Count; i++)
            {
                yield return new PaginableItem<T>(list[i], offset + 1);
                offset++;
            }
        }
    }
}