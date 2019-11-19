using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;
namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class ClassroomController : Controller
    {
       
        ClassroomBusiness ClassB = new ClassroomBusiness();
        LearnerProfileBusiness Lp = new LearnerProfileBusiness();
        staffRegBusiness sf = new staffRegBusiness();
        GradeBussiness gb = new GradeBussiness();
        YearBussiness yb = new YearBussiness();
        public ActionResult Index()
        {
            return View(ClassB.GetClassrooms());
        } 
        
        public ActionResult Create()
        {
            
            ViewBag.staffId = new SelectList(sf.GetStaffMembers(), "staffMemberId", "StaffMemberName");
            ViewBag.graddId = new SelectList(gb.getGrade(), "gradeId", "gradeName");
            return View();
        }
        public ActionResult LearnerAllocation(int id,string l)
        {
            if (l==null)
            {
                ViewBag.classRoomId = new SelectList(ClassB.GetClassroomsByLearnerID(id), "classroomid", "className");
            }
            else
            {
                ViewBag.classRoomId = new SelectList(ClassB.GetClassrooms(), "classroomid", "className");
            }
            
            ViewBag.yearId = new SelectList(yb.getYear(), "yearId", "year");
            YearLearnerClassRoom ylc = new YearLearnerClassRoom();
            ylc.learnerId = id;
            return View(ylc);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult LearnerAllocation(YearLearnerClassRoom x)
        {
            

            ViewBag.classRoomId = new SelectList(ClassB.GetClassroomsByLearnerID(x.learnerId), "classroomid", "className");
            ViewBag.yearId = new SelectList(yb.getYear(), "yearId", "year");

            if (ModelState.IsValid)
            {
                if (ClassB.GetClassrooms().Where(p => p.graddId ==ClassB.GetGradeId(x.yearId,x.learnerId)).Count()!=0)
                {
                    ModelState.AddModelError("", "Learner has been Allocated before !!");

                }
                else
                {

                    ClassB.addYearLearnerClassroom(x);
                    Fees y = new Fees();
                    y.classRoomId = x.classRoomId;
                    y.learnerId = x.learnerId;
                    ClassB.addFees(y);
                    return RedirectToAction("AppSuccess","LearnerProfile");
                }
                return View(x);

            }

            return View(x);
        }

        public JsonResult GetLearners()
        {

            return new JsonResult { Data = Lp.GetAllLearners(0), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult Create(ClassRoom x)
        {
            ViewBag.staffId = new SelectList(sf.GetStaffMembers(), "staffMemberId", "StaffMemberName");
            ViewBag.graddId = new SelectList(gb.getGrade(), "gradeId", "gradeName");
    

            if (ModelState.IsValid)
            {
               if( ClassB.GetClassrooms().Where(p=>p.className.ToLower()==x.className.ToLower()).Count()!=0)
                {
                    ModelState.AddModelError("", "Class Name Already Exist");

                }
                else if( ClassB.GetClassrooms().Where(p=> p.roomnumber.ToLower() == x.roomnumber.ToLower()).Count()!=0)
                {
                    ModelState.AddModelError("", "Room Has been allocated before");

                }
                else if( ClassB.GetClassrooms().Where(p=> p.staffId == x.staffId).Count()!=0)
                {
                    ModelState.AddModelError("", "Teacher Already allocated To Another Class");

                }
                else
                {
                    ClassB.addClarroom(x);
                    return RedirectToAction("Index");
                }
                return View(x);
                
            }

            return View(x);
        }
    }
}