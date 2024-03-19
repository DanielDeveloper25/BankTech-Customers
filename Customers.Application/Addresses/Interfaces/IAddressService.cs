using Customers.Application.Addresses.DTOs;
using Customers.Application.Generics.Interfaces;
using Customers.Domain.Entities;

namespace Customers.Application.Addresses.Interfaces
{
    public interface IAddressService : IGenericService<SaveAddressDTO, AddressDTO, Address>
    {
    }
}
