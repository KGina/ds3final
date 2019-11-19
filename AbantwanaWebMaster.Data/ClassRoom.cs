using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   public class ClassRoom
    {
        public int classRoomId { get; set; }
        public string roomNumber { get; set; }
        public string className { get; set; }

        public int staffId { get; set; }
        public virtual StaffMember Staff { get; set; }
        public int graddId { get; set; }
        public virtual Grade grade { get; set; }

        public virtual ICollection<YearLearnerGradeSubjectAssessment> yearlearnerclassrooms { get; set; }
        public virtual ICollection<WorkSchedule> workschedules { get; set; }

    
      }
}
