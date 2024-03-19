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

            RuleFor(customer => customer.PhoneNumber)
                .NotEmpty().When(customer => customer.PhoneNumber != null)
                .WithMessage("El número de teléfono no puede estar vacío.");

            RuleFor(customer => customer.Email)
                .NotEmpty().When(customer => customer.Email != null)
                .WithMessage("El correo electrónico no puede estar vacío.")
                .EmailAddress()
                .WithMessage("El correo electrónico tiene un formato inválido.")
                .Must(x => UniqueVerification.EmailIsUnique(x))
                .WithMessage("El correo electrónico ya existe.");

            RuleFor(customer => customer.HouseNumber)
                .NotEmpty().When(customer => customer.HouseNumber != null)
                .WithMessage("El número de casa no puede estar vacío.");

            RuleFor(customer => customer.AlternatePhoneNumber)
                .NotEmpty().When(customer => customer.AlternatePhoneNumber != null)
                .WithMessage("El número de teléfono alternativo no puede estar vacío.");

            RuleFor(customer => customer.Street)
                .NotEmpty().When(customer => customer.Street != null)
                .WithMessage("La calle no puede estar vacía.");

            RuleFor(customer => customer.City)
                .NotEmpty().When(customer => customer.City != null)
                .WithMessage("La ciudad no puede estar vacía.");

            RuleFor(customer => customer.State)
                .NotEmpty().When(customer => customer.State != null)
                .WithMessage("El estado no puede estar vacío.");

            RuleFor(customer => customer.ZipCode)
                .NotEmpty().When(customer => customer.ZipCode != null)
                .WithMessage("El código postal no puede estar vacío.");
        }
    }
}