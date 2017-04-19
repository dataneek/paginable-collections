namespace PaginableCollections
{
    using System.Collections.Generic;

    public interface IPager
    {
        IEnumerable<IPagerItem> GetPages();

        int TotalPageCount { get; }
        int MaximumPageNumberCount { get; }
    }
}