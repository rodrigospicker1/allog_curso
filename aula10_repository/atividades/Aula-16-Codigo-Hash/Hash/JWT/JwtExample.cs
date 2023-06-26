using System.Text;


namespace jwt
{
    static class JwsExample
    {
        public static void ShowHeaderPayload(string headerSegment, string payloadSegment)
        {
            Console.WriteLine("#######################      PASSO 1: Cria o Header e o Payload     #######################");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Header: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(headerSegment);
            Console.ResetColor();
            Console.WriteLine();

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Payload:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(payloadSegment);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ShowBase64Parts(string header, string payload)
        {
            Console.WriteLine();
            Console.WriteLine("#######################      PASSO 2: Transforma Head e Payload em Base64Url      #######################");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Header: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(header);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Payload: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(payload);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ShowSignatureParts(string signatureSegment)
        {
            string[] parts = signatureSegment.Split('.');
            string header = parts[0];
            string payload = parts[1];

            Console.WriteLine();
            Console.WriteLine("#######################      PASSO 3: Gera o que será assinado      #######################");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Formato da Assinatura: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("<header-base64url>.<payload-base64url>");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("O que sera assinado: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(header);
            Console.ResetColor();
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(payload);
            Console.ResetColor();
            Console.WriteLine();
        }


        public static void ShowKeyInfo(byte[] key)
        {
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("#######################      PASSO 4: Cria chave de assinatura      #######################");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Chave: ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(Convert.ToBase64String(key));
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ShowSignatureBytes(byte[] signatureBytes)
        {
            Console.WriteLine();
            Console.WriteLine("#######################      PASSO 5: Assina com HMACSHA256       #######################");
            Console.WriteLine();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Assinatura: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("HMAC-SHA-256");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Assinatura: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(PrintByteArray(signatureBytes));
            Console.WriteLine();
        }

        public static void ShowSignatureBase64Url(string signature)
        {
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("#######################      PASSO 6: Transforma assinatura em Base64Url      #######################");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Assinatura: ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(signature);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void ShowJws(string jwt)
        {
            string[] parts = jwt.Split('.');
            string header = parts[0];
            string payload = parts[1];
            string signature = parts[2];

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("#######################      PASSO 7: Monta a estrutura JWS/JWT     #######################");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Formato JWS: ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("<header-base64url>.<payload-base64url>.<assinatura-base64url>");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("JWS: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(header);
            Console.ResetColor();
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(payload);
            Console.ResetColor();
            Console.Write(".");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(signature);
            Console.ResetColor();
            Console.WriteLine();
        }

        public static string PrintByteArray(byte[] bytes)
        {
            var sb = new StringBuilder("new byte[] { ");
            foreach (var b in bytes)
            {
                sb.Append(b + ", ");
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
