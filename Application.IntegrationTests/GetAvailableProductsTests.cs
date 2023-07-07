using Application.Common;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Infrastructure;
using Application.GetAvailableProducts;
using FluentAssertions;
using Infrastructure.Persistence;

namespace Application.IntegrationTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task GetAvailableProductsShouldProperlyReturnResults()
        {
            await using var provider = new ServiceCollection()
                .AddInfrastructureServices()
                .AddMassTransitTestHarness(config =>
                {
                    config.AddConsumers(Assembly.GetAssembly(typeof(IAppDbContext)));
                })
                .BuildServiceProvider(true);

            using var scope = provider.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();

            await initialiser.TrySeedAsync();

            var harness = provider.GetRequiredService<ITestHarness>();

            await harness.Start();

            var client = harness.GetRequestClient<GetAvailableProductsQuery>();

            var response = await client.GetResponse<GetAvailableProductsResult>(new());

            response.Message.Products.Should().NotBeEmpty();
        }
    }
}