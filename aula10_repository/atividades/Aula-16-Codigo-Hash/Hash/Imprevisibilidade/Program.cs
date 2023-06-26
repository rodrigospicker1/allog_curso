using System.Security.Cryptography;
using System.Text;

var messages = new[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

using (var sha256Hash = SHA256.Create())
{
    foreach (var message in messages)
    {
        var hash = sha256Hash.ComputeHash(Encoding.ASCII.GetBytes(message));
        Console.WriteLine(
            "SHA-256: {0} : {1}", message,
            BitConverter.ToString(hash).ToLower().Replace("-", string.Empty)
        );
    }
}

using (var sha512Hash = SHA512.Create())
{
    foreach (var message in messages)
    {
        var hash = sha512Hash.ComputeHash(Encoding.ASCII.GetBytes(message));
        Console.WriteLine(
            "SHA-512:  {0} : {1}", message,
            BitConverter.ToString(hash).ToLower().Replace("-", string.Empty)
        );
    }
}

foreach (var message in messages)
{
    var hash = Blake3.Hasher.Hash(Encoding.UTF8.GetBytes(message));
    Console.WriteLine("Blake3: {0} : {1}", message, hash);
}
