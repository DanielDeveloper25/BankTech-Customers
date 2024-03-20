using Customers.Application.Addresses.DTOs;
using Customers.Application.Contacts.DTOs;

namespace Customers.Application.Customers.DTOs
{
    public class PatchCustomerDTO
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? IdentificationNumber { get; set; }
        public bool? ActiveAccount { get; set; }

        public ContactDTO? Contact { get; set; }
        public AddressDTO? Address { get; set; }
    }
}
