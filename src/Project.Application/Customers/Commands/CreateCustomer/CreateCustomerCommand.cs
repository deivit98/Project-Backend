using MediatR;
using Project.Application.Customers.Models;

namespace Project.Application.Customers.Commands.CreateCustomer;

public record CreateCustomerCommand(
    string FirstName,
    string Surname,
    DateOnly DateOfBirth,
    string Address,
    string PhoneNumber,
    string Iban) : IRequest<CustomerDto>;
