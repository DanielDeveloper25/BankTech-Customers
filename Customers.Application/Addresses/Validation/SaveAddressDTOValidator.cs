using Customers.Application.Addresses.DTOs;
using FluentValidation;

namespace Customers.Application.Addresses.Validation
{
    public class SaveAddressDTOValidator : AbstractValidator<SaveAddressDTO>
    {
        public SaveAddressDTOValidator()
        {
            RuleFor(dto => dto.Street).NotEmpty().WithMessage("Street is required.");
            RuleFor(dto => dto.City).NotEmpty().WithMessage("City is required.");
            RuleFor(dto => dto.State).NotEmpty().WithMessage("State is required.");
            RuleFor(dto => dto.ZipCode).NotEmpty().WithMessage("Zip code is required.");
            RuleFor(dto => dto.Country).NotEmpty().WithMessage("Country is required.");
        }
    }
}
