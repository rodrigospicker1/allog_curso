// dotnet add package Blake3 --version 0.5.1
using System.Security.Cryptography;
using System.Text;

var message = "Univali";

Console.WriteLine();
using (var sha256Hash = SHA256.Create())
{
    var hash256 = sha256Hash.ComputeHash(Encoding.ASCII.GetBytes(message));
    Console.WriteLine(
        "SHA-256: {0}",
        BitConverter.ToString(hash256).ToLower().Replace("-", string.Empty)
    );
}

Console.WriteLine();
using (var sha512Hash = SHA512.Create())
{
    var hash512 = sha512Hash.ComputeHash(Encoding.ASCII.GetBytes(message));
    Console.WriteLine(
        "SHA-512: {0}",
        BitConverter.ToString(hash512).ToLower().Replace("-", string.Empty)
    );
}

Console.WriteLine();
var hashBlake3 = Blake3.Hasher.Hash(Encoding.UTF8.GetBytes(message));
Console.WriteLine("Blake3: {0}", hashBlake3);
