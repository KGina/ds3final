using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Model
{
    public class Attendance
    {
        public int attendId { get; set; }
        public DateTime dateCreated { get; set; }
        public int learnerId { get; set; }
        public virtual LearnerProfileView LearnerProfile { get; set; }
        public bool present { get; set; }
        //public virtual ClassRoom ClassRoom { get; set; }
    }
}
