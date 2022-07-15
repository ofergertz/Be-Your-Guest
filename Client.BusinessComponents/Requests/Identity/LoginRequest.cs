using BeMyGuest.Shared.Model.Requests.Identity;
using System.ComponentModel.DataAnnotations;

namespace Client.BusinessComponents.Requests.Identity
{
    public class LoginRequest : ILoginRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
