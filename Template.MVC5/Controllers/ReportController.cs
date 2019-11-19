using System.Linq;
using System.Web.Mvc;
//using MVC_Print_PDF.Models;
using Rotativa;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;
using System.Net.Mail;
using System.IO;
using PagedList;
using System.Collections.Generic;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class ReportController : Controller
    {
        //AppEntities ctx;
        public ReportController()
        {
           // ctx = new Models.AppEntities(); 
        }
        LearnerProfileBusiness learners = new LearnerProfileBusiness();
        termBussiness business = new termBussiness();
        ClassroomBusiness cla = new ClassroomBusiness();
        GradeBussiness gb = new GradeBussiness();
        YearBussiness yb = new YearBussiness();
        // GET: LeaveTypes

        //public ActionResult Index(string Sorting_Order, string Search_Data)
        //{
        //    //ViewBag.termId = new SelectList(business.getTerm(), "termId", "name");
        //    var l = learners.GetAllLearnerWithTerms().Where(g => g.archive == false);
        //    if(Search_Data!=null)
        //    {
        //        l = l.Where(o => o.lname.ToUpper().Contains(Search_Data.ToUpper()) || o.lsurname.ToUpper().Contains(Search_Data.ToUpper()));
        //    }
        //    switch (Sorting_Order)
        //    {
        //        case "grade":
        //            l = l.OrderBy(k=>k.grade);
        //            break;
        //        case "lsurname":
        //            l = l.OrderBy(k => k.lsurname);
        //            break;
        //        case "lidnumber":
        //            l = l.OrderBy(k => k.lidnumber);
        //            break;
        //        default:
        //            l = l.OrderBy(k => k.lname);
        //            break;
        //    }
        //    int intPage = 1;
        //    int intPageSize = 5;
        //    int intTotalPageCount = 0;
        //    //LeaveRequest nm = new LeaveRequest();
        //    // nm.LeaveRequests = leaveReq.getLeaveReqs();

        //    var _UserDTOAsIPagedList =
        //            new StaticPagedList<LearnerProfileView>
        //            (
        //                l, intPage, intPageSize, intTotalPageCount
        //                );

        //    return View(_UserDTOAsIPagedList);
        //   // return View(l);
        //}
        public ActionResult PrintByGrade(int gradeId,int yearId,int termId,string Sorting_Order, string Search_Data)
        {
            ViewBag.gradeId = gradeId;
            ViewBag.yearId = yearId;
            ViewBag.termId = termId;
            ViewBag.gradeName = gb.getGrade().Where(i => i.gradeId == gradeId).Select(o => o.gradeName).FirstOrDefault();
            ViewBag.year = yb.getYear().Where(i => i.yearId == yearId).Select(o => o.year).FirstOrDefault();
            ViewBag.name = business.getTerm().Where(i => i.termId == termId).Select(o => o.name).FirstOrDefault();
            //ViewBag.termId = new SelectList(business.getTerm(), "termId", "name");
            var l = learners.GetAllLearnerWithTerms(gradeId,yearId).Where(g => g.archive == false);
            if(Search_Data!=null)
            {
                l = l.Where(o => o.lname.ToUpper().Contains(Search_Data.ToUpper()) || o.lsurname.ToUpper().Contains(Search_Data.ToUpper()));
            }
            switch (Sorting_Order)
            {
                case "grade":
                    l = l.OrderBy(k=>k.grade);
                    break;
                case "lsurname":
                    l = l.OrderBy(k => k.lsurname);
                    break;
                case "lidnumber":
                    l = l.OrderBy(k => k.lidnumber);
                    break;
                default:
                    l = l.OrderBy(k => k.lname);
                    break;
            }
            int intPage = 1;
            int intPageSize = 5;
            int intTotalPageCount = 0;
            //LeaveRequest nm = new LeaveRequest();
            // nm.LeaveRequests = leaveReq.getLeaveReqs();

            var _UserDTOAsIPagedList =
                    new StaticPagedList<LearnerProfileView>
                    (
                        l, intPage, intPageSize, intTotalPageCount
                        );

            return View(_UserDTOAsIPagedList);
           // return View(l);
        }
        public ActionResult GradeIndex()
        {
            //ViewBag.termId = new SelectList(business.getTerm(), "termId", "name");
            var l = cla.GetClassroomsWithTerms();
            return View(l);
        }
        public ActionResult GoToReport()
        {
            ViewBag.termId = new SelectList(business.getTerm(), "termId", "name");
            ViewBag.graddId = new SelectList(gb.getGrade(), "gradeId", "gradeName");
            ViewBag.yearId = new SelectList(yb.getYear(), "yearId", "year");
            
            return View();
        }
        [HttpPost]
        public ActionResult GoToReport(GoToReport x)
        {
            ViewBag.termId = new SelectList(business.getTerm(), "termId", "name");
            ViewBag.graddId = new SelectList(gb.getGrade(), "gradeId", "gradeName");
            ViewBag.yearId = new SelectList(yb.getYear(), "yearId", "year");
            if (ModelState.IsValid)
            {   if(x.graddId!=0&&x.termId!=0&&x.yearId!=0)
                {
                    return RedirectToAction("PrintByGrade", new { gradeId = x.graddId, termId = x.termId, yearId = x.yearId });

                }
                //return RedirectToAction("PrintByGrade", new {  gradeId = x.graddId, termId = x.termId, yearId = x.yearId });
                
            }
            ModelState.AddModelError("", "Can't Find Report");
            return View();
        }
        
        public ActionResult PrintAllReport()
        {
            var report = new ActionAsPdf("Index");
            return report;
        }
        public ActionResult IndexById(int id, int termid,int grdId,int yearId)
        {
            AssessmentBussiness ass = new AssessmentBussiness();
            //var emp = ctx.employeeinfoes.where(e=>e.empno==id).first();
            return View(ass.GetLearnerReport(id, termid, grdId,yearId));
        }
        public ActionResult GenerateAll(int termid,int grdId,int yearId)
        {
            AssessmentBussiness ass = new AssessmentBussiness();
            List<learnerReportv> reportvs = new List<learnerReportv>();
            var l = learners.GetAllLearnerWithTerms(grdId, yearId).Where(g =>g.termId==termid&& g.archive == false);
            foreach(var item in learners.GetAllLearnerWithGrade(termid,grdId,yearId))
            {
                learnerReportv learner = new learnerReportv();
                learner.learnerReports = ass.GetLearnerReport(item, termid, grdId, yearId);
                reportvs.Add(learner);
            }
            //var emp = ctx.employeeinfoes.where(e=>e.empno==id).first();
            return View(reportvs);
        }
        public ActionResult PrintAll1Report(int termid, int grdId, int yearId)
        {
            var report = new ActionAsPdf("GenerateAll", new { grdId = grdId, yearId= yearId, termid = termid });
            return report;
        }
        public ActionResult sendToAll(int termid,int grdId,int yearId)
        {
            AssessmentBussiness ass = new AssessmentBussiness();
            List<learnerReportv> reportvs = new List<learnerReportv>();
            var l = learners.GetAllLearnerWithTerms(grdId, yearId).Where(g =>g.termId==termid&& g.archive == false);
            foreach(var item in learners.GetAllLearnerWithGrade(termid,grdId,yearId))
            {
                learnerReportv learner = new learnerReportv();
                var report = new ActionAsPdf("IndexById", new { id = item, termId = termid, grdId = grdId, yearId = yearId }) { FileName = "Report.pdf" };

                //byte[] applicationPDFData = report.BuildPdf(this.ControllerContext);
                byte[] applicationPDFData = report.BuildFile(this.ControllerContext);
                Stream stream1 = new MemoryStream(applicationPDFData);
                learners.sendReport(stream1, report.FileName, item);

                learner.learnerReports = ass.GetLearnerReport(item, termid, grdId, yearId);
                reportvs.Add(learner);
            }
            //var emp = ctx.employeeinfoes.where(e=>e.empno==id).first();
            return View(reportvs);
        }
        public ActionResult DetailedReport( int termid,int grdId,int yearId)
        {
            AssessmentBussiness ass = new AssessmentBussiness();
            //var emp = ctx.employeeinfoes.where(e=>e.empno==id).first();
            return View(ass.GetSubjectReport(termid,grdId,yearId));
        }
       
        public ActionResult PrintReport(int id, int termId, int grdId, int yearId)
        {
            var report = new ActionAsPdf("IndexById",new  { id= id , termId = termId, grdId= grdId, yearId= yearId });
           

            return report;
        }
        public ActionResult DetailedSubReport( int termId, int grdId, int yearId)
        {
            var report = new ActionAsPdf("DetailedReport", new  {  termId = termId, grdId= grdId, yearId= yearId });
           
            return report;
        }
        public ActionResult sendReport(int id, int termId, int grdId, int yearId)
        {
            var report = new ActionAsPdf("IndexById", new { id = id, termId = termId, grdId = grdId, yearId = yearId }) { FileName = "Report.pdf" };
            
            //byte[] applicationPDFData = report.BuildPdf(this.ControllerContext);
            byte[] applicationPDFData = report.BuildFile(this.ControllerContext);
            Stream stream1 = new MemoryStream(applicationPDFData);
            learners.sendReport(stream1,report.FileName,id);
            return report;
        }
        public ActionResult PrintGradeReport(int id, int termId)
        {
            var report = new ActionAsPdf("GradeReport", new  {id=id,termId = termId });
            return report;
        }
        
       }
}