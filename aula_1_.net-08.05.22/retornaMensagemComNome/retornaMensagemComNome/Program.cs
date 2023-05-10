using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace retornaMensagemComNome
{
    class Program
    {
        static void Main(string[] args)
        {
            retornaNomeComMensagem();
        }

        static void retornaNomeComMensagem()
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();

            Console.Write("Olá meu nome é: {0}", nome);
            Console.ReadKey();
        }
    }
}
