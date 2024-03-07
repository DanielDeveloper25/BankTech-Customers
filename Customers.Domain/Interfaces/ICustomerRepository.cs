using Customers.Domain.Entities;

namespace Customers.Domain.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }
}
