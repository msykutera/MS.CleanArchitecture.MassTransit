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
                new Product("Ladder") { IsAvailable = false },
                new Product("Chess set") { IsAvailable = true },
                new Product("Barbell") { IsAvailable = true }
            };

            _context.Products.AddRange(products);

            await _context.SaveChangesAsync();
        }
    }
}
