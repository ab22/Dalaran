using Dalaran.Services.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Dalaran.Services
{
    public class SHAEncryptionService : IEncryptionService
    {
        public string Encrypt(string data, string salt)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] saltedData = Encoding.UTF8.GetBytes(data+salt);

            byte[] hashedBytes = sha256.ComputeHash(saltedData);

            return BitConverter.ToString(hashedBytes);
        }

        public string GenerateSalt()
        {
            return Guid.NewGuid().ToString();
        }
    }
}