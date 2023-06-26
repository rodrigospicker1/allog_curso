// dotnet add package Blake3 --version 0.5.1
using System.Security.Cryptography;
using System.Text;

var messages = new[] { "Univali", "Univale", "Unevali" };

Console.WriteLine();
using (var sha256Hash = SHA256.Create())
{
    foreach (var message in messages)
    {
        var hash = sha256Hash.ComputeHash(Encoding.ASCII.GetBytes(message));
        Console.WriteLine(
            "SHA-256:{0} : {1}", message, 
            BitConverter.ToString(hash).ToLower().Replace("-", string.Empty)
        );
    }
}

Console.WriteLine();
using (var sha512Hash = SHA512.Create())
{
    foreach (var message in messages)
    {
        var hash = sha512Hash.ComputeHash(Encoding.ASCII.GetBytes(message));
        Console.WriteLine(
            "SHA-512: {0} : {1}", message, 
            BitConverter.ToString(hash).ToLower().Replace("-", string.Empty)
        );
    }
}

Console.WriteLine();
foreach (var message in messages)
{
    var hash = Blake3.Hasher.Hash(Encoding.UTF8.GetBytes(message));
    Console.WriteLine("Blake3: {0} : {1}", message, hash);
}
