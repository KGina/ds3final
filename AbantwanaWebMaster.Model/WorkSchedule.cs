using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Model
{
    public class WorkSchedule
    {
        public int scheduleId { get; set; }
        public DateTime scheduleStartDate { get; set; }
        public DateTime scheduleEndDate { get; set; }

        public string ThemeColor { get; set; }
        public int classRoomId { get; set; }
        public int staffMemberId { get; set; }
        public bool archived { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
        public virtual StaffMember StaffMember { get; set; }
    }
}

