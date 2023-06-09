using Microsoft.AspNetCore.Mvc;

namespace Univali.Api.Controllers;

[ApiController]

[Route("api/customers")]
public class CustomersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        var result = Data.Instance.Customer;

        return Ok(result);
    }
}

    // [HttpGet("{id}")]
    // public ActionResult<Customer> GetCustomer ([FromRoute] int id){
        //var result = Data.Instance.Customer;
    // }
