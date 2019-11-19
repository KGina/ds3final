using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
   public class ParentView
    {
        public int parentid { get; set; }
        [Required(ErrorMessage = " Name Can not be empty")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 20 letters long")]
        [DataType(DataType.Text)]
        [Display(Name = " Name")]
        public string name { get; set; }
        [Required(ErrorMessage = " Surname Can not be empty")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Surname should be between 3 and 20 letters long")]
        [DataType(DataType.Text)]
        [Display(Name = " Surname")]
        public string surname { get; set; }
        [Required(ErrorMessage = " Date Of Birth can not be empty")]
        [Display(Name = " Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dob { get; set; }
        [Required(ErrorMessage = " Phone Number Can not be empty")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Not a SA number")]
        [Display(Name = " Phone Number")]
      //  [RegularExpression(@"0((60[3-9]|64[0-5]|66[0-5])\d{6}|(7[1-4689]|6[1-3]|8[1-4])\d{7})", ErrorMessage = "Not a SA number")]
        public int phonenumber { get; set; }
        [Required(ErrorMessage = " Physical Address can not be empty")]
        [Display(Name = "Physical Address")]
        public string physicaladdress { get; set; }
        [Required(ErrorMessage = " Email Address can not be empty")]
        [EmailAddress]
        [Display(Name = " Email Address")]
        public string emailaddress { get; set; }
        //[RegularExpression(@"0((60[3-9]|64[0-5]|66[0-5])\d{6}|(7[1-4689]|6[1-3]|8[1-4])\d{7})", ErrorMessage = "Not a SA Phone Number")]
        [Display(Name = " Home Phone Number")]
        public int homephonenumber { get; set; }
        public byte[] IdDocument { get; set; }
        public byte[] proofofresidence { get; set; }
        //public string status { get; set; }
        public bool archived { get; set; }
    }
}
