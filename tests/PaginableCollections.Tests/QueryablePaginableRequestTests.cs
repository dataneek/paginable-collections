namespace PaginableCollections.Tests
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture, Category("PaginableRequest")]
    public class QueryablePaginableRequestTests
    {
        [Test]
        public void ShouldEqualPageNumber()
        {
            var source = Enumerable.Range(10, 50).AsQueryable();
            var expectedPageNumber = 2;
            var paginableInfo = new PaginableRequest(expectedPageNumber, 10);

            var sut = source.ToPaginable(paginableInfo);

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Test]
        public void ShouldEqualItemCountPerPage()
        {
            var source = Enumerable.Range(11, 100).AsQueryable();
            var expectedItemCountPerPage = 12;
            var paginableInfo = new PaginableRequest(2, expectedItemCountPerPage);

            var sut = source.ToPaginable(paginableInfo);

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }
    }
}