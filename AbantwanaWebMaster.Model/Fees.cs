using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AbantwanaWebMaster.Model
{
   public class Fees
    {
        public int FeeId { get; set; }
        //public virtual Year year { get; set; }

        public int learnerId { get; set; }
        //public virtual LearnerProfile learnerProfiles { get; set; }
        [DisplayName("Class Name")]
        public int classRoomId { get; set; }
        [DisplayName("Grade")]

        public string grade { get; set; }
        [DisplayName("Date Created")]
        public string dateCreated { get; set; }
       // public virtual ClassRoom classRoom { get; set; }

        public DateTime datetimeCreated { get; set; }
        [DisplayName("Total Cost")]
        public double feeAmount { get; set; }
        [DisplayName("School Fee")]
        public double schoolFee { get; set; }
        [DisplayName("Stationary Fee")]
        public double stationaryfee { get; set; }

    }
   
}
