using Infrastructure;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddInfrastructureServices())
    .Build();

host.Run();
