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
                .WithMessage("El nombre es obligatorio.");

            RuleFor(customer => customer.LastName)
                .NotEmpty()
                .WithMessage("El apellido es obligatorio.");

            RuleFor(customer => customer.DateOfBirth)
                .NotEmpty()
                .WithMessage("La fecha de nacimiento es obligatoria.");

            RuleFor(customer => customer.IdentificationNumber)
                .NotEmpty()
                .WithMessage("El número de identificación es obligatorio.")
                .Must(x => UniqueVerification.IdentificationNumberIsUnique(x))
                .WithMessage("El número de identificación ya existe.");

            RuleFor(customer => customer.PhoneNumber)
                .NotEmpty()
                .WithMessage("El número de teléfono es obligatorio.");

            RuleFor(customer => customer.Email)
                .NotEmpty()
                .WithMessage("El correo electrónico es obligatorio.")
                .EmailAddress()
                .WithMessage("El correo electrónico tiene un formato inválido.")
                .Must(x => UniqueVerification.EmailIsUnique(x))
                .WithMessage("El correo electrónico ya existe.");

            RuleFor(customer => customer.Street)
                .NotEmpty()
                .WithMessage("La calle es obligatoria.");

            RuleFor(customer => customer.City)
                .NotEmpty()
                .WithMessage("La ciudad es obligatoria.");

            RuleFor(customer => customer.State)
                .NotEmpty()
                .WithMessage("El estado es obligatorio.");

            RuleFor(customer => customer.ZipCode)
                .NotEmpty()
                .WithMessage("El código postal es obligatorio.");
        }
    }
}
