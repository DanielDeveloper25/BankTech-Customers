using AutoMapper;
using Customers.Application.Contacts.DTOs;
using Customers.Application.Contacts.Interfaces;
using Customers.Application.Generics.Services;
using Customers.Domain.Entities;
using Customers.Domain.Interfaces;

namespace Customers.Application.Contacts.Services
{
    public class ContactService : GenericService<SaveContactDTO, UpdateContactDTO, ContactDTO, Contact>, IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper) : base(contactRepository, mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
    }
}
