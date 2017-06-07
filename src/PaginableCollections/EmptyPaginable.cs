namespace PaginableCollections
{
    using System.Linq;

    /// <summary>
    /// Represents an empty paginable collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EmptyPaginable<T> : StaticPaginable<T>
    {
        public const int DefaultItemCountPerPage = 10;

        /// <summary>
        /// Create new empty paginable collection.
        /// </summary>
        public EmptyPaginable()
            : base(Enumerable.Empty<T>(), 1, DefaultItemCountPerPage, 0)
        {
        }
    }
}