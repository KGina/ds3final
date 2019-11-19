using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   public class LearnerProfile
    {
        public int learnerId { get; set; }
        public byte[] Picture { get; set; }
        public string lname { get; set; }
        public string lsurname { get; set; }
        public string lidnumber { get; set; }
        public DateTime dateofbith { get; set; }
        public string grade { get; set; }
        public string medicaldetails { get; set; }
        public byte[] medicalCertificate{ get; set; }
        public byte[] BirthCertificate { get; set; }
        public string status { get; set; }
        public bool archive { get; set; }

        public virtual ICollection<ParentLearner>parentLearners { get; set; }
        public virtual ICollection<YearLearnerClassRoom>yearLearnerClassRooms { get; set; }
        public virtual ICollection<Attendance>Attendances { get; set; }

        public virtual ICollection<YearLearnerGradeSubjectAssessment> yearLearnerGradeSubjectAssessments { get; set; }
        public virtual ICollection<YearLearnerGradeSubject> yearLearnerGradeSubjects { get; set; }

    }

}

