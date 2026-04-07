using Application.Features.Orders.DTOs;

using Infrastructure;

namespace Application.Features.Orders.Commands;
/// <summary>
/// 
/// </summary>
/// <param name="CustomerId"></param>
/// <param name="Lines"></param>
public record PlaceOrderCommand(Guid CustomerId, List<OrderLineDto> Lines) : ICommand;
