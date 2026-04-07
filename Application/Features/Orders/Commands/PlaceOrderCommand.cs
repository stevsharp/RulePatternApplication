using Application.Features.Orders.DTOs;

using Infrastructure;

namespace Application.Features.Orders.Commands;

public record PlaceOrderCommand(
    Guid CustomerId,
    List<OrderLineDto> Lines
) : ICommand;
