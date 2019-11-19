using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Model
{
   public class Parent
    {
        public int parentid { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime dob { get; set; }
        public int phonenumber { get; set; }
        public string physicaladdress { get; set; }
        public string emailaddress { get; set; }
        public int homephonenumber { get; set; }
    }
}
