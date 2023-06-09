using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Univali.Api.Entities;
using Univali.Api.Models;
using Univali.Api;

[ApiController]
[Route("api/customers/{customerId}/addresses")]
public class AddressController : ControllerBase
{
    // [HttpGet]
    // public ActionResult<IEnumerable<AddressDto>> GetAddresses(int customerId)
    // {
    //     var customerFromDatabase = Data.Instance.Customers
    //         .FirstOrDefault(customer => customer.Id == customerId);

    //     if(customerFromDatabase == null) return NotFound();

    //     var addressesToReturn = new List<AddressDto>();
    //     foreach(var address in customerFromDatabase.Addresses)
    //     {
    //         addressesToReturn.Add(new AddressDto
    //         {
    //             Id = address.Id,
    //             Street = address.Street,
    //             City = address.City
    //         });
    //     }

    //     return Ok(addressesToReturn);

    // }

    [HttpGet("{addressId}")]
    public ActionResult<IEnumerable<AddressDto>> GetAddress(int customerId, int addressId)
    {
        var addressesToReturn = Data.Instance
            .Customers.FirstOrDefault(customer => customer.Id == customerId)
            ?.Addresses.FirstOrDefault(address => address.Id == addressId);

        return addressesToReturn != null ? Ok(addressesToReturn) : NotFound();

    }
}