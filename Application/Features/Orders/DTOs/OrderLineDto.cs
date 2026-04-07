namespace Application.Features.Orders.DTOs;

public record OrderLineDto(Guid ProductId, int Quantity, decimal UnitPrice);
