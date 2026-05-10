using MediatR;
using Project.Application.Customers.Models;

namespace Project.Application.Customers.Queries.GetCustomers;

public record GetCustomersQuery : IRequest<IReadOnlyList<CustomerDto>>;
