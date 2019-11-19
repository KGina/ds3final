using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace AbantwanaWebMaster.Model
{
    public class LeaveType
    {
       // [Key]
        public int leaveTypeID { get; set; }

        [DisplayName("Leave Type")]
        public string typeName { get; set; }
        public bool archived { get; set; }
    }
}
