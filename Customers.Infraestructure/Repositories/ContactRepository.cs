using Customers.Domain.Entities;
using Customers.Domain.Interfaces;
using Customers.Infraestructure.Context;

namespace Customers.Infraestructure.Repositories
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        private readonly CustomerDbContext _customerDbContext;

        public ContactRepository(CustomerDbContext customerDbContext) : base(customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }
    }
}
