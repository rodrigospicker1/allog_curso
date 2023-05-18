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

        public static bool verifyEmail(string eMail){
            if(eMail == ""){
                return false;
            }
            int teste = eMail.IndexOf("@");
            if(teste != -1){
                string[] dados = eMail.Split('@');
                string[] depoisAroba = dados[1].Split('.');
                if(depoisAroba[0] != "" && depoisAroba[1] != ""){
                    return true;
                }else{
                    return false;
                }
            }else{
                return false;
            }
        }

        public static void add()
        {
            Console.Clear();
            Console.WriteLine("Adicione um novo usuário");
            Console.Write("Digite o seu nome: ");
            string name = Console.ReadLine();
            Console.Write("Digite o seu endereço: ");
            string address = Console.ReadLine();
            Console.Write("Digite o seu telefone: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Digite o seu email: ");
            string eMail = Console.ReadLine();
            while(verifyEmail(eMail) != true){
                Console.Write("Email inválido, digite o1 email denovo: ");
                eMail = Console.ReadLine();
            }
            
            string path = "C:/Users/sysadmin/Desktop/Projetos/.NET/allog_curso-main/allog_curso-main/Teste.net/teste.csv";
            int id = 1;
            var lines = File.ReadAllLines(path);
            var all = File.ReadAllText(path);
            if(all != ""){
                var last_line = lines.Last();
                var dados = last_line.Split(',');
                id = int.Parse(dados[0])+1;
            }

            string client_details = id + "," + name + "," + address + "," + phoneNumber + "," + eMail;
            create_line(client_details);
            Console.Clear();
            Console.Write("Usuário inserido com sucesso\n");
        }

        public static void deleteById()
        {
            Console.Write("Qual id você deseja deletar: ");
            string id = Console.ReadLine();

            string path = "C:/Users/sysadmin/Desktop/Projetos/.NET/allog_curso-main/allog_curso-main/Teste.net/teste.csv";
            var lines = File.ReadLines(path);
            var Result = new List<string>();
            int find = 0;
            foreach (var line in lines){
                string[] dados = line.Split(',');
                if(dados[0] != id){
                    Result.Add(line);                        
                }else{
                    find=1;
                }
            }
            File.WriteAllLines(path, Result);

            Console.Clear();
            if(find == 0){
                Console.WriteLine("Usuário não encontrado\n");
            }else{
                Console.WriteLine("Usuário deletado com sucesso\n");
            }
        }

        public static void searchById()
        {
            Console.Write("Qual id você deseja ver: ");
            string id = Console.ReadLine();
            Console.Clear();
            string path = "C:/Users/sysadmin/Desktop/Projetos/.NET/allog_curso-main/allog_curso-main/Teste.net/teste.csv";
            var lines = File.ReadLines(path);
            foreach (var line in lines){
                string[] dados = line.Split(',');
                if(dados[0] == id){  
                    Console.WriteLine("Usuário encontrado"); 
                    Console.WriteLine("Nome: "+dados[1]); 
                    Console.WriteLine("Endereço: "+dados[2]);  
                    Console.WriteLine("Telefone: "+dados[3]); 
                    Console.WriteLine("Email: "+dados[4]+"\n");   
                    return;          
                }
            }
            Console.WriteLine("Usuário encontrado\n");
        }

        public static void listAll()
        {
            readAll();
        }

        public static void editById()
        {
            Console.Write("Qual id você deseja ver: ");
            string id = Console.ReadLine();
            Console.Clear();
            string path = "C:/Users/sysadmin/Desktop/Projetos/.NET/allog_curso-main/allog_curso-main/Teste.net/teste.csv";
            var lines = File.ReadLines(path);
            var Result = new List<string>();
            int find = 0;
            foreach (var line in lines){
                string[] dados = line.Split(',');
                if(dados[0] != id){
                    Result.Add(line);                        
                }else{
                    find = 1;
                    Console.Write("Usuário encontrado\n");
                    Console.Write("Digite o novo nome: ");
                    string name = Console.ReadLine();
                    Console.Write("Digite o novo endereço: ");  
                    string address = Console.ReadLine();
                    Console.Write("Digite o novo telefone: ");
                    string phoneNumber = Console.ReadLine();
                    Console.Write("Digite o novo email: ");
                    string eMail = Console.ReadLine();
                    while(verifyEmail(eMail)){
                      Console.Write("Email inválido, digite o novo email denovo: ");
                    eMail = Console.ReadLine();
                    }

                    string client_details = line[0] + "," + name + "," + address + "," + phoneNumber + "," + eMail;
                    Result.Add(client_details);
                    
                }
            }
            File.WriteAllLines(path, Result);
            Console.Clear();
            if(find == 0){
                Console.Write("Usuário não encontrado\n");
            }else{
                Console.Write("Usuário atualizado com sucesso\n");
            }
        }

        public static void create_line(string client_detail)
        {
            string path = "C:/Users/sysadmin/Desktop/Projetos/.NET/allog_curso-main/allog_curso-main/Teste.net/teste.csv";
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
            string path = "C:/Users/sysadmin/Desktop/Projetos/.NET/allog_curso-main/allog_curso-main/Teste.net/teste.csv";
            if (File.Exists(path))
            {
                Console.Clear();
                var lines = File.ReadLines(path);
                foreach (var line in lines){
                    string[] dados = line.Split(',');
                        Console.WriteLine("\nNome: "+dados[1]); 
                        Console.WriteLine("Endereço: "+dados[2]);  
                        Console.WriteLine("Telefone: "+dados[3]); 
                        Console.WriteLine("Email: "+dados[4]+"\n");      
            }
            }
        }

    }