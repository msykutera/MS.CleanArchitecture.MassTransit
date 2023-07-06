using Application.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using System.Reflection;

namespace Infrastructure;

public static class Configure
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("CleanArchitectureDb"));
        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped<AppDbContextInitialiser>();

        return services.AddMassTransit(config =>
        {
            config.AddConsumers(Assembly.GetAssembly(typeof(IAppDbContext)));
            config.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("default", endpoint =>
                {
                    endpoint.ConfigureConsumers(context);
                });
                cfg.ConfigureEndpoints(context);
            });
        });
    }
}
