using BeMyGuest.Shared.Model.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.DAL.Conectivity.Roles
{
    public interface IRolesManager
    {
        Task<IServiceWrapper<List<string>>> GetAllRoles();
    }
}
