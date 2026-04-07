using Infrastructure;

namespace Application.Features.Orders.Commands;

public record CancelOrderCommand(Guid OrderId) : ICommand;
