using Customers.Application.Contacts.DTOs;
using FluentValidation;

namespace Customers.Application.Contacts.Validation
{
    public class SaveContactDtoValidator : AbstractValidator<SaveContactDTO>
    {
        public SaveContactDtoValidator()
        {
            RuleFor(dto => dto.PhoneNumber).NotEmpty().WithMessage("Phone number is required.");
            RuleFor(dto => dto.HouseNumber).NotEmpty().WithMessage("House number is required.");
            RuleFor(dto => dto.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email address format.");
            RuleFor(dto => dto.AlternatePhoneNumber).NotEmpty().WithMessage("Alternate phone number is required.");
        }
    }
}
