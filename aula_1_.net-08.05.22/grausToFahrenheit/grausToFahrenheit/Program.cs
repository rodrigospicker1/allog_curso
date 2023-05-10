using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grausToFahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {
            grausToFahrenheit();
        }

        static void grausToFahrenheit()
        {
            double tempCelsius = 0.0;
            double tempFahrenheit = 0.0;

            do
            {
                Console.Write("Digite a temperatura em graus celsius: ");
            }
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out tempCelsius));
            tempFahrenheit = (9 * tempCelsius + 160) / 5;
            Console.Write("A temperatura {0}° Celsius em Fahrenheit fica {1}", tempCelsius, tempFahrenheit);
            Console.ReadKey();

        }
    }
}
