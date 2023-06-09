
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Univali.Api.Entities;
using Univali.Api.Models;

namespace Univali.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
    {
        var customersToReturn = Data.Instance.Customers
            .Select(customer => 
                new CustomerDto{
                    Id = customer.Id,
                    Name = customer.Name,
                    Cpf = customer.Cpf
            });
        return Ok(customersToReturn);
    }

    [HttpGet("{id}", Name = "GetCustomerById")]
    public ActionResult<CustomerDto> GetCustomerById(int id)
    {
        var customerFromDatabase = Data.Instance
            .Customers.FirstOrDefault(c => c.Id == id);

        if (customerFromDatabase == null) return NotFound();

        CustomerDto customerToReturn = new CustomerDto
        {
            Id = customerFromDatabase.Id,
            Name = customerFromDatabase.Name,
            Cpf = customerFromDatabase.Cpf
        };
        return Ok(customerToReturn);
    }


    [HttpGet("cpf/{cpf}")]
    public ActionResult<CustomerDto> GetCustomerByCpf(string cpf)
    {
        var customerFromDatabase = Data.Instance.Customers
            .FirstOrDefault(c => c.Cpf == cpf);

        if(customerFromDatabase == null)
        {
            return NotFound();
        }

        CustomerDto customerToReturn = new CustomerDto
        {
            Id = customerFromDatabase.Id,
            Name = customerFromDatabase.Name,
            Cpf = customerFromDatabase.Cpf
        };
        return Ok(customerToReturn);
    }

    [HttpGet("with-address/{id}")]
    public ActionResult<IEnumerable<CustomerDto>> GetCustomersWithAddress(int id)
    {
        var customerFromDatabase = Data.Instance.Customers
            .FirstOrDefault(customer => customer.Id == id);

        if(customerFromDatabase == null) return NotFound();

        var addressesToReturn = new List<AddressDto>();
        foreach(var address in customerFromDatabase.Addresses)
        {
            addressesToReturn.Add(new AddressDto
            {
                Id = address.Id,
                Street = address.Street,
                City = address.City
            });
        }

        var customersToReturn =  new CustomerWithAddressDto
            {
                Id = customerFromDatabase.Id,
                Name = customerFromDatabase.Name,
                Cpf = customerFromDatabase.Cpf,
                Addresses = addressesToReturn
            };
            return Ok(customersToReturn);
    }

    [HttpPost]
    public ActionResult<CustomerDto> CreateCustomer(
        CustomerForCreationDto customerForCreationDto)
    {
        if(!ModelState.IsValid) 
        {
            Response.ContentType = "application/problem+json";
            var problemDetailsFactory = HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
            return UnprocessableEntity(ModelState);

            var validationProblemDetails = problemDetailsFactory
                .CreateValidationProblemDetails(HttpContext, ModelState);

            validationProblemDetails.Status = StatusCodes.Status422UnprocessableEntity;

            return UnprocessableEntity(validationProblemDetails);
        }
        
        var customerEntity = new Customer()
        {
            Id = Data.Instance.Customers.Max(c => c.Id) + 1,
            Name = customerForCreationDto.Name,
            Cpf = customerForCreationDto.Cpf
        };

        Data.Instance.Customers.Add(customerEntity);

        var customerToReturn = new CustomerDto
        {
            Id = customerEntity.Id,
            Name = customerForCreationDto.Name,
            Cpf = customerForCreationDto.Cpf
        };

        return CreatedAtRoute
        (
            "GetCustomerById",
            new {id = customerToReturn.Id },
            customerToReturn
        );
    }

    [HttpPut("{id}")]
    public ActionResult UpdateCustomer(int id, 
        CustomerForUpdateDto customerForUpdateDto)
    {
        if(id != customerForUpdateDto.Id) return BadRequest();

        var customerFromDatabase = Data.Instance.Customers
            .FirstOrDefault(customer => customer.Id == id);

        if(customerFromDatabase == null) return NotFound();

        customerFromDatabase.Name = customerForUpdateDto.Name;
        customerFromDatabase.Cpf = customerForUpdateDto.Cpf;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCustomer(int id)
    {
        var customerFromDatabase = Data.Instance.Customers
            .FirstOrDefault(customer => customer.Id == id);

        if(customerFromDatabase == null) return NotFound();

        Data.Instance.Customers.Remove(customerFromDatabase);

        return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartiallyUpdateCustomer([FromBody] JsonPatchDocument<CustomerForPatchDto> patchDocument,
                                                [FromRoute] int id)
    {
        var customerFromDatabase = Data.Instance.Customers
            .FirstOrDefault(customer => customer.Id == id);

        if(customerFromDatabase == null) return NotFound();

        var customerToPatch = new CustomerForPatchDto
        {
            Name = customerFromDatabase.Name,
            Cpf = customerFromDatabase.Cpf
        };

        patchDocument.ApplyTo(customerToPatch);

        customerFromDatabase.Name = customerToPatch.Name;
        customerFromDatabase.Cpf = customerToPatch.Cpf;

        return NoContent();
    }
    
    [HttpGet("with-address")]
    public ActionResult<IEnumerable<CustomerWithAddressDto>> GetCustomerWithAddress()
    {
        var customerFromDatabase = Data.Instance.Customers;

        var customersToReturn = customerFromDatabase
            .Select(customer => new CustomerWithAddressDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Cpf = customer.Cpf,
                Addresses = customer.Addresses
                    .Select(address => new AddressDto{
                        Id = address.Id,
                        City = address.City,
                        Street = address.Street
                    }).ToList()
            });

        return Ok(customersToReturn);
    }

    [HttpPost("with-address")]
    public ActionResult<CustomerDto> CreateCustomerWithAddress(
        CustomerAddressForCreationDto customerAddressForCreationDto)
    {
        if(!ModelState.IsValid) 
        {
            Response.ContentType = "application/problem+json";
            var problemDetailsFactory = HttpContext.RequestServices.GetRequiredService<ProblemDetailsFactory>();
            return UnprocessableEntity(ModelState);

            var validationProblemDetails = problemDetailsFactory
                .CreateValidationProblemDetails(HttpContext, ModelState);

            validationProblemDetails.Status = StatusCodes.Status422UnprocessableEntity;

            return UnprocessableEntity(validationProblemDetails);
        }
        
        var customerEntity = new Customer()
        {
            Id = Data.Instance.Customers.Max(c => c.Id) + 1,
            Name = customerAddressForCreationDto.Name,
            Cpf = customerAddressForCreationDto.Cpf,
            Addresses = customerAddressForCreationDto.Addresses
        };

        Data.Instance.Customers.Add(customerEntity);

        var customerToReturn = new CustomerAddressDto
        {
            Id = customerEntity.Id,
            Name = customerAddressForCreationDto.Name,
            Cpf = customerAddressForCreationDto.Cpf,
            Addresses = customerAddressForCreationDto.Addresses
        };

        return CreatedAtRoute
        (
            "GetCustomerById",
            new {id = customerToReturn.Id },
            customerToReturn
        );
    }

    [HttpPut("with-address/{id}")]
    public ActionResult UpdateCustomerAddress( int id,
        CustomerAddressForUpdate customerAddressForUpdate)
    {
        if(id != customerAddressForUpdate.Id) return BadRequest();

        var customerFromDatabase = Data.Instance.Customers
            .FirstOrDefault(customer => customer.Id == id);

        if(customerFromDatabase == null) return NotFound();

        customerFromDatabase.Name = customerAddressForUpdate.Name;
        customerFromDatabase.Cpf = customerAddressForUpdate.Cpf;
        customerFromDatabase.Addresses = customerAddressForUpdate.Addresses;

        return NoContent();
    }

}