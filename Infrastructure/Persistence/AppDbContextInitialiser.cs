using Domain;

namespace Infrastructure.Persistence;

public class AppDbContextInitialiser
{
    private readonly AppDbContext _context;

    public AppDbContextInitialiser(AppDbContext context)
    {
        _context = context;
    }

    public async Task TrySeedAsync()
    {
        if (!_context.Products.Any())
        {
            var products = new List<Product>
            {
                new Product(1, "Ladder", true),
                new Product(1, "Chess set", true),
                new Product(1, "Barbell", false)
            };

            _context.Products.AddRange(products);

            await _context.SaveChangesAsync();
        }
    }
}
