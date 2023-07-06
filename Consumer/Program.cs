using MassTransit;
using Infrastructure;
using Application;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddInfrastructureServices();
        services.ConfigureConsumer();
    })
    .Build();

host.Run();
