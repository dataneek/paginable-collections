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
            var sut = new QueryableBasedPaginable<int>(source, 2, 10);

            sut.PageNumber.ShouldBeEquivalentTo(2);
        }
    }
}