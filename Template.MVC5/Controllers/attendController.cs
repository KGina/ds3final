using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class attendController : Controller
    {
        AssessmentBussiness asb = new AssessmentBussiness();
        ClassroomBusiness cb = new ClassroomBusiness();
        attendbussiness atb = new attendbussiness(); 
        // GET: attend
        public ActionResult Index(int classId)
        {
            return View(atb.getattendanceGradeReport(classId));
        }
        public ActionResult selectClassroom()
        {
            //LearnerProfileBusiness LP = new LearnerProfileBusiness();

           // ViewBag.learnerId = new SelectList(LP.GetAllLearners(0), "learnerId", "lname");
            return View(cb.GetClassrooms());
        }
        public ActionResult CreateAttendance(int classroomId)
        {
            //ViewBag.assessmentId = new SelectList(asb.GetAssessmentsBySubject(id), "assessmentId", "assessmentName");

            return View(asb.GetAllLearnersByGrade(classroomId));
        }
        [HttpPost]
        public ActionResult CreateAttendance(LearnerAssessment or, List<LearnerAssessment> vMs)
        {
            //ViewBag.assessmentId = new SelectList(asb.GetAssessmentsBySubject(id), "assessmentId", "assessmentName");
            foreach (var ih in vMs)
            {
                Attendance jk = new Attendance();
                jk.dateCreated = or.dateCreated;
                jk.learnerId = ih.learnerId;
                jk.present = ih.present;
                or.classID = ih.classID;
               // ih.dateCreated = or.dateCreated;
                atb.creatAttendence(jk);
            }
            return RedirectToAction("selectClassroom");
        }
    }
}