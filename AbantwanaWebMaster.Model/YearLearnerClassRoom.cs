using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace AbantwanaWebMaster.Model
{
   public class YearLearnerClassRoom
    {
        [Display(Name = "Year")]
        public int yearId { get; set; }
        public virtual Year year { get; set; }

        public int learnerId { get; set; }
        // public virtual LearnerProfile learnerProfiles { get; set; }
        [Display(Name = "Class Name")]
        public int classRoomId { get; set; }
        public virtual ClassRoom classRoom { get; set; }

    }
   
}
