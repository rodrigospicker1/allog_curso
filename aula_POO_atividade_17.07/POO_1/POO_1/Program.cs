class Program
    {
        static void Main()
        {
            int escolha = 0;
            Console.Clear();

            while(escolha != 6)
            {
                do
                {
                    Console.WriteLine("Digite ->");
                    Console.WriteLine("1 para cadastrar cliente");
                    Console.WriteLine("2 para editar cliente");
                    Console.WriteLine("3 para exluir cliente");
                    Console.WriteLine("4 para listar cliente");
                    Console.WriteLine("5 para listar todos cliente");
                    Console.WriteLine("6 para SAIR");
                    Console.Write("Escolha: ");
                }
                while (!int.TryParse(Console.ReadLine(), out escolha));

                if (escolha == 1){
                    Cliente.add();
                }else if(escolha == 2){
                    Cliente.editById();
                }else if(escolha == 3){
                    Cliente.deleteById();
                }else if(escolha == 4){
                    Cliente.searchById();
                }else if(escolha == 5){
                    Cliente.listAll();
                }else{
                    Console.Clear();
                }

            }
        }
        
    }