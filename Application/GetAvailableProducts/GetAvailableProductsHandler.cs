using Application.Common;
using Application.Messages;
using MassTransit;

namespace Application.GetAvailableProducts;

internal class GetAvailableProductsHandler : IConsumer<GetAvailableProductsQuery>
{
    private readonly IAppDbContext _dbContext;

    public GetAvailableProductsHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task Consume(ConsumeContext<GetAvailableProductsQuery> context)
    {
        throw new NotImplementedException();
    }
}
