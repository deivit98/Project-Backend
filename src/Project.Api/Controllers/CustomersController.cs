using MediatR;
using Microsoft.AspNetCore.Mvc;
using Project.Application.Customers.Commands.CreateCustomer;
using Project.Application.Customers.Commands.DeleteCustomer;
using Project.Application.Customers.Commands.UpdateCustomerContact;
using Project.Application.Customers.Queries.GetCustomerById;
using Project.Application.Customers.Queries.GetCustomers;

namespace Project.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command, CancellationToken cancellationToken)
    {
        var created = await sender.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var customer = await sender.Send(new GetCustomerByIdQuery(id), cancellationToken);
        return customer is null ? NotFound() : Ok(customer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var customers = await sender.Send(new GetCustomersQuery(), cancellationToken);
        return Ok(customers);
    }

    [HttpPut("{id:guid}/contact")]
    public async Task<IActionResult> UpdateContact(
        Guid id,
        [FromBody] UpdateCustomerContactRequest request,
        CancellationToken cancellationToken)
    {
        var result = await sender.Send(
            new UpdateCustomerContactCommand(id, request.Address, request.PhoneNumber, request.Iban),
            cancellationToken);

        return result is null ? NotFound() : Ok(result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await sender.Send(new DeleteCustomerCommand(id), cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}

public record UpdateCustomerContactRequest(string Address, string PhoneNumber, string Iban);
