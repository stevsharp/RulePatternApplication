namespace Application.Features.Orders.Queries;

public record OrderSummaryDto(
    Guid OrderId,
    string CustomerName,
    decimal TotalAmount,
    string Status
);
