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

        // Contact properties
        public string? PhoneNumber { get; set; }
        public string? HouseNumber { get; set; }
        public string? Email { get; set; }
        public string? AlternatePhoneNumber { get; set; }

        // Address properties
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? ZipCode { get; set; }
    }
}
