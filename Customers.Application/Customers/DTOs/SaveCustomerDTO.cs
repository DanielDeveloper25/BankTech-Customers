namespace Customers.Application.Customers.DTOs
{
    public class SaveCustomerDTO
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdentificationNumber { get; set; }
        public bool IsClient { get; set; }

        // Contact properties
        public required string PhoneNumber { get; set; }
        public required string HouseNumber { get; set; }
        public required string Email { get; set; }
        public string? AlternatePhoneNumber { get; set; }

        // Address properties
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
    }
}