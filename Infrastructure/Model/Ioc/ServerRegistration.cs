using BeMyGuest.Shared.Model.BusinessComponents.Identity;
using BeMyGuest.Shared.Model.BusinessServices;
using BeMyGuest.Shared.Model.DAL.Conectivity.Identity;
using BeMyGuest.Shared.Model.DAL.Conectivity.Roles;
using BeMyGuest.Shared.Model.Infrastructure.Mappers;
using BeMyGuest.Shared.Model.Infrastructure.Security;
using BeMyGuest.Shared.Model.Requests.Identity;
using BeMyGuest.Shared.Model.Responses.Identity;
using Client.BusinessComponents.Identity.UsersManager;
using Client.BusinessComponents.Requests.Identity;
using Client.BusinessComponents.Responses;
using Client.BusinessComponents.Roles;
using Infrastructure.BusinessServices;
using Infrastructure.Mappers;
using Infrastructure.Model.Services;
using Infrastructure.Security;
using Microsoft.Extensions.DependencyInjection;
using Model.BusinessComponents.Identity;
using Model.BusinessServices;

namespace Infrastructure.Model.Ioc
{
    public static class ServerRegistration
    {
        public static void RegisterServerComponents(this IServiceCollection builder)
        {
            builder.AddTransient<IServiceWrapper, ServiceWrapper>();
            builder.AddTransient<IIdentityService, IdentityService>();
            builder.AddTransient<IUser, User>();
            builder.AddTransient<IUsersManager, UsersManager>();
            builder.AddTransient<IGetRolesService, GetRolesService>();
            builder.AddTransient<ILoginResponse, LoginResponse>();
            builder.AddTransient<IJwtGenerator, JwtGenerator>();
            builder.AddTransient<ITokenGenerator, TokenGenerator>();
            builder.AddTransient<IRegisterResponse, RegisterResponse>();
            builder.AddTransient<IMapper<IRegisterRequest, IUser>, UserMappers>();
        }
    }
}
