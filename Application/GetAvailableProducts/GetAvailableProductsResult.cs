namespace Application.GetAvailableProducts;

public record GetAvailableProductsResult(IEnumerable<GetAvailableProductResult> Products);

public record GetAvailableProductResult(int Id, string Name);
