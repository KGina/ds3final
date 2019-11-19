using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   public class GradeSubject
    {
        public int gradeId { get; set; }
        public virtual Grade grade { get; set; }
        public int subjectId { get; set; }
        public virtual Subject subject { get; set; }
        public bool active { get; set; }
        public int requirement { get; set; }
        
        public virtual ICollection<Assessment> YearLearnerClassRooms { get; set; }

    }
}
