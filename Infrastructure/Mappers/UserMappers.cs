using BeMyGuest.Shared.Model.BusinessComponents.Identity;
using BeMyGuest.Shared.Model.BusinessComponents.ProfessionalClassification;
using BeMyGuest.Shared.Model.BusinessComponents.Roles;
using BeMyGuest.Shared.Model.Infrastructure.Mappers;
using BeMyGuest.Shared.Model.Requests.Identity;
using BeMyGuest.Shared.Model.Responses.Identity;
using Model.BusinessComponents.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public class UserMappers : IMapper<IRegisterRequest, IUser>
    {
        private readonly IServiceProvider _serviceProvider;

        public UserMappers(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IUser Map(IRegisterRequest registerRequest)
        {
            var user = (IUser)_serviceProvider.GetService(typeof(IUser));
            user.Address = registerRequest.Address;
            user.CreatedOn = DateTime.Now;
            user.Email = registerRequest.Email;
            user.FirstName = registerRequest.FirstName;
            user.LastName = registerRequest.LastName;
            user.UserId = Guid.NewGuid();
            user.IsActive = true;
            user.PhoneNumber = registerRequest.PhoneNumber;
            user.ProfilePictureDataUrl = registerRequest.ProfilePicture;
            user.UserName = registerRequest.UserName;
            user.UserCredential = new UserCredential()
            {
                CreatedOn = DateTime.Now,
                LastModifiedOn = DateTime.Now,
                Password = registerRequest.Password,
                UserCredentialId = Guid.NewGuid(),
                UserName = registerRequest.UserName
            };
            user.AppRole = registerRequest.Proffesion == null || !registerRequest.Proffesion.Any() ?
                                        new List<AppRole>() { new AppRole() { RoleName = "RegularUser", Users = new List<User>() { user as User } } } :
                                        new List<AppRole>() { new AppRole() { RoleName = "ProUser", Users = new List<User>() { user as User } } };

            user.UserProfessionalClassifications = registerRequest.Proffesion == null || !registerRequest.Proffesion.Any() ?
                                new List<ProfessionalClassification>() { new ProfessionalClassification() } :
                                UpdateUserClassification(registerRequest, user);
            //            user.UserProfessionalClassifications = registerRequest.Proffesion == null || !registerRequest.Proffesion.Any() ?
            //                            CreateRegularUser(user) :
            //                            CreateProUser(registerRequest, user);

            //            user.AppUserRoles = registerRequest.Proffesion == null || !registerRequest.Proffesion.Any() ?
            //                            new List<AppUserRoles>() { new AppUserRoles() { AppRole = new AppRole() { RoleName = "RegularUser" }, User = user as User } } :
            //                            new List<AppUserRoles>() { new AppUserRoles() { AppRole = new AppRole() { RoleName = "ProUser" }, User = user as User } };
            //;
            user.LastModifiedOn = DateTime.Now;
            return user;
        }

        private static List<ProfessionalClassification> UpdateUserClassification(IRegisterRequest registerRequest, IUser user)
        {
            List <ProfessionalClassification> professionalClassificationList = new List < ProfessionalClassification >();
            foreach (var profession in registerRequest.Proffesion)
            {
                professionalClassificationList.Add(new ProfessionalClassification() { ProfessionalClassificationName = profession, Users = new List<User>() { user as User } });

            }

            return professionalClassificationList;
        }

        private static List<UserProfessionalClassification> CreateProUser(IRegisterRequest registerRequest, IUser user)
        {
            List<UserProfessionalClassification> professionalClassificationList = new List<UserProfessionalClassification>();

            foreach (var profession in registerRequest.Proffesion)
            {
                professionalClassificationList.Add(new UserProfessionalClassification()
                {
                    CreatedOn = DateTime.Now,
                    LastModifiedOn = DateTime.Now,  
                    //ProfessionalClassification = new ProfessionalClassification()
                    //{
                    //    ProfessionalClassificationName = profession
                    //},
                    UserProfessionalClassificationId = Guid.NewGuid(),
                    //User = user as User,
                });
            };

            return professionalClassificationList;
        }

        private static List<UserProfessionalClassification> CreateRegularUser(IUser user)
        {
            return new List<UserProfessionalClassification>()
                            {
                                new UserProfessionalClassification()
                                {
                                    CreatedOn = DateTime.Now,
                                    LastModifiedOn= DateTime.Now,
                                    //ProfessionalClassification = new ProfessionalClassification()
                                    //{
                                    //    ProfessionalClassificationName = "RegularUser"
                                    //},
                                    UserProfessionalClassificationId = Guid.NewGuid(),
                                    //User = user as User
                                }

                            };
        }
    }
}
