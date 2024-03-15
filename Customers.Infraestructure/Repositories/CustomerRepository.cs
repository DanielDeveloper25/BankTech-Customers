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

        public async Task<Customer> GetByEmailWithIncludeAsync(string email, List<string>? properties = null, CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Set<Customer>()
                .Where(x => x.Contact.Email == email && !x.IsDeleted);

            if(properties != null)
            {
                foreach (string property in properties)
                {
                    query = query.Include(property);
                }
            }
            return await query.FirstOrDefaultAsync(cancellationToken);
        }

        public override async Task<Customer> AddAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            return await base.AddAsync(customer, cancellationToken);
        }

        public async Task<Customer> GetByIdentificationNumberAsync(string IDNumber,CancellationToken cancellationToken = default)
        {
            var query = _dbContext.Set<Customer>()
                .Where(x => x.IdentificationNumber == IDNumber && !x.IsDeleted);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
