using Customers.Domain.Entities.Base;

namespace Customers.Domain.Entities
{
    public class Contact : BaseEntity
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string HouseNumber { get; set; }
        public string Email { get; set; }
        public string AlternatePhoneNumber { get; set; }
    }
}
