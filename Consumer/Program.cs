using Application.Common;
using MassTransit;
using System.Reflection;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
        {
            x.AddConsumers(Assembly.GetAssembly(typeof(IAppDbContext)));
            x.UsingRabbitMq();
        });
    })
    .Build();

host.Run();
