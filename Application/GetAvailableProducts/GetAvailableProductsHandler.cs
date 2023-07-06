using Application.Common;
using MassTransit;

namespace Application.GetAvailableProducts;

public class GetAvailableProductsHandler : IConsumer<GetAvailableProductsQuery>
{
    private readonly IAppDbContext _dbContext;

    public GetAvailableProductsHandler(IAppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Consume(ConsumeContext<GetAvailableProductsQuery> context)
    {
        var result = new GetAvailableProductsResult { ProductName = "Testdsf3241!!!" };
        await context.RespondAsync(result);
    }
}
