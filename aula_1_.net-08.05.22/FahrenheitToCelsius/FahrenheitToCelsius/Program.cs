using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FahrenheitToCelsius
{
    class Program
    {
        static void Main(string[] args)
        {
            fahrenheitToCelsius();
        }
        static void fahrenheitToCelsius()
        {
            double tempCelsius = 0.0;
            double tempFahrenheit = 0.0;

            do
            {
                Console.Write("Digite a temperatura em graus Fahrenheit: ");
            }
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out tempFahrenheit));
            tempCelsius = (tempFahrenheit - 32)*5/9;
            Console.Write("A temperatura {0}° Fahrenheit em Celsius fica {1}", tempFahrenheit, tempCelsius.ToString("0.00"));
            Console.ReadKey();
        }
    }
}
