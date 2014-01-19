
namespace Dalaran.Services.Interfaces
{
    public interface IEncryptionService
    {
        string Encrypt(string data, string salt);
        string GenerateSalt();
        bool Compare(string data, string salt, string password);
    }
}