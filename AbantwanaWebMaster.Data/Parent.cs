using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   public class Parent
    {
        public int parentId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime dob { get; set; }
        public int phonenumber { get; set; }
        public string physicaladdress { get; set; }
        public string emailaddress { get; set; }
        public int homephonenumber { get; set; }
        public byte[] IdDocument { get; set; }
        public byte[] proofofresidence { get; set; }

      
        public bool archived { get; set; }
        public virtual ICollection<ParentLearner> LearnerProfiles { get; set; }
    }
}
