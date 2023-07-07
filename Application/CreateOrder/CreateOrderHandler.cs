using Application.Common;
using Domain;
using MassTransit;
using Microsoft.EntityFrameworkCore;

namespace Application.CreateOrder;

public class CreateOrderHandler : IConsumer<CreateOrderCommand>
{
    private readonly IAppDbContext _dbContext;

    public CreateOrderHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<CreateOrderCommand> context)
    {
        var products = await _dbContext.Products
            .Where(x => context.Message.ProductIds.Contains(x.Id))
            .ToListAsync(context.CancellationToken);

        var order = new Order
        {
            Created = DateTime.UtcNow,
            Products = products
        };

        _dbContext.Orders.Add(order);
        await _dbContext.SaveChangesAsync(context.CancellationToken);
    }
}