using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Extensions
{
    public class Constants
    {
        public static class IdentityAuthenticationApi
        {
            public const string Login =    "api/identity/Login";
            public const string Register = "api/identity/Register";
        }

        public static class UserRolesApi
        {
            public const string GetRoles = "api/Roles/GetRoles";
        }
    }
}
