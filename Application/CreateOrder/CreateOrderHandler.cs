using Application.Common;
using Application.Messages;
using MassTransit;

namespace Application.CreateOrder;

public class CreateOrderHandler : IConsumer<CreateOrderCommand>
{
    private readonly IAppDbContext _dbContext;

    public CreateOrderHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Consume(ConsumeContext<CreateOrderCommand> context)
    {
        throw new NotImplementedException();
    }
}