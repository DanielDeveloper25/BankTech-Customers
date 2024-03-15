using Customers.Domain.Interfaces; 
using System.Threading;
using System.Threading.Tasks;

namespace Customers.Application.Customers.Helpers
{
    public static class UniqueVerification
    {
        private static ICustomerRepository _customerRepository; 

        public static void Initialize(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public static bool EmailIsUnique(string email, CancellationToken cancellationToken = default)
        {
            if (_customerRepository == null)
            {
                throw new InvalidOperationException("Customer repository has not been initialized.");
            }

            var customer = _customerRepository.GetByEmailWithIncludeAsync(email, null).Result;
            return customer == null;
        }

        public static bool IdentificationNumberIsUnique(string idNumber, CancellationToken cancellationToken = default)
        {
            if (_customerRepository == null)
            {
                throw new InvalidOperationException("Customer repository has not been initialized.");
            }

            var customer = _customerRepository.GetByIdentificationNumberAsync(idNumber, cancellationToken).Result;
            return customer == null;
        }
    }
}
