using Infrastructure;

namespace Application.Features.Orders.Queries;

public record GetOrderSummaryQuery(Guid OrderId) : IQuery<OrderSummaryDto>;
