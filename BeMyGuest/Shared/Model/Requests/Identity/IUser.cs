using BeMyGuest.Shared.Model.BusinessComponents.Identity;
using BeMyGuest.Shared.Model.BusinessComponents.ProfessionalClassification;
using BeMyGuest.Shared.Model.BusinessComponents.Roles;
using Model.BusinessComponents.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeMyGuest.Shared.Model.Requests.Identity
{
    public interface IUser 
    {
        Guid UserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string UserName { get; set; }
        string PhoneNumber { get; set; }
        string? ProfilePictureDataUrl { get; set; }
        DateTime? CreatedOn { get; set; }
        DateTime? LastModifiedOn { get; set; }
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }
        bool IsActive { get; set; }
        string RefreshToken { get; set; } 
        DateTime? RefreshTokenExpiryTime { get; set; }
        UserCredential UserCredential { get; set; }
        List<ProfessionalClassification> UserProfessionalClassifications { get; set; }
        List<AppRole> AppRole { get; set; }
    }
}
