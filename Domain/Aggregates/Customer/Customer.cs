namespace Domain.Aggregates;

public class Customer
{
    public decimal CreditLimit { get; internal set; }
    public bool IsVerified { get; internal set; }
}