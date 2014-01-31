namespace Dalaran.Services.Interfaces
{
    public interface IAuthenticationService
    {
        void StartSession(object data);
        void EndSession();
        bool IsAuthenticated();
    }
}
