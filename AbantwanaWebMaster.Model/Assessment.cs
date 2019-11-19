using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
    public class Assessment
    {
        //[Key]
        public int assessmentId { get; set; }
        [DisplayName("Assessment Name")]
        [Required]
        public string assessmentName { get; set; }
        [DisplayName("Weightings")]
        [Range(0, 100)]
        public int weightings { get; set; }
        [DisplayName("Total Mark")]
        [Range(0,300)]
        public int totMark { get; set; }
        
        public int termId { get; set; }
        public virtual Term term { get; set; }
        public int subjectId { get; set; }
        public virtual Subject subject { get; set; }
        public int gradeId { get; set; }
        public virtual Grade grade { get; set; }
        public List<ClassRoom> myClass { get; set; }
        public int yearId { get; set; }
        public virtual Year year { get; set; }
        public virtual ICollection<YearLearnerGradeSubjectAssessment> yearLearnerGradeSubjectAssessments { get; set; }
    }
}
