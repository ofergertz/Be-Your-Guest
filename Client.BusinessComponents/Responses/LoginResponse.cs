using BeMyGuest.Shared.Model.Requests.Identity;

namespace Client.BusinessComponents.Requests.Identity
{
    public class LoginResponse : ILoginResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public string UserImageURL { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
