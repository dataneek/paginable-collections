namespace PaginableCollections.Tests
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture, Category("PaginableUtilities")]
    public class PaginableUtilitiesTests
    {
        [Test]
        public void CountEqualsZero()
        {
            var expectedCount = 0;
            var sut = Paginable.EmptyPaginable<object>();

            sut.Count().ShouldBeEquivalentTo(expectedCount);
        }
    }
}
