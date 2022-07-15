using BeMyGuest.Shared.Model.BusinessComponents.ProfessionalClassification;
using Model.BusinessComponents.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.Requests.Identity
{
    public interface IUserProfessionalClassification
    {
        Guid UserProfessionalClassificationId { get; set; }
        User User { get; set; }
        ProfessionalClassification ProfessionalClassification { get; set; }
        DateTime CreatedOn { get; set; }
        DateTime? LastModifiedOn { get; set; }
    }
}
