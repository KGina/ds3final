using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace AbantwanaWebMaster.Model
{
   public class Announcement
    {
        public int announcementid { get; set; }
        [DisplayName("Title")]
        public string title { get; set; }
        public DateTime datecreated { get; set; }
        public string datecreateddisplay { get; set; }
        public string expiredisplay { get; set; }
        [DisplayName("Message")]
        public string message { get; set; }
        [DisplayName("Expire Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime expirydate { get; set; }
        [DisplayName("Reciever")]
        public string reciever { get; set; }
        public int learnerId { get; set; }
        public int classroomId { get; set; }
        [DisplayName("Sender")]
        public string sender { get; set; }
        //public virtual StaffMember StaffMember { get; set; }
       

    }
}
