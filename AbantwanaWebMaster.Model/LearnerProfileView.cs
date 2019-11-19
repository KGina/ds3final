using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
   public class LearnerProfileView
    {
        public int learnerId { get; set; }
        public int termId { get; set; }
        [Display(Name = "Picture")]
        public byte[] Picture { get; set; }
        [Required(ErrorMessage = " Name Can not be empty")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Name should be between 4 and 20")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string lname { get; set; }
        [Required(ErrorMessage = " Surname Can not be empty")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Surname should be between 4 and 20")]
        [DataType(DataType.Text)]
        [Display(Name = "Surname")]
        public string lsurname { get; set; }
        [Required(ErrorMessage = " Id Number Cannot be empty")]
        [Display(Name = " Id Number")]
        //[RSAIDNumber(ErrorMessage = "A valid RSA ID Number is required.")]
        public string lidnumber { get; set; }

        [Required]
        [Display(Name = " Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateofbith { get; set; }
        [Required]
        [Display(Name = "Grade")]
        public string grade { get; set; }
        [Display(Name = "Medical Details")]
        public string medicaldetails { get; set; }
        [Display(Name = "Application Status")]
        public string status { get; set; }
        [Display(Name = "Application Status")]
        public string parentEmail { get; set; }
        public byte[] medicalCertificate { get; set; }
        public byte[] BirthCertificate { get; set; }
        public bool archive { get; set; }
        public List<Term> terms { get; set; }

    }
}
