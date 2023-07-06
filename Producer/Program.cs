using MassTransit;
using Microsoft.Extensions.Hosting;
using Application;
using Microsoft.Extensions.DependencyInjection;
using Application.GetAvailableProducts;
using Infrastructure;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddMassTransit(x =>
        {
            x.ConfigureProducer();
        });
    })
    .Build();

var client = host.Services.GetRequiredService<IRequestClient<GetAvailableProductsQuery>>();

var query = new GetAvailableProductsQuery();
var response = await client.GetResponse<GetAvailableProductsResult>(query);

Console.WriteLine(response.Message);