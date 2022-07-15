using BeMyGuest.Shared.Model.BusinessServices;
using BeMyGuest.Shared.Model.DAL.Conectivity.Roles;
using DAL.Conectivity.Context;
using Infrastructure.Model.Services;
using Microsoft.EntityFrameworkCore;
using Model.BusinessServices;

namespace Infrastructure.BusinessServices
{
    public class GetRolesService : IGetRolesService
    {
        private readonly AppDbContext _context;

        public GetRolesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IServiceWrapper<List<string>>> GetRoles()
        {
            var roles = await _context.ProfessionalClassification.Select(x => x.ProfessionalClassificationName).ToListAsync();
            return await ServiceWrapper<List<string>>.SuccessAsync(roles);
        }
    }
}
