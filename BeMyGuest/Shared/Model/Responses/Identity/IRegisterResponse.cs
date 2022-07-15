using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.Responses.Identity
{
    public interface IRegisterResponse
    {
        string UserName { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }

    }
}
