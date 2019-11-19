using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Model;
namespace AbantwanaWebMaster.BusinessLogic
{
   public class ClassroomBusiness
    {
        DataContext db = new DataContext();


        public List<Model.ClassRoom> GetClassrooms()
        {
            using (var ClassroomRep = new ClassroomRepository())
            {
                return ClassroomRep.GetAll().Select(x => new Model.ClassRoom() { classRoomId = x.classRoomId, roomnumber = x.roomNumber,
                    graddId = x.graddId,className=x.className,
                    staffId=x.staffId,
                    teachername=GetStaffName(x.staffId)
                }).ToList();
            }
        }

        public int GetgradeId2(int id)
        {
        var gh= db.classRooms.Where(i=>i.classRoomId==id).Select(x => x.graddId).FirstOrDefault();
            return (gh);
        }
        public string GetStaffName(int id)
        {
        var gh= db.staffMembers.Where(i=>i.staffMemberId==id).Select(x => x.StaffMemberName).FirstOrDefault();
            return (gh);
        }
        public int GetGradeId(int yearid, int leanerId)
        {
            var clId = db.yearLearnerClassRooms.Where(l => l.yearId == yearid && l.learnerId == leanerId).Select(k => k.classRoomId).FirstOrDefault();
            using (var ClassroomRep = new ClassroomRepository())
            {
                return ClassroomRep.GetAll().Where(p=>p.classRoomId==clId).Select(x =>   x.graddId).FirstOrDefault();
            }
        }
        public List<Model.YearLearnerClassRoom> GetYearLearnerClassrooms()
        {
            using (var ClassroomRep = new YearLearnerClassRoomRepository())
            {
                return ClassroomRep.GetAll().Select(x => new Model.YearLearnerClassRoom()
                {
                    classRoomId = x.classRoomId,
                    learnerId = x.learnerId,
                    yearId = x.yearId
                }).ToList();
            }
        }
        LearnerProfileBusiness lp = new LearnerProfileBusiness();
        public List<Model.ClassRoom> GetClassroomsByLearnerID(int id)
        { var gnam = db.learnerProfiles.Where(p => p.learnerId == id).Select(k => k.grade).FirstOrDefault();
            using (var ClassroomRep = new ClassroomRepository())
            {
                return ClassroomRep.GetAll().Where(o=>lp.Getgradename(o.graddId).ToLower()==gnam.ToLower()).Select(x => new Model.ClassRoom() { classRoomId = x.classRoomId, roomnumber = x.roomNumber,
                    graddId = x.graddId,className=x.className,
                    staffId=x.staffId
                }).ToList();
            }

         
        }
        public List<Model.ClassRoom> GetClassroomsWithTerms()
        {
            var termL = db.terms.ToList();
            List<Model.Term> terms = new List<Model.Term>();
            foreach (var it in termL)
            {
                Model.Term kl = new Model.Term();
                kl.termId = it.termId;
                kl.name = it.name;
                terms.Add(kl);

            }
            using (var ClassroomRep = new ClassroomRepository())
            {
                return ClassroomRep.GetAll().Select(x => new Model.ClassRoom() {
                    classRoomId = x.classRoomId,
                    roomnumber = x.roomNumber,
                    graddId = x.graddId,
                    gradename=x.grade.gradeName,
                    className = x.className,
                    staffId = x.staffId
                }).ToList();
            }

         
        }

        

        public void addClarroom(Model.ClassRoom x)
        {

            using (var ClassroomRep = new ClassroomRepository())
            {

                var addClass = new Data.ClassRoom {
                    classRoomId = x.classRoomId,
                    roomNumber = x.roomnumber,
                    graddId = x.graddId,
                    className = x.className,
                    staffId = x.staffId
                };
                ClassroomRep.Insert(addClass);
            }
        }
        public void addYearLearnerClassroom(Model.YearLearnerClassRoom x)
        {

            using (var ClassroomRep = new YearLearnerClassRoomRepository())
            {

                var addClass = new Data.YearLearnerClassRoom {
                    classRoomId = x.classRoomId,
                    learnerId=x.learnerId,
                    yearId=x.yearId
                };
                ClassroomRep.Insert(addClass);
            }
        }
        public void addFees(Model.Fees x)
        {
            var grid = db.classRooms.Where(l => l.classRoomId == x.classRoomId).Select(p => p.graddId).FirstOrDefault();
            var fess = db.grades.Where(k => k.gradeId == grid).Select(p => new { p.StationaryFee, p.gradeFee }).FirstOrDefault();
            x.feeAmount =(fess.gradeFee + fess.StationaryFee);
            using (var ClassroomRep = new FeeRepository())
            {

                var addClass = new Data.Fees
                {
                    FeeId = x.FeeId,
                    classRoomId = x.classRoomId,
                    learnerId = x.learnerId,
                    feeAmount = x.feeAmount,
                    datetimeCreated = DateTime.Now
                };
                ClassroomRep.Insert(addClass);
            }
        }


        //public int GetLearner()
        //{
        //    var grd = db.classRooms.Where(v => v.classRoomId == LearnerProfile.classRoomId).Select(m => m.GradeName).FirstOrDefault();

        //    ViewBag.LearnerId = new SelectList(db.learnerProfiles, "LearnerId", "GradeName");
        //    return View();
        //}
    }
}
