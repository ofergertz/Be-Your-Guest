using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.Requests.Identity
{
    public interface ILoginResponse
    {
        string Token { get; set; }
        string RefreshToken { get; set; }
        string UserImageURL { get; set; }
        DateTime RefreshTokenExpiryTime { get; set; }
    }
}
