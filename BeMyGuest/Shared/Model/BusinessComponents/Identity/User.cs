using BeMyGuest.Shared.Model.BusinessComponents.Identity;
using BeMyGuest.Shared.Model.BusinessComponents.ProfessionalClassification;
using BeMyGuest.Shared.Model.BusinessComponents.Roles;
using BeMyGuest.Shared.Model.Requests.Identity;
using Microsoft.AspNetCore.Identity;

namespace Model.BusinessComponents.Identity
{
    public class User : IUser
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public string FirstName { get; set;}
        public string LastName { get; set;}
        public string Email { get; set;}
        public string Address { get; set;}
        public string PhoneNumber { get; set; }
        public UserCredential UserCredential { get; set; }
        public List<ProfessionalClassification> UserProfessionalClassifications { get; set; }
        public List<AppRole> AppRole { get; set; }
        public string? ProfilePictureDataUrl { get; set;} = String.Empty;
        public DateTime? CreatedOn { get; set;}
        public DateTime? LastModifiedOn { get; set;}
        public bool IsDeleted { get; set;}
        public DateTime? DeletedOn { get; set;}
        public bool IsActive { get; set;}
        public string RefreshToken { get; set;} = String.Empty;
        public DateTime? RefreshTokenExpiryTime { get; set; } = DateTime.Now;
    }
}
