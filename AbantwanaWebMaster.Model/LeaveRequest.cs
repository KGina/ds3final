using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AbantwanaWebMaster.Model
{ 
   public class LeaveRequest
    {
        [Display(Name = "Request Number")]
        public int requestid { get; set; }
        [Display(Name = "Start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime startdate { get; set; }
        [Display(Name = "End date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime enddate { get; set; }
        [Display(Name = "Reason")]
        public string reason { get; set; }
        [Display(Name = "Response")]
        [DisplayName("Created Date")]

        public DateTime createDate { get; set; }
        [DisplayName("Leave Type")]
        public int leaveTypeID { get; set; }
        public virtual LeaveType leavetype { get; set; }
        [DisplayName("Status")]
        public string status { get; set; }
        public string StaffMemberName { get; set; }
        public string createdBy { get; set; }
        public int staffmemberId { get; set; }
        public bool archived { get; set; }
        public virtual StaffMember StaffMember { get; set; }
        public List<LeaveRequest> LeaveRequests = new List<LeaveRequest>();

    }
    
}
