using Customers.Application.Addresses.DTOs;
using FluentValidation;

namespace Customers.Application.Addresses.Validation
{
    public class UpdateAddressDtoValidator : AbstractValidator<UpdateAddressDTO>
    {
        public UpdateAddressDtoValidator()
        {
            RuleFor(dto => dto.Id).NotEmpty().WithMessage("Address ID is required.");
            RuleFor(dto => dto.Street).NotEmpty().WithMessage("Street is required.");
            RuleFor(dto => dto.City).NotEmpty().WithMessage("City is required.");
            RuleFor(dto => dto.State).NotEmpty().WithMessage("State is required.");
            RuleFor(dto => dto.ZipCode).NotEmpty().WithMessage("Zip code is required.");
        }
    }
}
