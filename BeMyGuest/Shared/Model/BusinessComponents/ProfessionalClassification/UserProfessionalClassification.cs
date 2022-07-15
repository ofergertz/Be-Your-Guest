using BeMyGuest.Shared.Model.Requests.Identity;
using Model.BusinessComponents.Identity;

namespace BeMyGuest.Shared.Model.BusinessComponents.ProfessionalClassification
{
    public class UserProfessionalClassification : IUserProfessionalClassification
    {
        public Guid UserProfessionalClassificationId { get; set; }
        public User User { get; set; }
        public ProfessionalClassification ProfessionalClassification { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }

    }
}
