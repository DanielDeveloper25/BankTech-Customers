using Customers.Application.Addresses.DTOs;
using FluentValidation;

namespace Customers.Application.Customers.Validation
{
    public class PatchAddressDTOValidator : AbstractValidator<AddressDTO>
    {
        public PatchAddressDTOValidator()
        {
            RuleFor(address => address.Street)
                .NotEmpty().When(address => address.Street != null)
                .WithMessage("La calle no puede estar vacía.");

            RuleFor(address => address.City)
                .NotEmpty().When(address => address.City != null)
                .WithMessage("La ciudad no puede estar vacía.");

            RuleFor(address => address.State)
                .NotEmpty().When(address => address.State != null)
                .WithMessage("El estado no puede estar vacío.");

            RuleFor(address => address.ZipCode)
                .NotEmpty().When(address => address.ZipCode != null)
                .WithMessage("El código postal no puede estar vacío.");
        }
    }
}
