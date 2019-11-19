using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   public class ParentAnnouncement
    {
        public int ParentAnnouncementId { get; set; }
        public int ReceiverId { get; set; }
        public bool Status { get; set; }
    }
}
