using BeMyGuest.Shared.Model.BusinessServices;
using BeMyGuest.Shared.Model.Requests.Identity;

namespace Client.Model.Responses.Identity
{
    public interface IAuthenticationManager
    {
        Task<IServiceWrapper> Login(ILoginRequest loginRequest);
        Task<IServiceWrapper> Register(IRegisterRequest registerRequest);
        Task<IServiceWrapper> Logout();

    }
}
