using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;
using PagedList;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class SubjectController : Controller
    {
        SubjectBusiness SB= new SubjectBusiness();
        GradeBussiness gb = new GradeBussiness();
        LearnerProfileBusiness lpb = new LearnerProfileBusiness();
        YearBussiness yb = new YearBussiness();
        termBussiness tb = new termBussiness();
        public ActionResult Index(string Sorting_Order)
        {
            var l = SB.GetSubjects();
            // List<Subject> k = new List<Subject>();
            switch (Sorting_Order)
            {
                default:
                    l = l.OrderBy(k => k.subjectName).ToList();
                    break;
            }
            int intPage = 1;
            int intPageSize = 5;
            int intTotalPageCount = 0;
            //LeaveRequest nm = new LeaveRequest();
            // nm.LeaveRequests = leaveReq.getLeaveReqs();

            var _UserDTOAsIPagedList =
                    new StaticPagedList<Subject>
                    (
                        l, intPage, intPageSize, intTotalPageCount
                        );

            return View(_UserDTOAsIPagedList);
            //return View(SB.GetSubjects());
        }
        public ActionResult GradeSubjectIndex(int gradeId)
        {
            ViewBag.GradeName = lpb.Getgradename(gradeId);
            var l = SB.GetGradeSubjects(gradeId);
            // List<Subject> k = new List<Subject>();
            l = l.OrderBy(k => k.subjectName).ToList();
            
            int intPage = 1;
            int intPageSize = 5;
            int intTotalPageCount = 0;
            //LeaveRequest nm = new LeaveRequest();
            // nm.LeaveRequests = leaveReq.getLeaveReqs();

            var _UserDTOAsIPagedList =
                    new StaticPagedList<GradeSubject>
                    (
                        l, intPage, intPageSize, intTotalPageCount
                        );

            return View(_UserDTOAsIPagedList);
            //return View(SB.GetSubjects());
        }

        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult YearIndex(int subjectId, int gradeId)
        {
            ViewBag.subjectId = subjectId;
            ViewBag.gradeId =gradeId;
            return View(yb.getYear());
        }
        public ActionResult TermIndex(int subjectId, int gradeId,int yearId)
        {
            ViewBag.subjectId = subjectId;
            ViewBag.gradeId =gradeId;
            ViewBag.yearId = yearId;
            return View(tb.getTerm());
        }
        public ActionResult AssesementIndex(int subjectId, int gradeId,int yearId,int termId)
        {
            ViewBag.subjectId = subjectId;
            ViewBag.gradeId =gradeId;
            ViewBag.yearId = yearId;
            ViewBag.termId = termId;
            return View(yb.getYear());
        }
        public ActionResult GradeSubjectUpdate(int subjectId,int gradeId)
        {
            GradeSubject x = new GradeSubject();
            x = SB.GetGradeSubjects(gradeId).Where(d => d.subjectId == subjectId).FirstOrDefault();
            return View(x);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GradeSubjectUpdate(GradeSubject x)
        {
            if (ModelState.IsValid)
            {
                SB.updateGradeSubject(x);
                return RedirectToAction("GradeSubjectIndex", "Subject", new { gradeId = x.gradeId });
            }
            return View(x);
        }
        public ActionResult subjectAllocation()
        {
            ViewBag.subjectId = new SelectList(SB.GetSubjects(), "subjectId", "subjectName");
            ViewBag.gradeId = new SelectList(gb.getGrade(), "gradeId", "gradeName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult subjectAllocation(GradeSubject x)
        {
            ViewBag.subjectId = new SelectList(SB.GetSubjects(), "subjectId", "subjectName");
            ViewBag.gradeId = new SelectList(gb.getGrade(), "gradeId", "gradeName");

            if (ModelState.IsValid)
            {
                if (SB.GetGradeSubjects(x.gradeId).Where(p => p.gradeId== x.gradeId&&p.subjectId==x.subjectId).Count() > 0)
                {
                    ModelState.AddModelError("", "Subject Already Linked To Grade Selected");
                    return View(x);
                }
                SB.addGradeSubject(x);
                return RedirectToAction( "GradeSubjectIndex", "Subject", new { gradeId = x.gradeId });
            }

            return View(x);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Subject x)
        {


            if (ModelState.IsValid)
            {if (SB.GetSubjects().Where(p => p.subjectName.ToLower() == x.subjectName.ToLower()).Count() > 0)
                {
                    ModelState.AddModelError("", "Subject Already Exist");
                    return View(x);
                }
                SB.addSubject(x);
                return RedirectToAction("Index");
            }

            return View(x);
        }
    }
}