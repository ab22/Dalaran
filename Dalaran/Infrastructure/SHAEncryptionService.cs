using Dalaran.Infrastructure.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Dalaran.Infrastructure
{
    public class SHAEncryptionService : IEncryptionService
    {
        string Encrypt(string data, string salt)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] saltedData = Encoding.UTF8.GetBytes(data+salt);

            byte[] hashedBytes = sha256.ComputeHash(saltedData);

            return BitConverter.ToString(hashedBytes);
        }
    }
}