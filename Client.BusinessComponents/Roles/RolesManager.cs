using BeMyGuest.Shared.Model.BusinessServices;
using BeMyGuest.Shared.Model.DAL.Conectivity.Roles;
using Client.Model.Extensions;
using DAL.Conectivity.Context;
using Model.Extensions;
using System.Net.Http.Json;

namespace Client.BusinessComponents.Roles
{
    public class RolesManager : IRolesManager
    {
        private readonly HttpClient _httpClient;


        public RolesManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IServiceWrapper<List<string>>> GetAllRoles()
        {
            var response = await _httpClient.GetAsync(Constants.UserRolesApi.GetRoles);
            var result = await response.ToResult<List<string>>();

            return result;
        }
    }
}
