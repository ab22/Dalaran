using System.Collections.Generic;

namespace Dalaran.Infrastructure.Interfaces
{
    public interface IMessageProvider
    {
        string GetMessage(string key);
        List<string> GetMessages(string[] keys);
    }
}
