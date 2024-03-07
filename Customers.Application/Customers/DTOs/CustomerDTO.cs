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
        public string Nationality { get; set; }
        public int ContactId { get; set; }
        public int AddressId { get; set; }
        //Audit properties
        public bool IsDeleted { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? UpdatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public string? DeletedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedDate { get; set; }
    }
}
