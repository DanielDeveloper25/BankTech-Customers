using Customers.Application.Contacts.DTOs;
using Customers.Application.Customers.Helpers;
using FluentValidation;

namespace Customers.Application.Contacts.Validation
{
    public class PatchContactDTOValidator : AbstractValidator<ContactDTO>
    {
        public PatchContactDTOValidator()
        {
            RuleFor(contact => contact.PhoneNumber)
                .NotEmpty().When(contact => contact.PhoneNumber != null)
                .WithMessage("El número de teléfono no puede estar vacío.");

            RuleFor(contact => contact.HouseNumber)
                .NotEmpty().When(contact => contact.HouseNumber != null)
                .WithMessage("El número de casa no puede estar vacío.");

            RuleFor(contact => contact.Email)
                .NotEmpty().When(contact => contact.Email != null)
                .WithMessage("El correo electrónico no puede estar vacío.")
                .EmailAddress()
                .WithMessage("El correo electrónico tiene un formato inválido.")
                .Must(x => UniqueVerification.EmailIsUnique(x))
                .WithMessage("El correo electrónico ya existe.");
        }
    }
}