using Customers.Application.Addresses.DTOs;
using Customers.Application.Contacts.DTOs;

namespace Customers.Application.Customers.DTOs
{
    public class SaveCustomerDTO
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string IdentificationNumber { get; set; }

        public SaveContactDTO Contact { get; set; }
        public SaveAddressDTO Address { get; set; }
    }
}