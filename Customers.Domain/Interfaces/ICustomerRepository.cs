using Customers.Domain.Entities;

namespace Customers.Domain.Interfaces
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        Task<Customer> GetByEmailWithIncludeAsync(string email, List<string> properties, CancellationToken cancellationToken = default);
    }
}
