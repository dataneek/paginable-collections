namespace ConsoleAppDotNetCore
{
    using System;
    using System.Linq;
    using PaginableCollections;

    class Program
    {
        static void Main(string[] args)
        {
            var itemCountPerPage = 25;
            var pageNumber = 4;

            var paginable =
                Enumerable.Range(1, 200)
                    .ToPaginable(pageNumber, itemCountPerPage);

            Console.WriteLine(string.Format("page number {0}", pageNumber));
            Console.WriteLine(string.Format("item count per page {0}", itemCountPerPage));
            Console.WriteLine(string.Join(",", paginable.Select(t => t.Item)));
            Console.WriteLine(string.Format("showing items {0} to {1} of {2}", paginable.FirstItemNumber, paginable.LastItemNumber, paginable.TotalItemCount));
            Console.ReadLine();
        }
    }
}