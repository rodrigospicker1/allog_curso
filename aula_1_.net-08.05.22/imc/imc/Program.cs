using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imc
{
    class Program
    {
        static void Main(string[] args)
        {
            imc();
        }

        static void imc()
        {
            double peso = 0.0;
            double altura = 0.0;
            double imc = 0.0;

            do
            {
                Console.Write("Digite seu peso (kg): ");
            }
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out peso));
            do
            {
                Console.Write("Digite sua altura (metros): ");
            }
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out altura));
            imc = peso / (altura * altura);
            Console.Write("Seu imc é {0}", imc.ToString("0.00"));
            Console.ReadKey();
        }
    }
}
