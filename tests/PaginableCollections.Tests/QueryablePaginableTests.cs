namespace PaginableCollections.Tests
{
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture, Category("QueryablePaginable")]
    public class QueryablePaginableTests
    {
        [Test]
        public void ShouldEqualPageNumber()
        {
            var source = Enumerable.Range(10, 50).AsQueryable();
            var expectedPageNumber = 2;

            var sut = new QueryableBasedPaginable<int>(source, expectedPageNumber, 10);

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Test]
        public void ShouldEqualItemCountPerPage()
        {
            var source = Enumerable.Range(11, 100).AsQueryable();
            var expectedItemCountPerPage = 12;

            var sut = new QueryableBasedPaginable<int>(source, 2, expectedItemCountPerPage);

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }

        [Test]
        public void ShouldEqualTotalItemCount()
        {
            var expectedTotalItemCount = 25;
            var source = Enumerable.Range(11, expectedTotalItemCount).AsQueryable();

            var sut = new QueryableBasedPaginable<int>(source, 2, 10);

            sut.TotalItemCount.ShouldBeEquivalentTo(expectedTotalItemCount);
        }

        [Test]
        public void ShouldEqualFirstElementNextPage()
        {
            var source = Enumerable.Range(1, 100).AsQueryable();
            var paginable = new QueryableBasedPaginable<int>(source, 3, 10);

            var sut = paginable.ElementAt(0);

            sut.ItemNumber.ShouldBeEquivalentTo(21);
            sut.Item.ShouldBeEquivalentTo(21);
        }
    }
}