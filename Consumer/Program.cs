using Infrastructure;
using Infrastructure.Persistence;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services.AddInfrastructureServices())
    .Build();

using var scope = host.Services.CreateScope();
var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitialiser>();
await initialiser.TrySeedAsync();

host.Run();
