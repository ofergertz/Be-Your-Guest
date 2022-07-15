using BeMyGuest.Shared.Model.Requests.Identity;
using Client.Model.Responses.Identity;
using Client.BusinessComponents.Requests.Identity;
using Model.Extensions;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using BeMyGuest.Shared.Model.BusinessServices;
using Client.Model.Extensions;
using Client.BusinessComponents.Responses;

namespace Client.BusinessComponents.Identity.Authentication
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly HttpClient _httpClient;

        public AuthenticationManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IServiceWrapper> Login(ILoginRequest loginRequest)
        {
            var response = await _httpClient.PostAsJsonAsync(Constants.IdentityAuthenticationApi.Login, loginRequest);
            var result = await response.ToResult<LoginResponse>();

            return result;
        }

        public Task<IServiceWrapper> Logout()
        {
            throw new NotImplementedException();
        }

        public async Task<IServiceWrapper> Register(IRegisterRequest registerRequest)
        {
            var response = await _httpClient.PostAsJsonAsync(Constants.IdentityAuthenticationApi.Register, registerRequest);
            var result = await response.ToResult<RegisterResponse>();

            return result;
        }
    }
}
