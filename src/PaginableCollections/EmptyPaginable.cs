namespace PaginableCollections
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Represents an empty paginable collection.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EmptyPaginable<T> : StaticPaginable<T>
    {
        /// <summary>
        /// Create new empty paginable collection.
        /// </summary>
        public EmptyPaginable()
            : base(Enumerable.Empty<T>(), 1, 0, 0)
        {
        }
    }
}