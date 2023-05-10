using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace midiaClasse
{
    class Program
    {
        public static int menu()
        {
            int option = 0;

            while (option != 1 && option != 2 && option != 3 && option != 4)
            {

                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("0 -> Sair");
                    Console.WriteLine("1 -> Listar");
                    Console.WriteLine("2 -> Pesquisar");
                    Console.WriteLine("3 -> Cadastrar");
                    Console.WriteLine("4 -> Alterar");
                    Console.Write("Digite o que você quer: ");
                }
                while (!int.TryParse(Console.ReadLine(), out option));

            }
            return option;
        }

        static void Main(string[] args)
        {
            string escolha = "";
            var listaLivros = new List<Livro>();

            while (escolha != "1" &&  escolha != "2"){
                    Console.Clear();
                    Console.WriteLine("Digite o que você quer adicionar");
                    Console.WriteLine("1 -> Opções de Dvd");
                    Console.WriteLine("2 -> Opções de Livro");
                    Console.Write("Digite: ");
                    escolha = Console.ReadLine();
             }

            if (escolha == "1")
            {
                int option = menu();

                while (option != 0)
                {
                    if (option == 1)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Listar: ");
                        dvd1.Listar();
                        option = menu();
                    }
                    if (option == 3)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Cadastrar: ");
                        dvd1.Cadastrar();
                        option = menu();
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
