using Univali.Api.Controllers;
using Univali.Api.DbContexts;
using Univali.Api.Entities;

public class CustomerRespository : ICustomerRepository
{
    private readonly CustomerContext _context;

    public CustomerRespository(CustomerContext customerContext){
        _context = customerContext;
    }

    public Customer GetCustomerById(int customerId){
        return _context.Customers.FirstOrDefault(c => c.Id);
    }

    public IEnumerable<Customer> GetCustomers(int customerId){
        return _context.Customers.OrderBy(c => c.Id).ToList();
    }

    public IEnumerable<Customer> GetCustomers()
    {
        throw new NotImplementedException();
    }
}