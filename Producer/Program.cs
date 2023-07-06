using MassTransit;
using Application;
using Application.GetAvailableProducts;

var bus = Bus.Factory.CreateUsingRabbitMq();

try
{
    var client = bus.CreateRequestClient<GetAvailableProductsQuery>(new Uri("exchange:default"));
    await bus.StartAsync();
    var response = await client.GetResponse<GetAvailableProductsResult>(new GetAvailableProductsQuery());

    Console.WriteLine(response.Message.ProductName);
}
finally
{
    await bus.StopAsync();
}