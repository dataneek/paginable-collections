namespace PaginableCollections.Tests
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture, Category("StaticPaginable")]
    public class StaticPaginableTests
    {
        [Test]
        public void ShouldEqualPageNumber()
        {
            var source = Enumerable.Range(11, 20);
            var sut = new StaticPaginable<int>(source, 2, 10, 100);

            sut.PageNumber.ShouldBeEquivalentTo(2);
        }

        [Test]
        public void ShouldEqualItemCountPerPage()
        {
            var source = Enumerable.Range(11, 20);
            var sut = new StaticPaginable<int>(source, 2, 10, 100);

            sut.ItemCountPerPage.ShouldBeEquivalentTo(10);
        }

        [Test]
        public void ShouldEqualTotalItemCount()
        {
            var source = Enumerable.Range(11, 20);
            var sut = new StaticPaginable<int>(source, 2, 10, 100);

            sut.TotalItemCount.ShouldBeEquivalentTo(100);
        }
    }
}