using Customers.Domain.Entities.Base;

namespace Customers.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string IdentificationNumber { get; set; }
        public bool IsClient { get; set; } = true;
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
