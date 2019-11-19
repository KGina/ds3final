using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   public class YearLearnerClassRoom
    {
        public int yearId { get; set; }
        public virtual Year year { get; set; }

        public int learnerId { get; set; }
        public virtual LearnerProfile learnerProfiles { get; set; }
        public int classRoomId { get; set; }
        public virtual ClassRoom classRoom { get; set; }

    }
   
}
