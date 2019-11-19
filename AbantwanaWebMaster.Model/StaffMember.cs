using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
  public  class StaffMember
    {
        public int staffMemberId { get; set; }
        [Display(Name = "Name")]
        public string StaffMemberName { get; set; }
        [Display(Name = "Surname")]

        public string StaffMemberSurname { get; set; }
        //[]
        [Display(Name = "Cell Phone Number")]
        public int phonenumber { get; set; }
        [Display(Name = "Email")]
        [EmailAddress]
        public string email { get; set;}
        [Display(Name = "Gender")]
        public string gender { get; set; }
        [Display(Name = "Profile Picture")]
        public byte[] UserPhoto { get; set; }
        //public DateTime dateofbirth { get; set; }
    }
}
