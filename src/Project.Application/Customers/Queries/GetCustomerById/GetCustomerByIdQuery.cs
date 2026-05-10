using MediatR;
using Project.Application.Customers.Models;

namespace Project.Application.Customers.Queries.GetCustomerById;

public record GetCustomerByIdQuery(Guid Id) : IRequest<CustomerDto?>;
