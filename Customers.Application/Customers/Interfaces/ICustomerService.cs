using Customers.Application.Customers.DTOs;
using Customers.Application.Generics.Interfaces;
using Customers.Domain.Entities;

namespace Customers.Application.Customers.Interfaces
{
    public interface ICustomerService : IGenericService<SaveCustomerDTO, CustomerDTO, Customer>
    {
        Task PatchCustomer(int id, PatchCustomerDTO patchCustomerDto);

        Task<CustomerDTO> GetCustomerWithRelatedEntitiesAsync(int id);
        Task<CustomerDTO> GetByEmailWithIncludeAsync(string email);
        Task<ClientDTO> GetClient(int id);
    }
}
