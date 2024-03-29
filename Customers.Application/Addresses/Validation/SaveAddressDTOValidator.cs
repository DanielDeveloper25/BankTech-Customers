﻿using Customers.Application.Addresses.DTOs;
using FluentValidation;

namespace Customers.Application.Addresses.Validation
{
    public class SaveAddressDTOValidator : AbstractValidator<SaveAddressDTO>
    {
        public SaveAddressDTOValidator()
        {
            RuleFor(address => address.Street)
                .NotEmpty()
                .WithMessage("La calle no puede estar vacía.");

            RuleFor(address => address.City)
                .NotEmpty()
                .WithMessage("La ciudad no puede estar vacía.");

            RuleFor(address => address.State)
                .NotEmpty()
                .WithMessage("El estado no puede estar vacío.");

            RuleFor(address => address.ZipCode)
                .NotEmpty()
                .WithMessage("El código postal no puede estar vacío.");
        }
    }
}
