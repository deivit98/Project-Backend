using MediatR;
using Project.Application.Customers.Models;

namespace Project.Application.Customers.Commands.UpdateCustomerContact;

public record UpdateCustomerContactCommand(
    Guid Id,
    string Address,
    string PhoneNumber,
    string Iban) : IRequest<CustomerDto?>;
