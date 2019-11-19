using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AbantwanaWebMaster.Model
{
   public class GradeSubject
    {
        [Display(Name = "Grade")]
        public int gradeId { get; set; }
        public virtual Grade grade { get; set; }
        [Display(Name = "Subject")]
        public string subjectName { get; set; }
        
        [Display(Name = "Subject")]
        public int subjectId { get; set; }
        public virtual Subject subject { get; set; }
        public bool active { get; set; }
        [Display(Name = "Requirement")]
        [Range(0,100)]
        public int requirement { get; set; }
        
        public virtual ICollection<Assessment> YearLearnerClassRooms { get; set; }

    }
}
