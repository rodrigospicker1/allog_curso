using Univali.Api.Entities;

namespace Univali.Api.Controllers
{
    internal interface ICustomerRepository
    {
        IEnumerable<Customer> GetCustomers();
    }
}