using Customers.Application.Contacts.Validation;
using Customers.Application.Customers.DTOs;
using Customers.Application.Customers.Helpers;
using FluentValidation;

namespace Customers.Application.Customers.Validation
{
    public class PatchCustomerDTOValidator : AbstractValidator<PatchCustomerDTO>
    {
        public PatchCustomerDTOValidator()
        {
            RuleFor(customer => customer.FirstName)
                .NotEmpty().When(customer => customer.FirstName != null)
                .WithMessage("El nombre no puede estar vacío.");

            RuleFor(customer => customer.LastName)
                .NotEmpty().When(customer => customer.LastName != null)
                .WithMessage("El apellido no puede estar vacío.");

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty().When(customer => customer.DateOfBirth != null)
                .WithMessage("La fecha de nacimiento no puede estar vacía.");

            RuleFor(customer => customer.IdentificationNumber)
                .NotEmpty().When(customer => customer.IdentificationNumber != null)
                .WithMessage("El número de identificación no puede estar vacío.")
                .Must(x => UniqueVerification.IdentificationNumberIsUnique(x))
                .WithMessage("El número de identificación ya existe.");

            RuleFor(customer => customer.Contact)
                .SetValidator(new PatchContactDTOValidator())
                .When(customer => customer.Contact != null);

            RuleFor(customer => customer.Address)
                .SetValidator(new PatchAddressDTOValidator())
                .When(customer => customer.Address != null);
        }
    }
}