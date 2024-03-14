using Customers.Application.Customers.DTOs;
using Customers.Application.Generics.Interfaces;
using Customers.Domain.Entities;

namespace Customers.Application.Customers.Interfaces
{
    public interface ICustomerService : IGenericService<SaveCustomerDTO, UpdateCustomerDTO, CustomerDTO, Customer>
    {
        Task<CustomerDTO> GetCustomerWithRelatedEntitiesAsync(int id);
        Task<CustomerDTO> GetByEmailWithIncludeAsync(string email);
    }
}
