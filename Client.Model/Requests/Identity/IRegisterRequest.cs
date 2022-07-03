using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model.Requests.Identity
{
    public interface IRegisterRequest
    {
         string FirstName { get; set; }
         string LastName { get; set; }
         string Email { get; set; }
         string UserName { get; set; }
         string Address { get; set; }
         string Password { get; set; }
        string ConfirmEmail { get; set; }
        string ConfirmPassword { get; set; }
        string PhoneNumber { get; set; }
        bool ActivateUser { get; set; } 
        bool AutoConfirmEmail { get; set; }
    }
}
