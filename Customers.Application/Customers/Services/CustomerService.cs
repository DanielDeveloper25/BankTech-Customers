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
            // Crear instancia de Contact
            var contact = new Contact
            {
                PhoneNumber = vm.PhoneNumber,
                HouseNumber = vm.HouseNumber,
                Email = vm.Email,
                AlternatePhoneNumber = vm.AlternatePhoneNumber
            };

            // Crear instancia de Address
            var address = new Address
            {
                Street = vm.Street,
                City = vm.City,
                State = vm.State,
                ZipCode = vm.ZipCode
            };

            // Crear instancia de Customer
            var customer = _mapper.Map<Customer>(vm);

            // Asociar Contact y Address al Customer
            customer.Contact = contact;
            customer.Address = address;

            // Guardar el nuevo Customer en la base de datos
            customer = await _customerRepository.AddAsync(customer);

            // Mapear la entidad Customer al DTO SaveCustomerDTO
            SaveCustomerDTO customerDto = _mapper.Map<SaveCustomerDTO>(customer);

            return customerDto;
        }
    }
}
