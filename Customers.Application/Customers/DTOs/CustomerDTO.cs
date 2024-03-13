namespace Customers.Application.Customers.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public required string IdentificationNumber { get; set; }
        public bool IsClient { get; set; }

        // Propiedades de Contact
        public required string PhoneNumber { get; set; }
        public required string HouseNumber { get; set; }
        public required string Email { get; set; }
        public string? AlternatePhoneNumber { get; set; }

        // Propiedades de Address
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
    }
}
