using Customers.Domain.Entities;
using Customers.Domain.Interfaces;
using Customers.Infraestructure.Context;

namespace Customers.Infraestructure.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        private readonly CustomerDbContext _dbContext;

        public AddressRepository(CustomerDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
