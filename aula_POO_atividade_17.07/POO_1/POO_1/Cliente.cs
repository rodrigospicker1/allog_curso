using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO_1
{
    class Cliente
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string endereço { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }

        public Cliente(int id, string nome, string endereço, string telefone, string email)
        {
            this.id = id;
            this.nome = nome;
            this.endereço = endereço;
            this.telefone = telefone;
            this.email = email;
        }

        public Cliente()
        {
        }


        public static void add()
        {
            Console.Write("Digite o seu nome: ");
            string name = Console.ReadLine();
            Console.Write("Digite o seu endereço: ");
            string address = Console.ReadLine();
            Console.Write("Digite o seu telefone: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Digite o seu email: ");
            string eMail = Console.ReadLine();

            string client_details = name + "," + address + "," + phoneNumber + "," + eMail;
            create_line(client_details);
        }

        public void deleteById()
        {

        }

        public void searchById()
        {

        }

        public void listAll()
        {

        }

        public void editById()
        {

        }

        public static void create_line(string client_detail)
        {
            string path = "C:/Users/8054703/OneDrive/POO_1/POO_1/teste.csv";
            if (File.Exists(path))
            {
                string teste = File.ReadAllText(path);
                if (teste == "")
                {
                    File.AppendAllText(path, client_detail);
                }
                else
                {
                    File.AppendAllText(path, '\n' + client_detail);
                }
            }
        }

        public static void readAll()
        {
            string path = "C:/Users/8054703/OneDrive/POO_1/POO_1/teste.csv";
            if (File.Exists(path))
            {
                string teste = File.ReadAllText(path);
                Console.WriteLine(File.ReadAllText(path));
                Console.Read();
            }
        }

    }
}
