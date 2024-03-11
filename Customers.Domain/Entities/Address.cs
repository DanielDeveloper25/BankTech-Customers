using Customers.Domain.Entities.Base;

namespace Customers.Domain.Entities
{
    public class Address : BaseEntity
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}
