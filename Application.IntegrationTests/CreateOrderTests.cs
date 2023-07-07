using Application.CreateOrder;
using FluentAssertions;

namespace Application.IntegrationTests
{
    [TestFixture]
    public class CreateOrderTests : Testing
    {
        [Test]
        public async Task CreateOrderShouldSucceed()
        {
            var client = Harness.GetRequestClient<CreateOrderCommand>();
            var command = new CreateOrderCommand(new List<int> { 1, 2 });
            var response = await client.GetResponse<CreateOrderResult>(command);

            response.Message.Should().NotBeNull();
            response.Message.Success.Should().BeTrue();
            response.Message.Id.Should().BeGreaterThan(0);
        }
    }
}