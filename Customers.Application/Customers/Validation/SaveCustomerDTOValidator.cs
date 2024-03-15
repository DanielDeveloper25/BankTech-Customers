using Customers.Application.Customers.DTOs;
using Customers.Application.Customers.Helpers;
using FluentValidation;

namespace Customers.Application.Customers.Validation
{
    public class SaveCustomerDTOValidator : AbstractValidator<SaveCustomerDTO>
    {
        public SaveCustomerDTOValidator()
        {
            RuleFor(customer => customer.FirstName).NotEmpty();
            RuleFor(customer => customer.LastName).NotEmpty();
            RuleFor(customer => customer.DateOfBirth).NotEmpty();
            RuleFor(customer => customer.IdentificationNumber).NotEmpty();
            RuleFor(customer => customer.PhoneNumber).NotEmpty();
            RuleFor(customer => customer.Email).NotEmpty().EmailAddress()
                .Must(x => UniqueVerification.EmailIsUnique(x)).WithMessage("This email address already exists.");
            RuleFor(customer => customer.IdentificationNumber).NotEmpty()
                .Must(x => UniqueVerification.IdentificationNumberIsUnique(x)).WithMessage("This identification number already exists.");
            RuleFor(customer => customer.Street).NotEmpty();
            RuleFor(customer => customer.City).NotEmpty();
            RuleFor(customer => customer.State).NotEmpty();
            RuleFor(customer => customer.ZipCode).NotEmpty();
        }
    }
}
