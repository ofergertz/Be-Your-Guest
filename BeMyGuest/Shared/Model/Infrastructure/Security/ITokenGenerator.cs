using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.Infrastructure.Security
{
    public interface ITokenGenerator
    {
        Task<string> GenerateRefreshToken();
    }
}
