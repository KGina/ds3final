using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Model
{
   public class LearnerProfile
    {
        public int learnerId { get; set; }
        public byte[] Picture { get; set; }
        public string lname { get; set; }
        public string lsurname { get; set; }
        public string lidnumber { get; set; }
        public DateTime dateofbith { get; set; }
        public string grade { get; set; }
        public string medicaldetails { get; set; }
       
    }
}
