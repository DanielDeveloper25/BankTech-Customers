using Customers.Application.Customers.DTOs;
using Customers.Application.Generics.Interfaces;
using Customers.Domain.Entities;

namespace Customers.Application.Customers.Interfaces
{
    public interface ICustomerService : IGenericService<SaveCustomerDTO, UpdateCustomerDTO, CustomerDTO, Customer>
    {
    }
}
