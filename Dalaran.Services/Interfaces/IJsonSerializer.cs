namespace Dalaran.Services.Interfaces
{
    public interface IJsonSerializerService
    {
        string Serialize(object data);
        T DeSerialize<T>(string data);
    }
}
