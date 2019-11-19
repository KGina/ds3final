using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AbantwanaWebMaster.Model
{
   public class Grade
    {
        public int gradeId { get; set; }
       
        [Required]
        [DisplayName("Stationary Fee")]

        public double StationaryFee { get; set; }
        [DisplayName("Grade Fee")]
        [Required]
        public double gradeFee { get; set; }
      
        [Required]
        [DisplayName("Grade")]

        public string gradeName { get; set; }
        public virtual ICollection<ClassRoom> ClassRooms { get; set; }
        public virtual ICollection<GradeSubject> GradeSubjects { get; set; }
        public virtual ICollection<Assessment> assessments { get; set; }
        public virtual ICollection<YearLearnerGradeSubjectAssessment> yearLearnerGradeSubjectAssessments { get; set; }
        public virtual ICollection<YearLearnerGradeSubject> yearLearnerGradeSubjects { get; set; }

    }
}
