using Application.Common;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AppDbContext : DbContext, IAppDbContext
{
    public DbSet<Order> Orders { get; set; }

    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions options) : base(options) { }
}