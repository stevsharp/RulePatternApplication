namespace Domain.Aggregates;
public class Customer
{
    public Guid Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public bool IsVerified { get; private set; }
    public decimal CreditLimit { get; private set; }

    private Customer() { }

    public static Customer Create(Guid id, string name, bool isVerified, decimal creditLimit)
        => new() { Id = id, Name = name, IsVerified = isVerified, CreditLimit = creditLimit };
}
