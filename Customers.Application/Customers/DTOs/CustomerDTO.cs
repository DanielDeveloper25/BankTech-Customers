using Customers.Application.Addresses.DTOs;
using Customers.Application.Contacts.DTOs;

namespace Customers.Application.Customers.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string IdentificationNumber { get; set; }
        public bool ActiveAccount { get; set; }

        public required ContactDTO Contact { get; set; }
        public required AddressDTO Address { get; set; }
    }
}
