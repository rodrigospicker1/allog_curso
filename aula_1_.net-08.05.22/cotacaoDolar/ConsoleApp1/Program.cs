using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            cotacaoDolar();
        }

        static void cotacaoDolar()
        {

            double cotacao = 0.0;
            double valor = 0.0;
            double valorConvertido = 0.0;

            do
            {
                Console.WriteLine("Digite a cotação do dolar");
                Console.Write("Cotação: ");
            }
            while (!double.TryParse(Console.ReadLine().Replace(".",","), out cotacao));
            do
            {
                Console.WriteLine("Digite o valor que você deseja converter");
                Console.Write("$: ");
            }
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out valor));
            valorConvertido = (float)(valor * cotacao);
            Console.Write("O valor digitado em dólar pra reais é, R$ ");
            Console.Write(valorConvertido.ToString("0.00"));
            Console.ReadKey();

        }

    }
}
