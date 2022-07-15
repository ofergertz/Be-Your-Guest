using BeMyGuest.Shared.Model.Infrastructure.Security;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Security
{
    public class JwtGenerator : IJwtGenerator
    {
        public async Task<string> GenerateJwtAsync()
        {
            var token = GenerateEncryptedToken(GetSigningCredentials());
            return await Task.FromResult(token);
        }

        private string GenerateEncryptedToken(SigningCredentials signingCredentials)
        {
            var token = new JwtSecurityToken(
               claims: null,
               expires: DateTime.UtcNow.AddDays(2),
               signingCredentials: signingCredentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var encryptedToken = tokenHandler.WriteToken(token);
            return encryptedToken;
        }

        private SigningCredentials GetSigningCredentials()
        {
            //"S0M3RAN0MS3CR3T!1!MAG1C!1!" should be in configuration
            var secret = Encoding.UTF8.GetBytes("S0M3RAN0MS3CR3T!1!MAG1C!1!");
            return new SigningCredentials(new SymmetricSecurityKey(secret), SecurityAlgorithms.HmacSha256);
        }
    }
}
