using BeMyGuest.Shared.Model.BusinessServices;
using BeMyGuest.Shared.Model.Requests.Identity;
using BeMyGuest.Shared.Model.Responses.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Services
{
    public interface IIdentityService : IService
    {
        Task<IServiceWrapper<ILoginResponse>> LoginAsync(ILoginRequest loginModel);
        Task<IServiceWrapper<IRegisterResponse>> RegisterAsync(IRegisterRequest registerModel);
    }
}
