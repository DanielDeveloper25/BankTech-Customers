using AutoMapper;
using Customers.Application.Customers.DTOs;
using Customers.Application.Customers.Interfaces;
using Customers.Application.Generics.Services;
using Customers.Domain.Entities;
using Customers.Domain.Interfaces;

namespace Customers.Application.Customers.Services
{
    public class CustomerService : GenericService<SaveCustomerDTO, UpdateCustomerDTO, CustomerDTO, Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) : base(customerRepository, mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
    }
}
