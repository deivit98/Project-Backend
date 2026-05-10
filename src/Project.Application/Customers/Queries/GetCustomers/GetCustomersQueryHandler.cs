using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Customers.Models;
using Project.Infrastructure.Extensions;
using Project.Infrastructure.Persistence;

namespace Project.Application.Customers.Queries.GetCustomers;

public class GetCustomersQueryHandler(ApplicationDbContext dbContext)
    : IRequestHandler<GetCustomersQuery, IReadOnlyList<CustomerDto>>
{
    public async Task<IReadOnlyList<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await dbContext.GetCustomersAsync(cancellationToken);
        
        return customers
            .Select(customer => new CustomerDto(
                customer.Id,
                customer.FirstName,
                customer.Surname,
                customer.DateOfBirth,
                customer.Address,
                customer.PhoneNumber,
                customer.Iban))
            .ToList();
    }
}
