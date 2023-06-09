using System.Runtime.CompilerServices;
using Univali.Api.Entities;

namespace Univali.Api.Controllers;

public class Data
{
    public List<Customer> customers { get; set; }
    static private Data _data;

    private Data()
    {
        this.customers = new List<Customer>{
            new Customer
            {
                Id = 1,
                Name = "Linus Trovalds",
                Cpf = "13967998932",
                Addresses = new List<Address>{
                    new Address{
                        Cep = "888",
                        Logadouro = "Teste",
                        Numero = 123
                    }
                }
            },
            new Customer
            {
                Id = 2,
                Name = "Jackson Professor",
                Cpf = "98765432198",
                Addresses = new List<Address>{
                    new Address{
                        Cep = "888",
                        Logadouro = "Teste",
                        Numero = 123
                    }
                }
            }
        };
    }

    public static Data getData()
    {
        if (_data == null)
        {
            _data = new Data();
        }
        return _data;
    }
}