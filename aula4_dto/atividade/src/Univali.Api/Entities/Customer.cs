namespace Univali.Api.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;

    public List<Address> Addresses { get; set; } = new List<Address>();

}
public class Address
    {

        public string Cep { get; set; } = string.Empty;
        public string Logadouro {get; set;} = string.Empty;

        public int Numero {get; set;}
}