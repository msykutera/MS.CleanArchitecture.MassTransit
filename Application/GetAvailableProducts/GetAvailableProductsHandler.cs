using Application.Common;
using MassTransit;
using Microsoft.EntityFrameworkCore;

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
        var products = await _dbContext.Products
            .Where(x => x.IsAvailable)
            .Select(product => new GetAvailableProductResult(product.Id, product.Name))
            .ToListAsync(context.CancellationToken);

        var result = new GetAvailableProductsResult(products);

        await context.RespondAsync(result);
    }
}
