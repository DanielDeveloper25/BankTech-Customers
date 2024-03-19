using AutoMapper;
using Customers.Application.Customers.DTOs;
using Customers.Application.Customers.Helpers;
using Customers.Application.Customers.Interfaces;
using Customers.Application.Customers.Validation;
using Customers.Application.Generics.Services;
using Customers.Domain.Entities;
using Customers.Domain.Interfaces;

namespace Customers.Application.Customers.Services
{
    public class CustomerService : GenericService<SaveCustomerDTO, CustomerDTO, Customer>, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly SaveCustomerDTOValidator _validator;
        private readonly IMapper _mapper;
        public CustomerService(ICustomerRepository customerRepository, IMapper mapper) : base(customerRepository, mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
            _validator = new SaveCustomerDTOValidator();
            UniqueVerification.Initialize(_customerRepository);
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

        public override async Task<List<CustomerDTO>> GetAllDtoWithPagination(int pageNumber, int pageSize)
        {
            var properties = new List<string> { "Contact", "Address" };
            var entityList = await _customerRepository.GetAllWithPaginationAsync(pageNumber, pageSize, properties);
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
        public async Task<ClientDTO> GetClient(int id)
        {
            var entity = await _customerRepository.GetByIdAsync(id);
            ClientDTO vm = _mapper.Map<ClientDTO>(entity);
            return vm;
        }

        public async Task PatchCustomer(int id, PatchCustomerDTO patchCustomerDto)
        {
            var customer = await _customerRepository.GetByIdWithIncludeAsync(id, new List<string> { "Contact", "Address" });
            if (customer == null)
            {
                throw new Exception($"Customer with id {id} not found.");
            }

            // Update Customer properties
            if (patchCustomerDto.FirstName != null) customer.FirstName = patchCustomerDto.FirstName;
            if (patchCustomerDto.LastName != null) customer.LastName = patchCustomerDto.LastName;
            if (patchCustomerDto.DateOfBirth != null) customer.DateOfBirth = patchCustomerDto.DateOfBirth.Value;
            if (patchCustomerDto.IdentificationNumber != null) customer.IdentificationNumber = patchCustomerDto.IdentificationNumber;
            if (patchCustomerDto.ActiveAccount != null) customer.ActiveAccount = patchCustomerDto.ActiveAccount.Value;

            // Update Contact properties
            if (patchCustomerDto.PhoneNumber != null) customer.Contact.PhoneNumber = patchCustomerDto.PhoneNumber;
            if (patchCustomerDto.HouseNumber != null) customer.Contact.HouseNumber = patchCustomerDto.HouseNumber;
            if (patchCustomerDto.Email != null) customer.Contact.Email = patchCustomerDto.Email;
            if (patchCustomerDto.AlternatePhoneNumber != null) customer.Contact.AlternatePhoneNumber = patchCustomerDto.AlternatePhoneNumber;

            // Update Address properties
            if (patchCustomerDto.Street != null) customer.Address.Street = patchCustomerDto.Street;
            if (patchCustomerDto.City != null) customer.Address.City = patchCustomerDto.City;
            if (patchCustomerDto.State != null) customer.Address.State = patchCustomerDto.State;
            if (patchCustomerDto.ZipCode != null) customer.Address.ZipCode = patchCustomerDto.ZipCode;

            await _customerRepository.UpdateAsync(customer);
        }
    }

}
