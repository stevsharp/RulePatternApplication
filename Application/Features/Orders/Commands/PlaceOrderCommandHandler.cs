using Application.Common;

using Domain.Aggregates;
using Domain.RuleEngline;
using Domain.Rules;

using Infrastructure;

namespace Application.Features.Orders.Commands;

public class PlaceOrderCommandHandler(IOrderRepository orders, ICustomerRepository customers) : ICommandHandler<PlaceOrderCommand>
{
    private readonly IOrderRepository _orders = orders;
    private readonly ICustomerRepository _customers = customers;

    public async Task<Result> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
    {
        var customer = await _customers.GetByIdAsync(command.CustomerId, cancellationToken);
        if (customer is null)
            return Result.Failure("Customer not found.");

        var lines = command.Lines.Select(l => OrderLine.Create(l.ProductId, l.Quantity, l.UnitPrice));
        var order = Order.Draft(customer, lines);

        var rule = new OrderMinimumAmountRule(50m)
            .And(new CustomerVerifiedRule())
            .And(new CreditLimitRule());

        var validationResult = rule.ToResult(order);

        if (validationResult.IsFailure)
            return validationResult;

        order.Place();
        await _orders.AddAsync(order, cancellationToken);
        return Result.Success();
    }

}