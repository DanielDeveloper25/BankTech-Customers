using AutoMapper;
using Customers.Application.Addresses.DTOs;
using Customers.Application.Addresses.Interfaces;
using Customers.Application.Generics.Services;
using Customers.Domain.Entities;
using Customers.Domain.Interfaces;

namespace Customers.Application.Addresses.Services
{
    public class AddressService : GenericService<SaveAddressDTO, AddressDTO, Address>, IAddressService
    {
        public readonly IAddressRepository _addressRepository;
        public readonly IMapper _mapper;

        public AddressService(IAddressRepository addressRepository, IMapper mapper) : base(addressRepository, mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }
    }
}
