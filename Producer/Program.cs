using MassTransit;
using Application;
using Application.GetAvailableProducts;
using Application.CreateOrder;

var bus = Bus.Factory.CreateUsingRabbitMq();

try
{
    await bus.StartAsync();

    var products = await GetAvailableProducts();

    var productNames = products.Select(x => x.Name);
    Console.WriteLine(string.Join(", ", productNames));

    var order = await CreateOrder(products);

    if (order.Success)
        Console.WriteLine($"Succesfully created order with Id {order.Id}.");
    else
        Console.WriteLine("Creating order failed.");
}
finally
{
    await bus.StopAsync();
}

async Task<IEnumerable<GetAvailableProductResult>> GetAvailableProducts()
{
    var client = bus.CreateRequestClient<GetAvailableProductsQuery>(new Uri("exchange:default"));
    var response = await client.GetResponse<GetAvailableProductsResult>(new GetAvailableProductsQuery());
    return response.Message.Products;
}

async Task<CreateOrderResult> CreateOrder(IEnumerable<GetAvailableProductResult> products)
{
    var client = bus.CreateRequestClient<CreateOrderCommand>(new Uri("exchange:default"));
    var productIds = products.Select(x => x.Id);
    var response = await client.GetResponse<CreateOrderResult>(new CreateOrderCommand(productIds));
    return response.Message;
}