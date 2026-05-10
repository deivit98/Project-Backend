using FluentValidation;

namespace Project.Application.Customers.Commands.UpdateCustomerContact;

public class UpdateCustomerContactCommandValidator : AbstractValidator<UpdateCustomerContactCommand>
{
    public UpdateCustomerContactCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Address).NotEmpty().MaximumLength(300);
        RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .Matches(@"^\+?[1-9]\d{7,14}$");
        RuleFor(x => x.Iban)
            .NotEmpty()
            .Length(15, 34)
            .Matches("^[A-Z0-9 ]+$");
    }
}
