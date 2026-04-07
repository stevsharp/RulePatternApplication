using Infrastructure;

using Microsoft.EntityFrameworkCore;

namespace Application.Features.Orders.Queries;


public interface IReadDbContext
{
    IQueryable<OrderSummaryView> OrderSummaries { get; }
}

public record OrderSummaryDto(
    Guid OrderId,
    string CustomerName,
    decimal TotalAmount,
    string Status
);


public class OrderSummaryView
{
    public Guid OrderId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class GetOrderSummaryQueryHandler : IQueryHandler<GetOrderSummaryQuery, OrderSummaryDto>
{
    private readonly IReadDbContext _db;

    public GetOrderSummaryQueryHandler(IReadDbContext db) => _db = db;

    public async Task<OrderSummaryDto?> HandleAsync(GetOrderSummaryQuery query, CancellationToken ct = default)
    {
        return await _db.OrderSummaries
            .Where(o => o.OrderId == query.OrderId)
            .Select(o => new OrderSummaryDto(o.OrderId, o.CustomerName, o.TotalAmount, o.Status))
            .FirstOrDefaultAsync(ct);
    }
}

