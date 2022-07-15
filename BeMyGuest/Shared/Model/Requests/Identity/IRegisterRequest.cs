using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.Requests.Identity
{
    public interface IRegisterRequest
    {
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }
        string ConfirmEmail { get; set; }
        string Password { get; set; }
        string ConfirmPassword { get; set; }
        string Address { get; set; }
        string ProfilePicture { get; set; }
        List<string> Proffesion { get; set; }
        bool ActivateUser { get; set; } 
    }
}
