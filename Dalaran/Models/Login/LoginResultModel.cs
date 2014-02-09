using Dalaran.Models.Operations;

namespace Dalaran.Models.Login
{
    public class LoginResultModel : OperationResult
    {
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}