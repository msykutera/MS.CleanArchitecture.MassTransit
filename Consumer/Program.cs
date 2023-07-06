using MassTransit;
using Infrastructure;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddInfrastructureServices();

        services.AddMassTransit(x =>
        {
            x.AddHandlers();
            x.AddTransport();
        });
    })
    .Build();

host.Run();
