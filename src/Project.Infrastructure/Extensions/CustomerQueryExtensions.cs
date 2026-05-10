using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Infrastructure.Persistence;

namespace Project.Infrastructure.Extensions;

public static class CustomerQueryExtensions
{
    public static async Task<Customer?> GetCustomerById(this ApplicationDbContext dbContext, Guid id, CancellationToken cancellationToken)
    {
       return await dbContext.Customers
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public static async Task<List<Customer>> GetCustomersAsync(this ApplicationDbContext dbContext, CancellationToken cancellationToken)
    {
        return await dbContext.Customers
            .AsNoTracking()
            .OrderBy(x => x.CreatedAtUtc)
            .ToListAsync(cancellationToken);
    }
}