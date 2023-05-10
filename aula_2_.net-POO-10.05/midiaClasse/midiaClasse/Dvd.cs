using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midiaClasse
{
    class Dvd:Midia
    {
        public string produtor { get; set; }
        public string diretor { get; set; }

        public Dvd()
        {
        }

        public Dvd(string produtor, string diretor, int codigo, string titulo, int ano, float valor, string categoria) : base(codigo, titulo, ano, valor, categoria)
        {
            this.produtor = produtor;
            this.diretor = diretor;
        }

        public void Listar()
        {
            Console.WriteLine("Código: {0}", codigo);
            Console.WriteLine("Título: {0}", titulo);
            Console.WriteLine("Ano: {0}", ano);
            Console.WriteLine("Valor: {0}", valor);
            Console.WriteLine("Categoria: {0}", valor);
            Console.WriteLine("Produtor: {0}", produtor);
            Console.WriteLine("Diretor: {0}",  diretor);
        }

        public void Cadastrar()
        {
            string esc = "";
            string value = "";

            while (esc != "1" && esc != "2" && esc != "2" && esc != "3" && esc != "4" && esc != "5" && esc != "6" && esc != "7")
            {
                Console.WriteLine("");
                Console.WriteLine("1 - código");
                Console.WriteLine("2 - titulo");
                Console.WriteLine("3 - ano");
                Console.WriteLine("4 - valor");
                Console.WriteLine("5 - categoria");
                Console.WriteLine("6 - produtor");
                Console.WriteLine("7 - produtor");
                Console.Write("Digite o número do item: ");
                esc = Console.ReadLine();
                Console.Write("Digite o valor que ele vai receber: ");
                value = Console.ReadLine();
            }

            if(esc == "1") { codigo = Int32.Parse(value);  }
            if(esc == "2") { titulo = value; }
            if(esc == "3") { ano = Int32.Parse(value); }
            if(esc == "4") { valor = (float)Convert.ToDouble(value); }
            if(esc == "5") { categoria = value; }
            if(esc == "6") { produtor = value; }
            if(esc == "7") { diretor = value; }
        }
    }
}
