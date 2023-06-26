// dotnet add package Blake3 --version 0.5.1
using System.Text;

var message = "Univali";

var hash = Blake3.Hasher.Hash(Encoding.UTF8.GetBytes(message));
Console.WriteLine($"Blake3: {hash}");
