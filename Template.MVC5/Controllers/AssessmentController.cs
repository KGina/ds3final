using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;
using ExcelDataReader;
using PagedList;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class AssessmentController : Controller
    {
       // YearBussiness business = new YearBussiness();
        // GET: LeaveTypes
        SubjectBusiness SB = new SubjectBusiness();
        GradeBussiness gb = new GradeBussiness();
        LearnerProfileBusiness lpb = new LearnerProfileBusiness();
        YearBussiness yb = new YearBussiness();
        AssessmentBussiness ab=new AssessmentBussiness();
        ClassroomBusiness cb = new ClassroomBusiness();
        termBussiness tb = new termBussiness();

        public ActionResult GradeIndex()
        {
            return View(gb.getGrade());
        }
        //public ActionResult bulkInsert()
        //{
        //    return View();
        //}

        public ActionResult Index(int subjectId, int gradeId, int yearId, int termId)
        {
            ViewBag.subjectId = subjectId;
            ViewBag.gradeId = gradeId;
            ViewBag.yearId = yearId;
            ViewBag.termId = termId;
            ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == subjectId).Select(o => o.subjectName).FirstOrDefault();
            ViewBag.gradeName = gb.getGrade().Where(i => i.gradeId == gradeId).Select(o => o.gradeName).FirstOrDefault();
            ViewBag.year = yb.getYear().Where(i => i.yearId == yearId).Select(o => o.year).FirstOrDefault();
            ViewBag.name = tb.getTerm().Where(i => i.termId == termId).Select(o => o.name).FirstOrDefault();
            List<Assessment> l = ab.getAssoo(subjectId, gradeId, yearId, termId);
            int intPage = 1;
            int intPageSize = 5;
            int intTotalPageCount = 0;
            //LeaveRequest nm = new LeaveRequest();
            // nm.LeaveRequests = leaveReq.getLeaveReqs();

            var _UserDTOAsIPagedList =
                    new StaticPagedList<Assessment>
                    (
                        l, intPage, intPageSize, intTotalPageCount
                        );
            
            return View(_UserDTOAsIPagedList);
        }

        // GET: assessment/Create
        public ActionResult Create(int subjectId, int gradeId, int yearId, int termId)
        {
            ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == subjectId).Select(o => o.subjectName).FirstOrDefault();
            ViewBag.gradeName = gb.getGrade().Where(i => i.gradeId == gradeId).Select(o => o.gradeName).FirstOrDefault();
            ViewBag.year = yb.getYear().Where(i => i.yearId == yearId).Select(o => o.year).FirstOrDefault();
            ViewBag.name = tb.getTerm().Where(i => i.termId == termId).Select(o => o.name).FirstOrDefault();
            Assessment a = new Assessment();
            a.termId = termId;
            a.subjectId = subjectId;
            a.yearId = yearId;
            a.gradeId = gradeId;
            return View(a);
        }
        //public ActionResult CaptureMark(int subjectId, int yearId, int termId,int assessmentId,int classRoomId)
        //{
        //    ViewBag.subjectId = subjectId;
        //    var gradeId = cb.GetgradeId(classRoomId);
        //    ViewBag.gradeId = gradeId;
        //    ViewBag.yearId = yearId;
        //    ViewBag.termId = termId;
        //    ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == subjectId).Select(o => o.subjectName).FirstOrDefault();
        //    ViewBag.className = cb.GetClassrooms().Where(i => i.classRoomId == classRoomId).Select(o => o.className).FirstOrDefault();
        //    ViewBag.year = yb.getYear().Where(i => i.yearId == yearId).Select(o => o.year).FirstOrDefault();
        //    ViewBag.name = tb.getTerm().Where(i => i.termId == termId).Select(o => o.name).FirstOrDefault();
        //    ViewBag.assname = ab.getAssess().Where(i => i.assessmentId == assessmentId).Select(o => o.assessmentName).FirstOrDefault();

        //    return View(ab.GetAllLearnersByClassRoom(yearId,subjectId,gradeId,classRoomId,assessmentId,termId));
        //}
        public ActionResult CaptureMark(int subjectId, int yearId, int termId,int assessmentId,int classRoomId)
        {
            ViewBag.subjectId = subjectId;
            var gradeId = cb.GetgradeId2(classRoomId);
            ViewBag.gradeId = gradeId;
            ViewBag.yearId = yearId;
            ViewBag.termId = termId;
            ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == subjectId).Select(o => o.subjectName).FirstOrDefault();
            ViewBag.className = cb.GetClassrooms().Where(i => i.classRoomId == classRoomId).Select(o => o.className).FirstOrDefault();
            ViewBag.year = yb.getYear().Where(i => i.yearId == yearId).Select(o => o.year).FirstOrDefault();
            ViewBag.name = tb.getTerm().Where(i => i.termId == termId).Select(o => o.name).FirstOrDefault();
            ViewBag.assname = ab.getAssess().Where(i => i.assessmentId == assessmentId).Select(o => o.assessmentName).FirstOrDefault();
           
            return View(ab.GetAllLearnersByClassRoom(yearId,subjectId,gradeId,classRoomId,assessmentId,termId));
        }
        //[HttpPost]
        public ActionResult bulkInsert(int subjectId, int yearId, int termId,int assessmentId,int classRoomId)
        {
            ViewBag.subjectId = subjectId;
            var gradeId = cb.GetgradeId2(classRoomId);
            ViewBag.gradeId = gradeId;
            ViewBag.yearId = yearId;
            ViewBag.termId = termId;
            ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == subjectId).Select(o => o.subjectName).FirstOrDefault();
            ViewBag.className = cb.GetClassrooms().Where(i => i.classRoomId == classRoomId).Select(o => o.className).FirstOrDefault();
            ViewBag.year = yb.getYear().Where(i => i.yearId == yearId).Select(o => o.year).FirstOrDefault();
            ViewBag.name = tb.getTerm().Where(i => i.termId == termId).Select(o => o.name).FirstOrDefault();
            ViewBag.assname = ab.getAssess().Where(i => i.assessmentId == assessmentId).Select(o => o.assessmentName).FirstOrDefault();
           
            return View(ab.GetAllLearnersByClassRoom(yearId,subjectId,gradeId,classRoomId,assessmentId,termId).FirstOrDefault());
        }
        [HttpPost]
        public ActionResult bulkInsert(HttpPostedFileBase upload, LearnerAssessment learner)
        {
            List<LearnerAssessment> lio = new List<LearnerAssessment>();
            if (upload != null && upload.ContentLength > 0)
            {
                // ExcelDataReader works with the binary Excel file, so it needs a FileStream
                // to get started. This is how we avoid dependencies on ACE or Interop:
                Stream stream = upload.InputStream;

                IExcelDataReader reader = null;


                if (upload.FileName.EndsWith(".xls"))
                {
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (upload.FileName.EndsWith(".xlsx"))
                {
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                else
                {
                    ModelState.AddModelError("File", "This file format is not supported");
                    return View();
                }
                int fieldcount = reader.FieldCount;
                int rowcount = reader.RowCount;
                DataTable dt = new DataTable();
                DataRow row;
                DataTable dt_ = new DataTable();
                try
                {
                    dt_ = reader.AsDataSet().Tables[0];
                    for (int i = 0; i < dt_.Columns.Count; i++)
                    {
                        dt.Columns.Add(dt_.Rows[0][i].ToString());
                    }
                    int rowcounter = 0;
                    for (int row_ = 1; row_ < dt_.Rows.Count; row_++)
                    {
                        row = dt.NewRow();


                        if(count(learner, Convert.ToInt32(dt_.Rows[row_][0]))>0)
                        {
                            learner.learnerId = Convert.ToInt32(dt_.Rows[row_][0]);
                             learner.Name = dt_.Rows[row_][2].ToString();
                            learner.AssessmentMark= Convert.ToInt32(dt_.Rows[row_][3]);
                        }
                        lio.Add(learner);
                        //Students students = new Students();
                        //students.Name = dt_.Rows[row_][1].ToString();
                        //students.Country = dt_.Rows[row_][2].ToString();
                        //db.Students.Add(students);
                        //db.SaveChanges();


                        for (int col = 0; col < dt_.Columns.Count; col++)
                        {
                            row[col] = dt_.Rows[row_][col].ToString();
                            rowcounter++;
                        }
                        dt.Rows.Add(row);
                    }


                foreach (var ih in lio)
                {
                    ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == ih.subjectId).Select(o => o.subjectName).FirstOrDefault();
                    ViewBag.className = cb.GetClassrooms().Where(i => i.classRoomId == ih.classID).Select(o => o.className).FirstOrDefault();
                    ViewBag.year = yb.getYear().Where(i => i.yearId == ih.yearId).Select(o => o.year).FirstOrDefault();
                    ViewBag.name = tb.getTerm().Where(i => i.termId == ih.termId).Select(o => o.name).FirstOrDefault();
                    ViewBag.assname = ab.getAssess().Where(i => i.assessmentId == ih.assessmentId).Select(o => o.assessmentName).FirstOrDefault();
                    //ih.assessmentId = ih.assessmentId;
                    if (ab.getTot(ih.assessmentId) < ih.AssessmentMark)
                    {
                        //ViewBag.assessmentId = new SelectList(asb.GetAssessmentsBySubject(asb.getsub(or.assessmentId)), "assessmentId", "assessmentName");

                        ModelState.AddModelError("", "Unable to save Marks Cannot Be greater " + ab.getTot(ih.assessmentId) + ", Check Learner No." + ih.learnerId );
                        return View(learner);
                    }
                }
                YearLearnerGradeSubjectAssessment x = new YearLearnerGradeSubjectAssessment();
                //ViewBag.assessmentId = new SelectList(asb.GetAssessmentsBySubject(id), "assessmentId", "assessmentName");
                foreach (var ih in lio)
                {
                    x.yearId = ih.yearId;
                    x.assessmentId = ih.assessmentId;
                    x.subjectId = ih.subjectId;
                    x.gradeId = ih.gradeid;
                    x.learnerId = ih.learnerId;
                    x.mark = ih.AssessmentMark;
                    x.yearId = ih.yearId;
                    if (ab.getLearnerAssess().Where(p => p.assessmentId == ih.assessmentId && p.learnerId == ih.learnerId).Count() > 0)
                    {
                        ab.updateLeanerAssess(x);
                    }
                    else
                    {
                        ab.createLeanerAssess(x);
                    }
                }
                    return RedirectToAction("Index", new { subjectId = x.subjectId, gradeId = x.gradeId, termId = ab.getAssess().Where(p => p.assessmentId == x.assessmentId).Select(y => y.termId).FirstOrDefault(), yearId = x.yearId });

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("File", "Unable to Upload file!");
                   return View(learner);
                }
            }
                return View(learner);
        }
        public ActionResult VMark(int subjectId, int yearId, int termId,int assessmentId,int classRoomId)
        {
            ViewBag.subjectId = subjectId;
            var gradeId = cb.GetClassrooms().Where(i => i.classRoomId == classRoomId).Select(o => o.graddId).FirstOrDefault(); ;
            ViewBag.gradeId = gradeId;
            ViewBag.yearId = yearId;
            ViewBag.termId = termId;
            ViewBag.gradeName =gb.getGrade().Where(i => i.gradeId == gradeId).Select(o => o.gradeName).FirstOrDefault();
            ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == subjectId).Select(o => o.subjectName).FirstOrDefault();
            ViewBag.className = cb.GetClassrooms().Where(i => i.classRoomId == classRoomId).Select(o => o.className).FirstOrDefault();
            ViewBag.year = yb.getYear().Where(i => i.yearId == yearId).Select(o => o.year).FirstOrDefault();
            ViewBag.name = tb.getTerm().Where(i => i.termId == termId).Select(o => o.name).FirstOrDefault();
            ViewBag.assname = ab.getAssess().Where(i => i.assessmentId == assessmentId).Select(o => o.assessmentName).FirstOrDefault();
           
            return View(ab.GetAllLearnersByClassRoom(yearId,subjectId,gradeId,classRoomId,assessmentId,termId));
        }
        [HttpPost]
        public ActionResult CaptureMark( List<LearnerAssessment> vMs)
        {
            
            foreach (var ih in vMs)
            {
                ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == ih.subjectId).Select(o => o.subjectName).FirstOrDefault();
                ViewBag.className = cb.GetClassrooms().Where(i => i.classRoomId == ih.classID).Select(o => o.className).FirstOrDefault();
                ViewBag.year = yb.getYear().Where(i => i.yearId == ih.yearId).Select(o => o.year).FirstOrDefault();
                ViewBag.name = tb.getTerm().Where(i => i.termId == ih.termId).Select(o => o.name).FirstOrDefault();
                ViewBag.assname = ab.getAssess().Where(i => i.assessmentId == ih.assessmentId).Select(o => o.assessmentName).FirstOrDefault();
                //ih.assessmentId = ih.assessmentId;
                if (ab.getTot(ih.assessmentId) < ih.AssessmentMark)
                {
                    //ViewBag.assessmentId = new SelectList(asb.GetAssessmentsBySubject(asb.getsub(or.assessmentId)), "assessmentId", "assessmentName");

                    ModelState.AddModelError("", "Unable to save Marks Cannot Be greater " + ab.getTot(ih.assessmentId)+" Check "+ih.Name+"'s Mark");
                    return View(vMs);
                }
            }
            YearLearnerGradeSubjectAssessment x = new YearLearnerGradeSubjectAssessment();
            //ViewBag.assessmentId = new SelectList(asb.GetAssessmentsBySubject(id), "assessmentId", "assessmentName");
            foreach (var ih in vMs)
            {
                x.yearId = ih.yearId;
                x.assessmentId = ih.assessmentId;
                x.subjectId = ih.subjectId;
                x.gradeId = ih.gradeid;
                x.learnerId = ih.learnerId;
                x.mark = ih.AssessmentMark;
                x.yearId = ih.yearId;
                if (ab.getLearnerAssess().Where(p=>p.assessmentId==ih.assessmentId&&p.learnerId==ih.learnerId).Count()>0)
                {
                    ab.updateLeanerAssess(x);
                }
                else
                {
                    ab.createLeanerAssess(x);
                }
            }
            return RedirectToAction("Index",new { subjectId = x.subjectId, gradeId = x.gradeId, termId = ab.getAssess().Where(p=>p.assessmentId==x.assessmentId).Select(y=>y.termId).FirstOrDefault(), yearId = x.yearId });
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Assessment x)
        {
            ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == x.subjectId).Select(o => o.subjectName).FirstOrDefault();
            ViewBag.gradeName = gb.getGrade().Where(i => i.gradeId == x.gradeId).Select(o => o.gradeName).FirstOrDefault();
            ViewBag.year = yb.getYear().Where(i => i.yearId == x.yearId).Select(o => o.year).FirstOrDefault();
            ViewBag.name = tb.getTerm().Where(i => i.termId == x.termId).Select(o => o.name).FirstOrDefault();
            if (ModelState.IsValid)
            { 
                int wor = (int)ab.getAssess().Where(k => k.yearId == x.yearId && k.termId == x.termId && k.gradeId == x.gradeId && k.subjectId == x.subjectId&&k.assessmentName.ToLower()==x.assessmentName.ToLower()).Count();

                if (wor > 0)
                {
                    ModelState.AddModelError("", "You Already Have An Assessment Called" + x.assessmentName );
                    return View(x);
                }
                else
                {
                    int we = (int)ab.getAssess().Where(k => k.yearId == x.yearId && k.termId == x.termId && k.gradeId == x.gradeId && k.subjectId == x.subjectId).Select(h => h.weightings).Sum();
                    if (we + x.weightings > 100)
                    {
                        
                        ModelState.AddModelError("", "You Already Have " + we + "% Weighting Saved");
                        return View(x);

                    }
                    else
                    {
                        ab.createAssessr(x);
                        return RedirectToAction("Index", new { subjectId = x.subjectId, gradeId = x.gradeId, termId = x.termId, yearId = x.yearId });


                    }
                }

            }
            return View(x);
        }
        public ActionResult Edit(int assessmentId)
        {
            Assessment a = new Assessment();
            a = ab.getAssess().Where(d => d.assessmentId == assessmentId).FirstOrDefault();
            ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == a.subjectId).Select(o => o.subjectName).FirstOrDefault();
            ViewBag.gradeName = gb.getGrade().Where(i => i.gradeId == a.gradeId).Select(o => o.gradeName).FirstOrDefault();
            ViewBag.year = yb.getYear().Where(i => i.yearId == a.yearId).Select(o => o.year).FirstOrDefault();
            ViewBag.name = tb.getTerm().Where(i => i.termId == a.termId).Select(o => o.name).FirstOrDefault();
           
            return View(a);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Assessment x)
        {
            ViewBag.subjectName = SB.GetSubjects().Where(i => i.subjectId == x.subjectId).Select(o => o.subjectName).FirstOrDefault();
            ViewBag.gradeName = gb.getGrade().Where(i => i.gradeId == x.gradeId).Select(o => o.gradeName).FirstOrDefault();
            ViewBag.year = yb.getYear().Where(i => i.yearId == x.yearId).Select(o => o.year).FirstOrDefault();
            ViewBag.name = tb.getTerm().Where(i => i.termId == x.termId).Select(o => o.name).FirstOrDefault();
            if (ModelState.IsValid)
            {
                int wor = (int)ab.getAssess().Where(k => k.yearId == x.yearId && k.termId == x.termId && k.gradeId == x.gradeId && k.subjectId == x.subjectId &&k.assessmentId!=x.assessmentId&& k.assessmentName.ToLower() == x.assessmentName.ToLower()).Count();

                if (wor > 0)
                {
                    ModelState.AddModelError("", "You Already Have An Assessment Called" + x.assessmentName);
                    return View(x);
                }
                else
                {
                    int we = (int)ab.getAssess().Where(k => k.yearId == x.yearId&& k.assessmentId != x.assessmentId && k.termId == x.termId && k.gradeId == x.gradeId && k.subjectId == x.subjectId).Select(h => h.weightings).Sum();
                    if (we + x.weightings > 100)
                    {

                        ModelState.AddModelError("", "You Already Have " + we + "% Weighting Saved");
                        return View(x);

                    }
                    else
                    {
                        ab.updateAssess(x);
                        return RedirectToAction("Index", new { subjectId = x.subjectId, gradeId = x.gradeId, termId = x.termId, yearId = x.yearId, });


                    }
                }

            }
            return View(x);
        }
        public int count(LearnerAssessment learner, int id)
        {
            return (ab.GetAllLearnersByClassRoom(learner.yearId, learner.subjectId, learner.gradeid, learner.classID, learner.assessmentId, learner.termId).Where(p=>p.learnerId==id).Count());
        }

    }
}