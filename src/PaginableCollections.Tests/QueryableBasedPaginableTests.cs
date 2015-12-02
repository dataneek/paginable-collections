namespace PaginableCollections.Tests
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture, Category("QueryableBasedPaginable")]
    public class QueryableBasedPaginableTests
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
    }
}