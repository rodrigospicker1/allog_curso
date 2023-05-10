using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trocaAsemReplace
{
    class Program
    {
        static void Main(string[] args)
        {
            trocaAsemReplace();
        }

        static void trocaAsemReplace()
        {

            Console.Write("Digite uma frase: ");
            string frase = Console.ReadLine();
            char[] chars = frase.ToCharArray();
            Console.Write("Frase digitada trocando 'A' por '&' fica: ");
            for (int i = 0; i < chars.Length; i++)
            {
                if (chars[i] == 'A')
                {
                    chars[i] = '&';
                }
                Console.Write(chars[i]);
            }

            Console.ReadKey();
        }
    }
}
