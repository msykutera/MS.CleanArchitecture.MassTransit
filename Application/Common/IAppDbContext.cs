using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Common;

public interface IAppDbContext
{
    DbSet<Order> Orders { get; }

    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
