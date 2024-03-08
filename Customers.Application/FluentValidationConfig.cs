using Customers.Application.Addresses.DTOs;
using Customers.Application.Addresses.Validation;
using Customers.Application.Contacts.DTOs;
using Customers.Application.Contacts.Validation;
using Customers.Application.Customers.DTOs;
using Customers.Application.Customers.Validation;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Customers.Application
{
    public static class FluentValidationConfig
    {
        public static void AddFluentValidation(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();

            services.AddScoped<IValidator<SaveCustomerDTO>, SaveCustomerDTOValidator>();
            services.AddScoped<IValidator<UpdateCustomerDTO>, UpdateCustomerDTOValidator>();

            services.AddScoped<IValidator<SaveAddressDTO>, SaveAddressDTOValidator>();
            services.AddScoped<IValidator<UpdateAddressDTO>, UpdateAddressDtoValidator>();

            services.AddScoped<IValidator<SaveContactDTO>, SaveContactDtoValidator>();
            services.AddScoped<IValidator<UpdateContactDTO>, UpdateContactDTOValidator>();
        }
    }
}
