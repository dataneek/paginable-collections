namespace PaginableCollections.Tests
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture, Category("QueryablePaginable")]
    public class EnumerableQueryablePaginableTests
    {
        [Test]
        public void ShouldEqualPageNumber()
        {
            var source = Enumerable.Range(10, 50);
            var expectedPageNumber = 2;

            var sut = source.ToPaginable(expectedPageNumber, itemCountPerPage: 10);

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Test]
        public void ShouldEqualItemCountPerPage()
        {
            var source = Enumerable.Range(11, 100);
            var expectedItemCountPerPage = 12;

            var sut = source.ToPaginable(2, expectedItemCountPerPage);

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }

        [Test]
        public void ShouldEqualTotalItemCount()
        {
            var expectedTotalItemCount = 25;
            var source = Enumerable.Range(11, expectedTotalItemCount);

            var sut = source.ToPaginable(2, 10);

            sut.TotalItemCount.ShouldBeEquivalentTo(expectedTotalItemCount);
        }
    }
}