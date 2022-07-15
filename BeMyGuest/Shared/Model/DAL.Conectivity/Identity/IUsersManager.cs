using BeMyGuest.Shared.Model.Requests.Identity;
using BeMyGuest.Shared.Model.Responses.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.DAL.Conectivity.Identity
{
    public interface IUsersManager
    {
        Task<IUser> FindByEmailAsync(string email);
        Task<IRegisterResponse> CreateUserAsync(IRegisterRequest registerRequest);
        bool CheckPassword(IUser user, string password);
        Task UpdateUserAsync(IUser user);
    }
}
