using Customers.Application.Customers.DTOs;
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
            RuleFor(customer => customer.Email).NotEmpty().EmailAddress();
            RuleFor(customer => customer.Street).NotEmpty();
            RuleFor(customer => customer.City).NotEmpty();
            RuleFor(customer => customer.State).NotEmpty();
            RuleFor(customer => customer.ZipCode).NotEmpty();
        }
    }
}
