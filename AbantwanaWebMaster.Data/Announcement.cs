using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace AbantwanaWebMaster.Data
{
   public class Announcement
    {
        public int announcementid { get; set; }
        public string title { get; set; }
        public DateTime datecreated { get; set; }
        public string message { get; set; }
        public DateTime expirydate { get; set; }
        public string reciever { get; set; }
        public string sender { get; set; } 
        ///public virtual StaffMember StaffMember { get; set; }
    }
}
