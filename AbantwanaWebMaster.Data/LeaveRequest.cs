using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   public class LeaveRequest
    {
        public int requestid { get; set; }
        public DateTime startdate { get; set; }
        public DateTime enddate { get; set; }
        public string reason { get; set; }
       // public bool approvalstatus { get; set; }
       // [DisplayName("Created Date")]

        public DateTime createDate { get; set; }
        public bool archived { get; set; }
        //[DisplayName("Status")]
        public string status { get; set; }
        public int leaveTypeID { get; set; }
        public virtual LeaveType leavetype { get; set; }
        public int staffmemberId { get; set; }

        public virtual StaffMember StaffMember { get; set; }
    }
}
