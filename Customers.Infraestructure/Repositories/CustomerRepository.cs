using Customers.Domain.Entities;
using Customers.Domain.Interfaces;
using Customers.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Customers.Infraestructure.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        private readonly CustomerDbContext _dbContext;

        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Customer> GetByEmailWithIncludeAsync(string email, List<string> properties, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Set<Customer>()
                .Where(x => x.Contact.Email == email && !x.IsDeleted);

            foreach (string property in properties)
            {
                query = query.Include(property);
            }

            return await query.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
