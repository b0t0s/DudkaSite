using Microsoft.EntityFrameworkCore;
using Site.Server.Domain.Entities;

namespace Site.Server.Domain;

public class SiteDbContext : DbContext
{
    public SiteDbContext(DbContextOptions<SiteDbContext> options) : base(options)
    {
    }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Customer> Clients { get; set; }

    public DbSet<Shop> Places { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) optionsBuilder.UseInMemoryDatabase("ShopSite");
    }
}