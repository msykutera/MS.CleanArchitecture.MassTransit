using MassTransit;
using Infrastructure;
using Application;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddInfrastructureServices();

        services.AddMassTransit(x =>
        {
            x.AddHandlers();
            x.ConfigureConsumer();
        });
    })
    .Build();

host.Run();
