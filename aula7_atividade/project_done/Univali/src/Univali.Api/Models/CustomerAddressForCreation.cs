namespace Univali.Api.Models
{
   public class CustomerAddressForCreationDto
   {
    public int Id {get; set;}
    public string Name {get; set;} = string.Empty;
    public string Cpf {get; set;} = string.Empty;
    public ICollection<Address> Addresses {get;set;} = new List<Address>();
    }
}
