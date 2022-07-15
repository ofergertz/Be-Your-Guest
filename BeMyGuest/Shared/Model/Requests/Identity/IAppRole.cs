using Model.BusinessComponents.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.Requests.Identity
{
    public interface IAppRole
    {
        int AppRoleId { get; set; }
        string RoleName { get; set; }
        List<User> Users { get; set; }
    }
}
