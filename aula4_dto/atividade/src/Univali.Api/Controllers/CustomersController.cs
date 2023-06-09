using Microsoft.AspNetCore.Mvc;
using Univali.Api.Entities;

namespace Univali.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomerController : ControllerBase
{
    [HttpGet]
    [HttpGet("GetAllCostumers")]
    public ActionResult<IEnumerable<CustomerDTO>> GetCustomers()
    {
        var result = Data.getData().customers;
        var customersDTOs = new List<CustomerDTO>();

        foreach (Customer customer in result)
        {
            Console.WriteLine(customer.Addresses[0].Cep);
            customersDTOs.Add(new CustomerDTO()
            {
                Name = customer.Name,
                Cpf = customer.Cpf,
                Addresses = customer.Addresses
            });
        }
        return Ok(customersDTOs);
    }

    [HttpGet("GetCostumerById/{id:int:min(1)}")]
    public ActionResult<CustomerDTO> GetCusomerById([FromRoute] int id)
    {
        var customers = Data.getData().customers;
        var customer = customers.FirstOrDefault(n => n.Id == id);
        var customerDTO = new CustomerDTO();

        if (customer != null)
        {
            customerDTO.Name = customer.Name;
            customerDTO.Cpf = customer.Cpf;
            return Ok(customerDTO);
        }

        return NotFound(customerDTO);

        // testa customer diferente de null | se for verdadeiro: opção | se não: segunda opção 
        // return customer != null ? Ok(customer) : NotFound(customer);
    }

    [HttpGet("GetCostumerByCpf/{cpf}")]
    public ActionResult<CustomerDTO> GetCusomerByCpf([FromRoute] string cpf)
    {
        var customers = Data.getData().customers;
        var customer = customers.FirstOrDefault(n => n.Cpf == cpf);
        var customerDTO = new CustomerDTO();

        if (customer != null)
        {
            customerDTO.Name = customer.Name;
            customerDTO.Cpf = customer.Cpf;
            return Ok(customerDTO);
        }

        return NotFound(customerDTO);
    }

    [HttpPost]
    [Route("CreateCustomers")]
    public ActionResult<List<CustomerDTO>> CreateCustomers(List<CustomerDTO> customers)
    {
        var newCustomers = new List<Customer>();
        var newCustomersDTOs = new List<CustomerDTO>();

        foreach (CustomerDTO newCustomer in customers)
        {
            var existsCpf = Data.getData().customers.FirstOrDefault(n => n.Cpf == newCustomer.Cpf);

            if (existsCpf != null) {
                CustomerDTO returnObj = new CustomerDTO(){
                    Name = existsCpf.Name,
                    Cpf = existsCpf.Cpf
                };
                 return Conflict(returnObj);
            }

            else
            {
                newCustomers.Add(new Customer()
                {
                    Id = Data.getData().customers.Max(n => n.Id) + 1,
                    Name = newCustomer.Name,
                    Cpf = newCustomer.Cpf
                }
                );
                newCustomersDTOs.Add(new CustomerDTO(){
                    Name = newCustomer.Name,
                    Cpf = newCustomer.Cpf
                
                });
            }
        }
        Data.getData().customers.AddRange(newCustomers);

        return Ok(newCustomersDTOs);

        //return CreatedAtRoute(
        //     $"GetCustomerById{newCustomers.First().Id}",
        //     new{id = newCustomers.First().Id},
        //     newCustomers.First()
        // );
    }

    [HttpPost]
    [Route("CreateCustomer")]
    public ActionResult<CustomerDTO> CreateCustomer(CustomerDTO newCustomer)
    {

        var existsCpf = Data.getData().customers.FirstOrDefault(n => n.Cpf == newCustomer.Cpf);
        var newCustomerDTO = new CustomerDTO(){
            Name = newCustomer.Name,
            Cpf = newCustomer.Cpf
        };

        if (existsCpf != null) {
            
             return Conflict(newCustomerDTO); 
        }

        else
        {
            Data.getData().customers.Add(new Customer()
            {
                Id = Data.getData().customers.Max(n => n.Id) + 1,
                Name = newCustomer.Name,
                Cpf = newCustomer.Cpf
            }
            );
        }

        // return CreatedAtRoute(
        //     $"GetCustomerById",
        //     new{id = newCustomer.Id},
        //     newCustomer
        // );

        return Ok(newCustomerDTO);
    }

    [HttpPut]
    [Route("EditCustomerByCpf/{cpf}")]
    public ActionResult<CustomerDTO> EditCustomer(string cpf, CustomerDTO editedCustomer)
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
            CustomerDTO returnCustomerDTO = new CustomerDTO(){
                Name = editedCustomer.Name,
                Cpf = editedCustomer.Cpf
            };

            Data.getData().customers[Data.getData().customers.IndexOf(oldCustomer)] = newCustomer;


            return Ok(returnCustomerDTO);
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
            return NotFound(cpf);
        }

        existingCustomers.Remove(customerToRemove);

        return Ok(new CustomerDTO(){
            Name = customerToRemove.Name,
            Cpf = customerToRemove.Cpf
        });
    }
}