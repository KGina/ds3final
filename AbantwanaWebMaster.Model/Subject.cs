using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace AbantwanaWebMaster.Model
{
    public class Subject
    {
        public int subjectId { get; set; }
        [DisplayName("Subject")]
        public string subjectName { get; set; }
        public virtual ICollection<GradeSubject> gradeSubjects { get; set; }
        public virtual ICollection<Assessment> assessments { get; set; }
        public virtual ICollection<YearLearnerGradeSubjectAssessment> yearLearnerGradeSubjectAssessments { get; set; }
        public virtual ICollection<YearLearnerGradeSubject> yearLearnerGradeSubjects { get; set; }

    }
}
