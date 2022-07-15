using BeMyGuest.Shared.Model.Requests.Identity;
using Model.BusinessComponents.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.BusinessComponents.Identity
{
    public class UserCredential : IUserCredential
    {
        public Guid UserCredentialId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
    }
}
