using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   public class Grade
    {
        public int gradeId { get; set; }
        public string gradeName { get; set; }
        public double StationaryFee { get; set; }
        public double gradeFee { get; set; }
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
        public virtual ICollection<GradeSubject> GradeSubjects { get; set; }
        public virtual ICollection<Assessment> assessments { get; set; }
        public virtual ICollection<YearLearnerGradeSubjectAssessment> yearLearnerGradeSubjectAssessments { get; set; }
        public virtual ICollection<YearLearnerGradeSubject> yearLearnerGradeSubjects { get; set; }

    }
}
