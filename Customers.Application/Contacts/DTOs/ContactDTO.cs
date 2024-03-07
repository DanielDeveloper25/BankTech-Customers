namespace Customers.Application.Contacts.DTOs
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string PreferredContactMethod { get; set; }
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
