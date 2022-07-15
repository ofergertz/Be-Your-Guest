using BeMyGuest.Shared.Model.BusinessServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Services
{
    public interface IGetRolesService : IService
    {
        Task<IServiceWrapper<List<string>>> GetRoles();
    }
}
