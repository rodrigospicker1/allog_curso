using Microsoft.AspNetCore.Mvc;

namespace Univali.Api.Controllers;

[ApiController]

[Route("api/customers")]
public class CustomersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        var result = Data.getData().customers;

        return Ok(result);
    }

    [HttpGet("{id}", Name = "GetCustomerById")]
    public ActionResult<Customer> GetCustomerById(int id)
    {
        Console.WriteLine($"id: {id}");
        var result = Data.getData().customers.FirstOrDefault(c => c.Id == id);

        if(result == null) return NotFound();
        return Ok(result);
    }

    [HttpGet("cpf/{cpf}")]
    public ActionResult<Customer> GetCustomerByCpf(string cpf)
    {
        Console.WriteLine($"cpf: {cpf}");
        var result = Data.getData().customers.FirstOrDefault(c => c.Cpf == cpf);

        if(result == null) return NotFound();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer customer)
    {
        var newCustomer = new Customer
        {
            Id = Data.getData().customers.Max(c => c.Id) + 1,
            Name = customer.Name,
            Cpf = customer.Cpf
        };

        Data.getData().customers.Add(newCustomer);
        return CreatedAtRoute
        (
            "GetCustomerById",
            new {id = newCustomer.Id},
            newCustomer
        );
    }

    [HttpPut]
    [Route("EditCustomerByCpf/{cpf}")]
    public ActionResult<Customer> EditCustomer( string cpf ,Customer editedCustomer)
    {

        var oldCustomer = Data.getData().customers.FirstOrDefault(n => n.Cpf == cpf);


        if (oldCustomer == null) 
        {
            return NotFound(cpf);

        }

        else
        {
            Customer newCustomer = new Customer()
            {
                Id = oldCustomer.Id,
                Name = editedCustomer.Name,
                Cpf = editedCustomer.Cpf

            };

            Data.getData().customers[Data.getData().customers.IndexOf(oldCustomer)] = newCustomer;
            

            return Ok(newCustomer);
        }


        // return CreatedAtRoute(
        //     $"GetCustomerById",
        //     new{id = newCustomer.Id},
        //     newCustomer
        // );

        
    }


    [HttpDelete]
    [Route("DeleteCostumerByCpf/{cpf}")]
    public ActionResult<Customer> Delete([FromRoute] string cpf)
    {
        var existingCustomers = Data.getData().customers;
        var customerToRemove = existingCustomers.FirstOrDefault(n => n.Cpf == cpf);
        if (customerToRemove == null)
        {
            return NotFound(customerToRemove);
        }
        existingCustomers.Remove(customerToRemove);
        return Ok(customerToRemove);
    }
}