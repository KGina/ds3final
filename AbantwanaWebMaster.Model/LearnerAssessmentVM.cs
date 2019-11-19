using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
    public class LearnerAssessmentVM
    {
       // public int LearnerAssignmentID { get; set; }
        [DisplayName("Assessment Mark")]
        public int AssessmentMark { get; set; }
        [DisplayName("Assessment Name")]
        public int assessmentId { get; set; }
        public virtual Assessment Assessment { get; set; }
        public List<string> AssessmentNameList { get; set; }
        //public List<string> Assessmentterm { get; set; }
        [DisplayName("Assessment Name")]
        public int learnerId { get; set; }
        public virtual LearnerProfileView LearnerProfile { get; set; }
        public List<int> LearnermarkrList { get; set; }
        // public int AssessmentMark { get; set; }
        [DisplayName("Date Captured")]
        public DateTime dateCreated { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Surname")]
        public string Surname { get; set; }
        [DisplayName("Result")]
        public string decision { get; set; }

    }
}
