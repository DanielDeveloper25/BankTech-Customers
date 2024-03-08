using Customers.Domain.Enums;

namespace Customers.Application.Customers.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdentificationNumber { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public bool IsClient { get; set; }
        public int ContactId { get; set; }
        public int AddressId { get; set; }
    }
}
