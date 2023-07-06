using MassTransit;
using Application;
using Application.GetAvailableProducts;

var bus = Bus.Factory.CreateUsingRabbitMq();

try
{
    var client = bus.CreateRequestClient<GetAvailableProductsQuery>(new Uri("exchange:default"));
    await bus.StartAsync();
    var response = await client.GetResponse<GetAvailableProductsResult>(new GetAvailableProductsQuery());
    var productNames = response.Message.Products.Select(x => x.Name);

    Console.WriteLine(string.Join(", ", productNames));
}
finally
{
    await bus.StopAsync();
}