using Microsoft.EntityFrameworkCore;
using Project.Domain.Entities;
using Project.Infrastructure.Persistence;

namespace Project.Infrastructure.Extensions;

public static class CustomerCommandExtensions
{
    public static async Task<Customer?> GetCustomerForUpdateById(this ApplicationDbContext dbContext, Guid id, CancellationToken cancellationToken)
    {
        return await dbContext.Customers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public static async Task<bool> DeleteCustomerById(this ApplicationDbContext dbContext, Guid id, CancellationToken cancellationToken)
    {
        var customer = await dbContext.Customers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        
        if (customer is null)
        {
            return false;
        }

        dbContext.Customers.Remove(customer);

        return true;
    }

    public static async Task CreateCustomer(this ApplicationDbContext dbContext, Customer customer,
        CancellationToken cancellationToken)
    {
        await dbContext.Customers.AddAsync(customer, cancellationToken);
    }
    
}