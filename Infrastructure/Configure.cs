﻿using Application.Common;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;

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

    public static void ConfigureConsumer(this IBusRegistrationConfigurator config)
    {
        config.UsingRabbitMq((context, busFactoryConfigurator) =>
        {
            busFactoryConfigurator.ConfigureEndpoints(context);
        });
    }

    public static void ConfigureProducer(this IBusRegistrationConfigurator config)
    {
        config.UsingRabbitMq();
    }
}
