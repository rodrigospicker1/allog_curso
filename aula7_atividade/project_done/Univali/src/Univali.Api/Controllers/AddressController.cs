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
    [HttpGet]
    public ActionResult<IEnumerable<AddressDto>> GetAddresses(int customerId)
    {
        var customerFromDatabase = Data.Instance.Customers
            .FirstOrDefault(customer => customer.Id == customerId);

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

        return Ok(addressesToReturn);

    }

    [HttpGet("{addressId}")]
    public ActionResult<IEnumerable<AddressDto>> GetAddress(int customerId, int addressId)
    {
        var addressesToReturn = Data.Instance
            .Customers.FirstOrDefault(customer => customer.Id == customerId)
            ?.Addresses.FirstOrDefault(address => address.Id == addressId);

        return addressesToReturn != null ? Ok(addressesToReturn) : NotFound();

    }

    [HttpPost]
    public ActionResult<AddressDto> CreateAddress(int customerId,
        AddressForCreationDto addressForCreationDto)
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

        var AddressEntity = new Address()
        {
            Id = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId).Addresses.Max(a => a.Id) + 1,
            Street = addressForCreationDto.Street,
            City = addressForCreationDto.City
        };

        Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId).Addresses.Add(AddressEntity);

        var AddressToReturn = new AddressDto
        {
            Id = AddressEntity.Id,
            Street = AddressEntity.Street,
            City = AddressEntity.City
        };

        return Ok(AddressToReturn);
    }

     [HttpPut("{id}")]
    public ActionResult UpdateAddress(int customerId, int id, 
        AddressForUpdateDto addressForUpdateDto)
    {
        if(id != addressForUpdateDto.Id) return BadRequest();

        var addressFromDatabase = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId).Addresses
            .FirstOrDefault(address => address.Id == id);

        if(addressFromDatabase == null) return NotFound();

        addressFromDatabase.Street = addressForUpdateDto.Street;
        addressFromDatabase.City = addressForUpdateDto.City;

        return NoContent();
    }

     [HttpDelete("{id}")]
    public ActionResult DeleteAddress(int customerId, int id)
    {
        var addressFromDatabase = Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId).Addresses
            .FirstOrDefault(customer => customer.Id == id);

        if(addressFromDatabase == null) return NotFound();

        Data.Instance.Customers.FirstOrDefault(customer => customer.Id == customerId).Addresses.Remove(addressFromDatabase);

        return NoContent();
    }
}

// 1. Crie um método GET que retorne um address específico de um determinado
// customer.
// 2. Crie um método POST para adicionar um address a um customer existente.
// 3. Crie um método PUT para atualizar um address específico de um determinado
// customer.
// 4. Crie um método DELETE para remover um address específico de um determinado
// customer.
// 5. Crie um método GET que retorne um customer específico com todos os addresses
// que lhe pertencem.
// 6. Crie um método POST para criar um customer com um ou vários addresses. Não é
// necessário fazer a validação da quantidade de addresses.
// 7. Crie um método PUT para atualizar um customer com addresses. Se o customer
// que está sendo atualizado já possui addresses, estes serão substituídos pelos novos
// addresses. Não é necessário verificar quais addresses existem para saber quais
// adicionar, atualizar ou excluir. Basta substituir todos os addresses existentes pelos
// novos addresses