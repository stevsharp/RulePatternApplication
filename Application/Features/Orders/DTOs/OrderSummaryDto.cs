namespace Application.Features.Orders.DTOs;

public record OrderSummaryDto(
    Guid OrderId,
    string CustomerName,
    decimal TotalAmount,
    string Status
);
