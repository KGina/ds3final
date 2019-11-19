using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.Service;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class attendbussiness
    {
        DataContext db = new DataContext();
        public List<Model.Attendance>  getattendance()
        {

            using (var leaveRepo = new AttendRepository  ())
            {
                return leaveRepo.GetAll().Select(x => new Model.Attendance() {attendId=x.attendId, dateCreated=x.dateCreated,present=x.present,learnerId=x.learnerId }).ToList();
            }
        }
        public List<Model.attendGradeReport>  getattendanceGradeReport(int classId)
        {
            List<attendGradeReport> atgr = new List<attendGradeReport>();
            attendGradeReport gradeReports = new attendGradeReport();
            gradeReports.grade = db.classRooms.Where(l => l.classRoomId == classId).Select(l=>l.className).FirstOrDefault();
            var students = db.yearLearnerClassRooms.Where(c => c.classRoomId == classId).ToList();
            List<attendanceReport> ar = new List<attendanceReport>();
            foreach (var ite in students)
            {
                attendanceReport kl = new attendanceReport();
                kl.learnerName = db.learnerProfiles.Where(l => l.learnerId == ite.learnerId).Select(n => n.lname).FirstOrDefault();
                kl.daysAbseent = db.attendances.Where(lo => lo.learnerId == ite.learnerId && lo.present == false).Count();
                kl.daysPresent = db.attendances.Where(lo => lo.learnerId == ite.learnerId&& lo.present == true).Count();
                ar.Add(kl);
            }
            gradeReports.attendanceReports = ar;
            atgr.Add(gradeReports);
            return atgr;
        }
        
        public void creatAttendence(Model.Attendance attendance)
        {
            
            using (var attRepo = new AttendRepository())
            {
                if (attendance != null)
                {
                    
                    var attCreate = new Data.Attendance() { dateCreated=attendance.dateCreated,learnerId=attendance.learnerId,present=attendance.present};
                    attRepo.Insert(attCreate);
                }
            }
       
        }

        public void updateAttendance(Model.Attendance att)
        {

            using (var attRepo = new AttendRepository())
            {
                if (att != null)
                {

                    var attCreate = new Data.Attendance() { attendId = att.attendId,dateCreated=att.dateCreated,present=att.present };
                    attRepo.Update(attCreate);
                }
            }

        }



    }
}
