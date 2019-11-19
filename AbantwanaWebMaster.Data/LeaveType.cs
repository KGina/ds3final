using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
    public class LeaveType
    {
       // [Key]
        public int leaveTypeID { get; set; }

       // [DisplayName("Leave Type")]
        public string typeName { get; set; }
        public bool archived { get; set; }
    }
}
