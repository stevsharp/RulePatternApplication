using Application.Features.Orders.Queries;

using Domain.Aggregates;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public sealed class ReadDbContext : DbContext, IReadDbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

    public IQueryable<OrderSummaryView> OrderSummaries => Set<OrderSummaryView>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderSummaryView>(v =>
        {
            v.HasKey(x => x.OrderId);
            v.ToTable("OrderSummaries");
        });
    }
}

public class WriteDbContext(DbContextOptions<WriteDbContext> options) : DbContext(options)
{
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Customer> Customers => Set<Customer>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(o =>
        {
            o.HasKey(x => x.Id);
            o.Property(x => x.Status).HasMaxLength(50);
            o.HasMany(x => x.Lines).WithOne().OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Customer>(c =>
        {
            c.HasKey(x => x.Id);
            c.Property(x => x.Name).HasMaxLength(200);
        });

        modelBuilder.Entity<OrderLine>(l =>
        {
            l.HasKey(x => x.ProductId);
        });
    }
}


