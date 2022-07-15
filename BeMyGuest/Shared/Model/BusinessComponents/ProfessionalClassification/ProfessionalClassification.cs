using Model.BusinessComponents.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeMyGuest.Shared.Model.BusinessComponents.ProfessionalClassification
{
    public class ProfessionalClassification
    {
        public int ProfessionalClassificationId { get; set; }
        public string ProfessionalClassificationName { get; set; }
        public List<User> Users { get; set; }

    }
}
