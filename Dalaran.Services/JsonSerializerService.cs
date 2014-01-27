using Dalaran.Services.Interfaces;
using Newtonsoft.Json;

namespace Dalaran.Services
{
    public class JsonSerializerService : IJsonSerializerService
    {
        public string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public T DeSerialize<T>(string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
