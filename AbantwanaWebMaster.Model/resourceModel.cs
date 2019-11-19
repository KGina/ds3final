using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbantwanaWebMaster.Model
{
    public class resourceModel
    {
        //classroom details
        public int id { get; set; }
        public int resourceId { get; set; }
        public string title { get; set; }
        public string groupId { get; set; }
        public int roomNumber { get; set; }
        public string GradeName { get; set; }
        public string Description { get; set; }
        //Staff details
        // public string title { get; set; }
        public string StaffMemberName { get; set; }
        public string StaffMemberSurname { get; set; }
        public int phonenumber { get; set; }
        public string email { get; set; }
        public DateTime dateOfBirth { get; set; }

        //schedule Model
        public int staffMemberId { get; set; }
        public int classRoomId { get; set; }
        public int scheduleId { get; set; }
        public DateTime scheduleStartDate { get; set; }
        public DateTime? scheduleEndDate { get; set; }
        public string ThemeColor { get; set; }
    }
}