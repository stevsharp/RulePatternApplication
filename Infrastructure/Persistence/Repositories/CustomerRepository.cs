using Application.Common;

using Domain.Aggregates;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly WriteDbContext _db;
    public CustomerRepository(WriteDbContext db) => _db = db;

    public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken ct = default)
        => await _db.Customers.FirstOrDefaultAsync(c => c.Id == id, ct);
}
