using Customers.Domain.Entities;
using Customers.Domain.Interfaces;
using Customers.Infraestructure.Context;

namespace Customers.Infraestructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
