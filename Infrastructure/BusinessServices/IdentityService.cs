using BeMyGuest.Shared.Model.BusinessServices;
using BeMyGuest.Shared.Model.DAL.Conectivity.Identity;
using BeMyGuest.Shared.Model.Infrastructure.Security;
using BeMyGuest.Shared.Model.Requests.Identity;
using BeMyGuest.Shared.Model.Responses.Identity;
using Client.BusinessComponents.Identity;
using Infrastructure.Model.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using Model.BusinessComponents.Identity;
using Model.BusinessServices;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.BusinessServices
{
    public class IdentityService : IIdentityService
    {
        private readonly IUsersManager _userManager;
        private readonly IStringLocalizer<IdentityService> _localizer;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly ITokenGenerator _tokenGenerator;
        private readonly IServiceProvider _serviceProvider;


        public IdentityService(IStringLocalizer<IdentityService> localizer,
            IServiceProvider serviceProvider, IUsersManager userManager, IJwtGenerator jwtGenerator, 
            ITokenGenerator tokenGenerator)
        {
            _localizer = localizer;
            _serviceProvider = serviceProvider;
            _userManager = userManager;
            _jwtGenerator = jwtGenerator;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<IServiceWrapper<ILoginResponse>> LoginAsync(ILoginRequest loginRequest)
        {
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
            {
                return await ServiceWrapper<ILoginResponse>.FailAsync(_localizer["User Not Found."]);
            }
            if (!user.IsActive)
            {
                return await ServiceWrapper<ILoginResponse>.FailAsync(_localizer["User Not Active. Please contact the administrator."]);
            }
            var passwordValid =  _userManager.CheckPassword(user, loginRequest.Password);
            if (!passwordValid)
            {
                return await ServiceWrapper<ILoginResponse>.FailAsync(_localizer["Invalid Credentials."]);
            }

            user.RefreshToken = await _tokenGenerator.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
            await _userManager.UpdateUserAsync(user);
            var token = await _jwtGenerator.GenerateJwtAsync();

            var response = CreateResponse(user, token);
            return await ServiceWrapper<ILoginResponse>.SuccessAsync(response);
        }

        public async Task<IServiceWrapper<IRegisterResponse>> RegisterAsync(IRegisterRequest registerModel)
        {
            var response = await _userManager.CreateUserAsync(registerModel);
            return await ServiceWrapper<IRegisterResponse>.SuccessAsync(response);
        }

        private ILoginResponse CreateResponse(IUser user, string token)
        {
            var response = (ILoginResponse)_serviceProvider.GetService(typeof(ILoginResponse));
            response.Token = token;
            response.RefreshToken = user.RefreshToken;
            response.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime.Value;
            response.UserImageURL = user.ProfilePictureDataUrl;

            return response;
        }      
    }
}
