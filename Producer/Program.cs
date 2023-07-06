using MassTransit;
using Microsoft.Extensions.Hosting;
using Application;
using Microsoft.Extensions.DependencyInjection;
using Application.GetAvailableProducts;
using Infrastructure;

var bus = Bus.Factory.CreateUsingRabbitMq();

var client = bus.CreateRequestClient<GetAvailableProductsQuery>(new Uri("exchange:available-products"));
await bus.StartAsync();
var response = await client.GetResponse<GetAvailableProductsResult>(new GetAvailableProductsQuery());

Console.WriteLine(response.Message.ProductName);

await bus.StopAsync();