using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
    public class LearnerAssessment
    {
       // public int LearnerAssignmentID { get; set; }
        [DisplayName("Assessment Mark")]
        public int AssessmentMark { get; set; }
        [DisplayName("Assessment Name")]
        public int assessmentId { get; set; }
        public virtual Assessment Assessment { get; set; }
        //[DisplayName("Learner Name")]
        public int yearId { get; set; }
        [DisplayName("Learner Name")]

        public int learnerId { get; set; }
        public virtual LearnerProfileView LearnerProfile { get; set; }
        // public int AssessmentMark { get; set; }
        [DisplayName("Date Captured")]
        public DateTime dateCreated { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Surname")]
        public string Surname { get; set; }
        public bool present { get; set; }
        public int classID { get; set; }
        public int gradeid { get; set; }
        public int subjectId { get; set; }
        public int termId { get; set; }
    }
}
