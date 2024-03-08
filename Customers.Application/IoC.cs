using Customers.Application.Addresses.Interfaces;
using Customers.Application.Addresses.Services;
using Customers.Application.Contacts.Interfaces;
using Customers.Application.Contacts.Services;
using Customers.Application.Customers.DTOs;
using Customers.Application.Customers.Interfaces;
using Customers.Application.Customers.Services;
using Customers.Application.Generics.Interfaces;
using Customers.Application.Generics.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Customers.Application
{
    public static class IoC
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            #region Services
            services.AddTransient(typeof(IGenericService<,,,>), typeof(GenericService<,,,>));
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IContactService, ContactService>();
            #endregion
        }
    }
}
