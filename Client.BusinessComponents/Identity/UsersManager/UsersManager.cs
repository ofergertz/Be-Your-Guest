using BeMyGuest.Shared.Model.DAL.Conectivity.Identity;
using BeMyGuest.Shared.Model.Infrastructure.Mappers;
using BeMyGuest.Shared.Model.Requests.Identity;
using BeMyGuest.Shared.Model.Responses.Identity;
using DAL.Conectivity.Context;
using Microsoft.EntityFrameworkCore;
using Model.BusinessComponents.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.BusinessComponents.Identity.UsersManager
{
    public class UsersManager : IUsersManager
    {
        private readonly AppDbContext _context;
        private readonly IServiceProvider _serviceProvider;

        public UsersManager(AppDbContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        public bool CheckPassword(IUser user, string password)
        {
            //immplement salt of password and check if the same as in DB
            return true;
        }

        public async Task<IRegisterResponse> CreateUserAsync(IRegisterRequest registerRequest)
        {
            var mapper = (IMapper<IRegisterRequest, IUser>)_serviceProvider.GetService(typeof(IMapper<IRegisterRequest, IUser>));
            var user = mapper.Map(registerRequest);
            await _context.Users.AddAsync(user as User);
            _context.SaveChanges();
            return CreateResponse(user);
        }

        private IRegisterResponse CreateResponse(IUser user)
        {
            var serviceResponse = (IRegisterResponse)_serviceProvider.GetService(typeof(IRegisterResponse));
            serviceResponse.UserName = user.UserName;
            serviceResponse.LastName = user.LastName;
            serviceResponse.FirstName = user.FirstName;
            return serviceResponse;
        }

        public async Task<IUser> FindByEmailAsync(string email)
        {
            var user = await _context.Users.Where(o => o.Email.Equals(email))
                .Include(o => o.UserCredential)
                .ToListAsync();
            if (user == null || !user.Any())
                return null;

            return user.FirstOrDefault();
        }

        public async Task UpdateUserAsync(IUser user)
        {
            _context.Users.Update(user as User);
            _context.SaveChanges();
        }
    }
}
