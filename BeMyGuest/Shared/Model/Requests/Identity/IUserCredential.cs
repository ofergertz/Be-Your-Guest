using Model.BusinessComponents.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.Requests.Identity
{
    public interface IUserCredential
    {
        Guid UserCredentialId { get; set; }
        string UserName { get; set; }
        string Password { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? LastModifiedOn { get; set; }
    }
}
