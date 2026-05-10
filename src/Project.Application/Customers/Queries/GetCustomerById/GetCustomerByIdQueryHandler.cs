using MediatR;
using Microsoft.EntityFrameworkCore;
using Project.Application.Customers.Models;
using Project.Infrastructure.Extensions;
using Project.Infrastructure.Persistence;

namespace Project.Application.Customers.Queries.GetCustomerById;

public class GetCustomerByIdQueryHandler(ApplicationDbContext dbContext)
    : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
{
    public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
    {
        var customer = await dbContext.GetCustomerById(request.Id, cancellationToken);

        return customer is null
            ? null
            : new CustomerDto(
                customer.Id,
                customer.FirstName,
                customer.Surname,
                customer.DateOfBirth,
                customer.Address,
                customer.PhoneNumber,
                customer.Iban);
    }
}
