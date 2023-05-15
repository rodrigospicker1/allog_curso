using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static POO_1.Cliente;

namespace POO_1
{
    class Program
    {
        static void Main()
        {
            int escolha = 0;

            while(escolha != 5)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Digite ->");
                    Console.WriteLine("1 para cadastrar cliente");
                    Console.WriteLine("2 para editar cliente");
                    Console.WriteLine("3 para exluir cliente");
                    Console.WriteLine("4 para listar cliente");
                    Console.Write("Escolha: ");
                }
                while (!int.TryParse(Console.ReadLine(), out escolha));

                if (escolha == 1)
                {
                    Cliente.add();
                }else if(escolha == 4)
                {
                    Cliente.readAll();
                }

            }
        }
        
    }
}
