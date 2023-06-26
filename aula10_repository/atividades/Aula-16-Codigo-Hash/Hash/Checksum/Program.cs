using System.Security.Cryptography;

string filePath = "../../slide.key";
byte[] fileBytes = File.ReadAllBytes(filePath);

using (HashAlgorithm hashAlgorithm = SHA256.Create())
{
    byte[] hashBytes = hashAlgorithm.ComputeHash(fileBytes);
    string hashString = BitConverter.ToString(hashBytes).Replace("-", string.Empty);

    Console.WriteLine("Checksum do arquivo: " + hashString);
}
