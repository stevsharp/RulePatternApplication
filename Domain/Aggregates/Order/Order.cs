namespace Domain.Aggregates;

public sealed class Order
{
    public Guid Id { get; private set; }
    public Customer Customer { get; private set; } = null!;
    public decimal TotalAmount { get; private set; }
    public string Status { get; private set; } = "Draft";

    private readonly List<OrderLine> _lines = new();
    public IReadOnlyList<OrderLine> Lines => _lines.AsReadOnly();

    private Order() { }

    public static Order Draft(Customer customer, IEnumerable<OrderLine> lines)
    {
        var order = new Order { Id = Guid.NewGuid(), Customer = customer };
        order._lines.AddRange(lines);
        order.TotalAmount = order._lines.Sum(l => l.Total);
        return order;
    }

    public void Place() => Status = "Placed";
    public void Cancel() => Status = "Cancelled";
}