using BeMyGuest.Shared.Model.DAL.Conectivity.Roles;
using BeMyGuest.Shared.Model.Requests.Identity;
using Client.BusinessComponents.Identity.Authentication;
using Client.BusinessComponents.Requests.Identity;
using Client.BusinessComponents.Roles;
using Client.BusinessComponents.Validators.Requests.Identity;
using Client.Model.Responses.Identity;
using Client.Model.Validators.Requests.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Model.Ioc
{
    public static class ClientRegistration
    {
        public static void RegisterClientComponents(this IServiceCollection builder)
        {
            builder.AddTransient<IAuthenticationManager, AuthenticationManager>();
            builder.AddTransient<IRolesManager, RolesManager>();
            builder.AddTransient<IRegisterRequestValidator, RegisterRequestValidator>();
            builder.AddTransient<IRegisterRequest, RegisterRequest>();
            builder.AddTransient<ILoginRequest, LoginRequest>();
        }
    }
}
