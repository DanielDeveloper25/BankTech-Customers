using Customers.Application.Addresses.DTOs;
using Customers.Application.Addresses.Validation;
using Customers.Application.Contacts.DTOs;
using Customers.Application.Contacts.Validation;
using Customers.Application.Customers.DTOs;
using Customers.Application.Customers.Helpers;
using FluentValidation;

namespace Customers.Application.Customers.Validation
{
    public class SaveCustomerDTOValidator : AbstractValidator<SaveCustomerDTO>
    {
        public SaveCustomerDTOValidator()
        {
            RuleFor(customer => customer.FirstName)
                .NotEmpty()
                .WithMessage("El nombre no puede estar vacío.");

            RuleFor(customer => customer.LastName)
                .NotEmpty()
                .WithMessage("El apellido no puede estar vacío.");

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .WithMessage("La fecha de nacimiento no puede estar vacía.");

            RuleFor(customer => customer.IdentificationNumber)
                .NotEmpty()
                .WithMessage("El número de identificación no puede estar vacío.")
                .Must(x => UniqueVerification.IdentificationNumberIsUnique(x))
                .WithMessage("El número de identificación ya existe.");

            RuleFor(customer => customer.Contact)
                .SetValidator(new SaveContactDTOValidator());

            RuleFor(customer => customer.Address)
                .SetValidator(new SaveAddressDTOValidator());
        }
    }
}