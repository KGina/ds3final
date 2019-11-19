using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Model
{
   public class Year
    {
        public int yearId { get; set; }
        public int year { get; set; }
        public virtual ICollection<YearLearnerClassRoom> YearLearnerClassRooms { get; set; }
        public virtual ICollection<Assessment> assessments { get; set; }
        public virtual ICollection<YearLearnerGradeSubjectAssessment> yearLearnerGradeSubjectAssessments { get; set; }
        public virtual ICollection<YearLearnerGradeSubject> yearLearnerGradeSubjects { get; set; }
        
    }
}
