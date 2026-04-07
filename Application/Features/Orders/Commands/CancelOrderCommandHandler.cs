using Application.Common;

using Infrastructure;

namespace Application.Features.Orders.Commands;

public class CancelOrderCommandHandler(IOrderRepository orders) : ICommandHandler<CancelOrderCommand>
{
    private readonly IOrderRepository _orders = orders;

    public async Task<Result> Handle(CancelOrderCommand command, CancellationToken cancellationToken)
    {
        var order = await _orders.GetByIdAsync(command.OrderId, cancellationToken);
        if (order is null)
            return Result.Failure("Order not found.");

        order.Cancel();
        await _orders.UpdateAsync(order, cancellationToken);
        return Result.Success();
    }
}
