// dotnet add package Microsoft.AspNetCore.Cryptography.KeyDerivation
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

Console.Write("Enter a password: ");
string? password = Console.ReadLine();

/*
Gere um salt de 128 bits usando uma sequência de bytes aleatórios
    criptograficamente fortes.
"RandomNumberGenerator" fornece funcionalidades para gerar valores aleatórios.
"GetBytes" cria uma matriz de bytes com uma sequência aleatória
    criptograficamente forte de valores.
"128 / 8" converte bits para bytes
*/
byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

//Converte para Base64 que possui os caracteres [A-Z,a-z,0-9,/,+] mais o sufixo =
Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

/*
Deriva uma subchave de 256 bits com HMAC
"password": A senha da qual derivar a chave.
"salt": O sal a ser usado durante o processo de derivação de chave.
"prf": A função pseudo-aleatória a ser usada no processo de derivação de chave.
"iterationCount": O número de iterações da função pseudo-aleatória a aplicar
    durante o processo de derivação de chave.
numBytesRequested: O comprimento desejado (em bytes) da chave derivada.
 */
string hashed = Convert.ToBase64String(
    KeyDerivation.Pbkdf2(
        password: password!,
        salt: salt,
        prf: KeyDerivationPrf.HMACSHA256,
        iterationCount: 310000,
        numBytesRequested: 256 / 8
    )
);

Console.WriteLine($"Hashed: {hashed}");
