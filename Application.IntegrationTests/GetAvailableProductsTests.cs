using Application.GetAvailableProducts;
using FluentAssertions;

namespace Application.IntegrationTests
{
    [TestFixture]
    public class GetAvailableProductsTests : Testing
    {
        [Test]
        public async Task GetAvailableProductsShouldProperlyReturnResults()
        {
            var client = Harness.GetRequestClient<GetAvailableProductsQuery>();

            var response = await client.GetResponse<GetAvailableProductsResult>(new());

            response.Message.Products.Should().NotBeEmpty();
        }
    }
}