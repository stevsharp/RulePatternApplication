namespace Domain.Aggregates;

public sealed class OrderLine
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal Total => Quantity * UnitPrice;

    private OrderLine() { }

    public static OrderLine Create(Guid productId, int quantity, decimal unitPrice)
        => new() { ProductId = productId, Quantity = quantity, UnitPrice = unitPrice };
}