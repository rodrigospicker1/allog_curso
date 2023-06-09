using Microsoft.AspNetCore.Mvc;

namespace Univali.Api.Controllers;

[ApiController]
[Route("api/{controller}")]

public class CustomerController : ControllerBase
{
    [HttpGet("all")]
    public JsonResult GetCustomers(){
        return new JsonResult(
            new List<object>
            {
                new{
                    Id = 1,
                    Name = "Linus Torvalds",
                    Cpf = "73473943096"
                },
                new{
                    Id = 2,
                    Name = "Bill Gates",
                    Cpf = "95395994076"
                }
            }
        );
    }

    public 
}