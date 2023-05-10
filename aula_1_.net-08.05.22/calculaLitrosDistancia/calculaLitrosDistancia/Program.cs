using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculaLitrosDistancia
{
    class Program
    {
        static void Main(string[] args)
        {
            calculaLitrosDistancia();
        }

        static void calculaLitrosDistancia()
        {
            int velocidadeMedia = 0;
            double tempoViagem = 0.0;
            double distancia = 0.0;
            double quantLitros = 0.0;

            do
            {
                Console.Write("Digite quanto tempo a viagem demorou (horas): ");
            }
            while (!double.TryParse(Console.ReadLine().Replace(".", ","), out tempoViagem));
            do
            {
                Console.Write("Qual velocidade média da viagem (km/h): ");
            }
            while (!int.TryParse(Console.ReadLine().Replace(".", ","), out velocidadeMedia));
            distancia = tempoViagem * velocidadeMedia; 
            quantLitros = distancia / 12;
            Console.WriteLine("--- Cálculo da viagem ---");
            Console.WriteLine("Velocidade média (km/h) -> {0} km/h", velocidadeMedia.ToString("0.00"));
            Console.WriteLine("Tempo gasto -> {0} horas", tempoViagem.ToString("0.00"));
            Console.WriteLine("Distância percorrida -> {0} km", distancia.ToString("0.00"));
            Console.WriteLine("Litros de combustível gasto -> {0} Litos", quantLitros.ToString("0.00"));
            
            Console.ReadKey();
        }
    }
}
