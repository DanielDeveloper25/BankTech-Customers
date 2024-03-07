using Customers.Application.Contacts.DTOs;
using Customers.Application.Generics.Interfaces;
using Customers.Domain.Entities;

namespace Customers.Application.Contacts.Interfaces
{
    public interface IContactService : IGenericService<SaveContactDTO, UpdateContactDTO, ContactDTO, Contact>
    {
    }
}
