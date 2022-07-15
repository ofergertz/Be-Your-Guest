using BeMyGuest.Shared.Model.Responses.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.BusinessComponents.Responses
{
    public class RegisterResponse : IRegisterResponse
    {
        public string UserName {get;set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
