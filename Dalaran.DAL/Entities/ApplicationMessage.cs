using Dalaran.DAL.Interfaces;

namespace Dalaran.DAL.Entities
{
    public class ApplicationMessage : IEntity
    {
        public string KeyName { get; set; }
        public string Message { get; set; }
    }
}
