using MediatR;
using Project.Application.Customers.Models;
using Project.Domain.Entities;
using Project.Infrastructure.Extensions;
using Project.Infrastructure.Persistence;

namespace Project.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandHandler(ApplicationDbContext dbContext)
    : IRequestHandler<CreateCustomerCommand, CustomerDto>
{
    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = Customer.Create(
            request.FirstName,
            request.Surname,
            request.DateOfBirth,
            request.Address,
            request.PhoneNumber,
            request.Iban);

        await dbContext.CreateCustomer(customer, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CustomerDto(
            customer.Id,
            customer.FirstName,
            customer.Surname,
            customer.DateOfBirth,
            customer.Address,
            customer.PhoneNumber,
            customer.Iban);
    }
}
