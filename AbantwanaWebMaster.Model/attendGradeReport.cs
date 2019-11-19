using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
    //  public string comment { get; set; }
    public class attendGradeReport
    {
        public string grade { get; set; }

        public List<attendanceReport> attendanceReports { get; set; }

    }
    public class attendanceReport
    {
        public string learnerName { get; set; }
        public int daysAbseent { get; set; }
        public int daysPresent { get; set; }

        //public List<Term> terms { get; set; }

    }
}