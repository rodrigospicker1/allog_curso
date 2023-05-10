using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reajusteSalarial
{
    class Program
    {
        static void Main(string[] args)
        {
            reajusteSalarial();
        }
        static void reajusteSalarial()
        {
            double salario = 0.0;

            do
            {
                Console.Write("Digite o seu salário, R$ ");
            }
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out salario));

            if(salario >= 1850)
            {
                salario +=180;
            }
            else if(salario < 1850 && salario > 0)
            {
                salario +=320;
            }

            Console.Write("Seu salário com reajuste fica, R$ {0}", salario);
            Console.ReadKey();

        }
    }
}
