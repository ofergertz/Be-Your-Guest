using BeMyGuest.Shared.Model.Requests.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessComponents.Identity
{
    public class AppRole : IAppRole
    {
        public int AppRoleId { get; set; }
        public string RoleName { get; set; }

        public List<User> Users { get; set; }
    }
}
