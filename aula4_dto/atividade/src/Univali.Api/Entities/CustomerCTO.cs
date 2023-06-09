namespace Univali.Api.Entities;

public class CustomerDTO
{
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public List<Address> Addresses { get; set; } = new List<Address>();

}

