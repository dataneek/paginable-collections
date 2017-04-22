namespace PaginableCollections.Tests
{
    using System.Linq;
    using Xunit;

    public class StaticPagerTest
    {
        [Fact]
        public void ShouldNotBeNull()
        {
            var sut = Enumerable.Range(1, 10).ToPaginable(1, 5).ToPager(2);
        }
    }
}