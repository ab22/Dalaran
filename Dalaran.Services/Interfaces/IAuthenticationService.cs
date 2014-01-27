using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dalaran.Services.Interfaces
{
    public interface IAuthenticationService
    {
        void StartSession(object data);
        void EndSession();
        bool IsAuthenticated();
    }
}
