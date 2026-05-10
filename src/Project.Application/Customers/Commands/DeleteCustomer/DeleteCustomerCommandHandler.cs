using MediatR;
using Project.Infrastructure.Extensions;
using Project.Infrastructure.Persistence;

namespace Project.Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler(ApplicationDbContext dbContext)
    : IRequestHandler<DeleteCustomerCommand, bool>
{
    public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var isRemoved = await dbContext.DeleteCustomerById(request.Id, cancellationToken);
        
        if(!isRemoved)
            return false;
        
        await dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
