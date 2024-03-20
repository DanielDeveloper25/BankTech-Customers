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
            CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ReverseMap();

            CreateMap<Customer, SaveCustomerDTO>()
                .ForMember(dest => dest.Contact, opt => opt.MapFrom(src => src.Contact))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ReverseMap();

            CreateMap<Customer, ClientDTO>().ReverseMap();

            CreateMap<Address, AddressDTO>().ReverseMap();
            CreateMap<Address, SaveAddressDTO>().ReverseMap();

            CreateMap<Contact, ContactDTO>().ReverseMap();
            CreateMap<Contact, SaveContactDTO>().ReverseMap();
        }
    }
}