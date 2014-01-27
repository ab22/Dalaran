using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalaran.Services.Interfaces
{
    public interface IJsonSerializerService
    {
        string Serialize(object data);
        T DeSerialize<T>(string data);
    }
}
