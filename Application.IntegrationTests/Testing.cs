using Application.Common;
using Infrastructure;
using Infrastructure.Persistence;
using MassTransit;
using MassTransit.Testing;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.IntegrationTests;

[SetUpFixture]
public partial class Testing
{
    private ServiceProvider _provider;

    public ITestHarness Harness = null!;

    [OneTimeSetUp]
    public async Task RunBeforeAnyTests()
    {
        _provider = new ServiceCollection()
            .AddInfrastructureServices()
            .AddMassTransitTestHarness(config =>
            {
                config.AddConsumers(Assembly.GetAssembly(typeof(IAppDbContext)));
            })
            .BuildServiceProvider(true);

        using var scope = _provider.CreateScope();

        var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();

        await initialiser.TrySeedAsync();

        Harness = _provider.GetRequiredService<ITestHarness>();

        await Harness.Start();
    }

    [OneTimeTearDown]
    public async Task RunAfterAnyTests()
    {
        await _provider.DisposeAsync();
        await Harness.Stop();
    }
}