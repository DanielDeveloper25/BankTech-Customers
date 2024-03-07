using Customers.Domain.Entities.Base;
using Customers.Domain.Enums;

namespace Customers.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdentificationNumber { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public bool IsClient { get; set; }
        public string Nationality { get; set; }
        public int ContactId { get; set; }
        public Contact? Contact { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
