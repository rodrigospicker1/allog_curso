// dotnet add package Blake3 --version 0.5.1
using System.Security.Cryptography;
using System.Text;

var mensagens = new[]
{
    "a",
    "Univali",
    "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum."
};

using (var sha256Hash = SHA256.Create())
{
    foreach (var mensagem in mensagens)
    {
        var hash = sha256Hash.ComputeHash(Encoding.ASCII.GetBytes(mensagem));
        Console.WriteLine(
            "SHA-256: {0}",
            BitConverter.ToString(hash).ToLower().Replace("-", string.Empty)
        );
    }
}

using (var sha512Hash = SHA512.Create())
{
    foreach (var mensagem in mensagens)
    {
        var hash = sha512Hash.ComputeHash(Encoding.ASCII.GetBytes(mensagem));
        Console.WriteLine(
            "SHA-512: {0}",
            BitConverter.ToString(hash).ToLower().Replace("-", string.Empty)
        );
    }
}

foreach (var mensagem in mensagens)
{
    var hash = Blake3.Hasher.Hash(Encoding.UTF8.GetBytes(mensagem));
    Console.WriteLine("Blake3: {0}", hash);
}
