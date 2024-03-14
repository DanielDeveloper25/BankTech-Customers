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

        public override async Task<SaveCustomerDTO> Add(SaveCustomerDTO vm)
        {
            var contact = new Contact
            {
                PhoneNumber = vm.PhoneNumber,
                HouseNumber = vm.HouseNumber,
                Email = vm.Email,
                AlternatePhoneNumber = vm.AlternatePhoneNumber
            };

            var address = new Address
            {
                Street = vm.Street,
                City = vm.City,
                State = vm.State,
                ZipCode = vm.ZipCode
            };

            var customer = _mapper.Map<Customer>(vm);

            customer.Contact = contact;
            customer.Address = address;

            customer = await _customerRepository.AddAsync(customer);

            SaveCustomerDTO customerDto = _mapper.Map<SaveCustomerDTO>(customer);

            return customerDto;
        }

        public override async Task<List<CustomerDTO>> GetAllDto()
        {
            var properties = new List<string> { "Contact", "Address" };
            var entityList = await _customerRepository.GetAllWithIncludeAsync(properties);
            return _mapper.Map<List<CustomerDTO>>(entityList);
        }

        public async Task<CustomerDTO> GetByEmailWithIncludeAsync(string email)
        {
            var properties = new List<string> { "Contact", "Address" };
            var customer = await _customerRepository.GetByEmailWithIncludeAsync(email, properties);
            var customerDto = _mapper.Map<CustomerDTO>(customer);
            return customerDto;
        }

        public async Task<CustomerDTO> GetCustomerWithRelatedEntitiesAsync(int id)
        {
            var properties = new List<string> { "Contact", "Address" };
            var customer = await _customerRepository.GetByIdWithIncludeAsync(id, properties);
            var customerDto = _mapper.Map<CustomerDTO>(customer);
            return customerDto;
        }
    }
}
