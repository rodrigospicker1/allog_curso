using System.Security.Cryptography;
using System.Text;

var mensagem = "univali";
Console.WriteLine("Mensagem: {0}", mensagem);

// Cria um array de 32 caracteres(16x8=128/4=32)
byte[] chave = new byte[16];
Console.WriteLine(BitConverter.ToString(chave));

// Gera uma chave aleatória de 16 bytes
// Método fill preenche o próprio array enviado como argumento
RandomNumberGenerator.Fill(chave);
Console.WriteLine(BitConverter.ToString(chave));

//Cria uma instância de HMACSHA256
// Recebe no construtor a chave que será usada na assinatura
var hmac = new HMACSHA256(chave);

// Recebe um array de bytes que representa a mensagem a ser processada
// Retorna um novo array de bytes que contém o valor hash calculado.
var hmacResult = hmac.ComputeHash(Encoding.ASCII.GetBytes(mensagem));

// "BitConverter" converte um tipo bytes para um tipo primitivo e vice-versa
Console.WriteLine("Senha: {0}", 
    BitConverter.ToString(chave).ToLower().Replace("-", string.Empty));
Console.WriteLine("HMAC-SHA-256: {0}", 
    BitConverter.ToString(hmacResult).ToLower().Replace("-", string.Empty));