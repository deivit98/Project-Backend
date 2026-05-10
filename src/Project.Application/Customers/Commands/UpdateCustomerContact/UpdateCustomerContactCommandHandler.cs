using MediatR;
using Project.Application.Customers.Models;
using Microsoft.EntityFrameworkCore;
using Project.Infrastructure.Extensions;
using Project.Infrastructure.Persistence;

namespace Project.Application.Customers.Commands.UpdateCustomerContact;

public class UpdateCustomerContactCommandHandler(ApplicationDbContext dbContext)
    : IRequestHandler<UpdateCustomerContactCommand, CustomerDto?>
{
    public async Task<CustomerDto?> Handle(UpdateCustomerContactCommand request, CancellationToken cancellationToken)
    {
        var customer = await dbContext.GetCustomerForUpdateById(request.Id, cancellationToken);
        
        if (customer is null)
        {
            return null;
        }

        customer.UpdateAddress(request.Address);
        customer.UpdatePhoneNumber(request.PhoneNumber);
        customer.UpdateIban(request.Iban);

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
