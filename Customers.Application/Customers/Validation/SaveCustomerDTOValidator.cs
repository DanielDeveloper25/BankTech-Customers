using Customers.Application.Customers.DTOs;
using FluentValidation;

namespace Customers.Application.Customers.Validation
{
    public class SaveCustomerDTOValidator : AbstractValidator<SaveCustomerDTO>
    {
        public SaveCustomerDTOValidator()
        {
            RuleFor(dto => dto.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(dto => dto.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(dto => dto.DateOfBirth).NotEmpty().WithMessage("Date of birth is required.");
            RuleFor(dto => dto.IdentificationNumber).NotEmpty().WithMessage("Identification number is required.");
            RuleFor(dto => dto.IdentificationType).NotEmpty().WithMessage("Identification type is required.");
            RuleFor(dto => dto.ContactId).NotEmpty().WithMessage("Contact ID is required.");
            RuleFor(dto => dto.AddressId).NotEmpty().WithMessage("Address ID is required.");
        }
    }
}
