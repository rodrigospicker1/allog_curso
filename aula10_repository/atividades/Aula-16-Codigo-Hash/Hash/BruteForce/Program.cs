// dotnet add package Sodium.Core --version 1.3.3
// dotnet add package Blake3 --version 0.5.1
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Sodium;

long _time = 20_000;
double seconds = 0;
var hashCount = 0;

var MD5 = (string password, out double totaltime, out int count) =>
{
    var seconds = Stopwatch.StartNew();
    var hashCount = 0;
    var bytes = Encoding.ASCII.GetBytes(password);
    var md5 = System.Security.Cryptography.MD5.Create();
    do
    {
        md5.ComputeHash(bytes);
        hashCount++;
    } while (seconds.ElapsedMilliseconds < _time);

    seconds.Stop();
    totaltime = seconds.Elapsed.TotalSeconds;
    count = hashCount;
};

var Blake = (string password, out double totaltime, out int count) =>
{
    var seconds = Stopwatch.StartNew();
    var hashCount = 0;
    var bytes = Encoding.ASCII.GetBytes(password);

    do
    {
        Blake3.Hasher.Hash(bytes);
        hashCount++;
    } while (seconds.ElapsedMilliseconds < _time);

    seconds.Stop();
    totaltime = seconds.Elapsed.TotalSeconds;
    count = hashCount;
};

var Sha256 = (string password, out double totaltime, out int count) =>
{
    var shA256Managed = SHA256.Create();
    var bytes = Encoding.ASCII.GetBytes(password);

    var seconds = Stopwatch.StartNew();
    var hashCount = 0;
    do
    {
        shA256Managed.ComputeHash(bytes);
        hashCount++;
    } while (seconds.ElapsedMilliseconds < _time);

    seconds.Stop();
    totaltime = seconds.Elapsed.TotalSeconds;
    count = hashCount;
};



var password = "Sup3rSecr3t";
Console.WriteLine($"Quantas senhas podem ser hasheadas em 20 segundos?");
Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("            MD5 hashes");
MD5(password, out seconds, out hashCount);
Console.WriteLine($"MD5: {hashCount.ToString("N0")}");

Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("            SHA256 hashes");

Sha256(password, out seconds, out hashCount);
Console.WriteLine($"SHA256: {hashCount:N0}");

Console.WriteLine();
Console.WriteLine("========================================");
Console.WriteLine("            BLAKE hashes");

Blake(password, out seconds, out hashCount);
Console.WriteLine($"Blake3: {hashCount:N0}");

Console.WriteLine();
