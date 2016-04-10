namespace PaginableCollections.Tests
{
    using System;
    using System.Linq;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture, Category("PaginableInfo")]
    public class PaginableInfoTests
    {
        [Test]
        public void ShouldEqualPageNumber()
        {
            var expectedPageNumber = 2;
            var sut = new PaginableInfo(expectedPageNumber, 10);

            sut.PageNumber.ShouldBeEquivalentTo(expectedPageNumber);
        }

        [Test]
        public void ShouldEqualItemCountPerPage()
        {
            var expectedItemCountPerPage = 12;
            var sut = new PaginableInfo(2, expectedItemCountPerPage);

            sut.ItemCountPerPage.ShouldBeEquivalentTo(expectedItemCountPerPage);
        }
    }
}