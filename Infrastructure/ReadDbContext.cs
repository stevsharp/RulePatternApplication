using Application.Features.Orders.Queries;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public sealed class ReadDbContext : DbContext, IReadDbContext
{
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options) { }

    public IQueryable<OrderSummaryView> OrderSummaries => Set<OrderSummaryView>().AsNoTracking();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderSummaryView>(v =>
        {
            v.HasKey(x => x.OrderId);
            v.ToTable("OrderSummaries");
        });
    }
}


