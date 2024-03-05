using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.Application.Entities
{
    public class Customer : BaseEntity
    {
        public required int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int IdentificationNumber { get; set; }
        public IdentificationType IdentificationType { get; set; }
        public int ContactId { get; set; }
        public Contact? Contact { get; set; }
        public int AddressId { get; set; }
        public Address? Address { get; set; }
    }
}
