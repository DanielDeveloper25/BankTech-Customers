using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Customers.Application.Addresses.DTOs;
using Customers.Application.Contacts.DTOs;
using Customers.Application.Customers.DTOs;
using Customers.Domain.Entities;

namespace Customers.Application.Mapping
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Customer, SaveCustomerDTO>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDTO>().ReverseMap();

            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Address, SaveAddressDTO>().ReverseMap();
            CreateMap<Address, UpdateAddressDTO>().ReverseMap();

            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Contact, SaveContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
        }
    }
}
