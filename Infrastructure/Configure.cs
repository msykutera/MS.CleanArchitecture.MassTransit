using Application.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using Application.GetAvailableProducts;

namespace Infrastructure;

public static class Configure
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("CleanArchitectureDb"));
        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());
        services.AddScoped<AppDbContextInitialiser>();
        return services;
    }

    public static IServiceCollection ConfigureConsumer(this IServiceCollection services)
    {
        services.AddMassTransit(config =>
        {
            config.AddConsumer<GetAvailableProductsHandler>();
            config.UsingRabbitMq((context, cfg) =>
            {
                cfg.ReceiveEndpoint("available-products", endpoint =>
                {
                    endpoint.ConfigureConsumers(context);
                });
                cfg.ConfigureEndpoints(context);
            });
        });


        return services;
    }

    public static IServiceCollection ConfigureProducer(this IServiceCollection services)
    {
        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq();
        });
        return services;
    }
}
