using Domain.Aggregates;

using Infrastructure.RuleEngline;

namespace Domain.Rules;

public class OrderMinimumAmountRule(decimal minimum) : BaseRule<Order>
{
    private readonly decimal _minimum = minimum;

    public override bool IsSatisfiedBy(Order order) =>
        order.TotalAmount >= _minimum;

    public override string ErrorMessage =>
        $"Order must be at least {_minimum:C}.";
}

public class CustomerVerifiedRule : BaseRule<Order>
{
    public override bool IsSatisfiedBy(Order order) =>
        order.Customer.IsVerified;

    public override string ErrorMessage =>
        "Customer account must be verified.";
}

public class CreditLimitRule : BaseRule<Order>
{
    public override bool IsSatisfiedBy(Order order) =>
        order.TotalAmount <= order.Customer.CreditLimit;

    public override string ErrorMessage =>
        "Order exceeds available credit limit.";
}