﻿using Model.BusinessComponents.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.BusinessComponents.Roles
{
    public class AppUserRoles
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int AppRoleI { get; set; }
    }
}
