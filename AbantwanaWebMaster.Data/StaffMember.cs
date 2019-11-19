using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
    public class StaffMember
    {
        public int staffMemberId { get; set; }
        public string StaffMemberName { get; set; }
        public string StaffMemberSurname { get; set; }
        public int phonenumber { get; set; }
        public string email { get; set;}
        public byte[] UserPhoto { get; set; }
        public string gender { get; set; }
        // public DateTime dateOfBirth { get; set; }
        public virtual ICollection<WorkSchedule> WorkSchedules { get; set; }
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
