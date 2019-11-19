using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
    public class announce
    {
        [Key]
        public int EmailId { get; set; }
        [DataType(DataType.EmailAddress), Display(Name = "To")]
        [Required]
       public string ToEmail { get; set; }
      
        [Display(Name = "Body")]
        [DataType(DataType.MultilineText)]
        public string EMailBody { get; set; }
        [Display(Name = "Subject")]
        public string EmailSubject { get; set; }
        
    }
}