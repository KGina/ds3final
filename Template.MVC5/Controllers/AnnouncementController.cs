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
    public class AnnouncementController : Controller
    {
        AnnouncementBusiness am = new AnnouncementBusiness();
        ClassroomBusiness ClassB = new ClassroomBusiness();
        LearnerProfileBusiness LP = new LearnerProfileBusiness();
        // GET: Announcement

        public ActionResult Index()
        {
            int intPage = 1;
            int intPageSize = 5;
            int intTotalPageCount = 0;
            //LeaveRequest nm = new LeaveRequest();
            // nm.LeaveRequests = leaveReq.getLeaveReqs();

            var _UserDTOAsIPagedList =
                    new StaticPagedList<Announcement>
                    (
                        am.GetAnnouncements(), intPage, intPageSize, intTotalPageCount
                        );


            return View(_UserDTOAsIPagedList);
            //return View();
        }
        public ActionResult pIndex()
        {
            int intPage = 1;
            int intPageSize = 5;
            int intTotalPageCount = 0;
            //LeaveRequest nm = new LeaveRequest();
            // nm.LeaveRequests = leaveReq.getLeaveReqs();

            var _UserDTOAsIPagedList =
                    new StaticPagedList<Announcement>
                    (
                        am.GetAnnouncements(User.Identity.Name), intPage, intPageSize, intTotalPageCount
                        );
            return View( _UserDTOAsIPagedList);
        }

        public ActionResult AnnouncementReceipient()
        {
            LearnerProfileBusiness LP = new LearnerProfileBusiness();

            ViewBag.learnerId = new SelectList(LP.GetAllLearners(0), "learnerId", "lname");
            return View(ClassB.GetClassrooms());
        }
        //[HttpPost]
        public JsonResult GetStudentByGrade(int id, int yearId)
        {
            LearnerProfileBusiness LP = new LearnerProfileBusiness();
           // ViewBag.learnerId = new SelectList(LP.GetAllLearners(id), "learnerId", "lname");

            return new JsonResult { Data = LP.GetAllL(id,yearId), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public ActionResult SendByStudent(int classroomid )
        {

             ViewBag.learnerId = new SelectList(LP.GetLearnerProfileByGrade(classroomid), "learnerId", "lname");
            return View();

        }



        //Add parent receipient

        public ActionResult SendByGrade()
        {

            ViewBag.classroomid = new SelectList(LP.GetLearnerProfileByClassroom(), "classRoomId", "gradename");
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //[]
        public ActionResult SendByGrade(Announcement announcement)
        {


            if (ModelState.IsValid)
            {
                am.CreateByGrade(announcement, User.Identity.Name);
                //am.newParentAnnouce(announcement.learnerId);
                return RedirectToAction("Index");
            }

            return View(announcement);
        }

        public ActionResult SendByAllLearners(int classroomid)
        {

            ViewBag.classroomid = new SelectList(LP.GetLearnerProfileByGrade(classroomid), "classroomId", "name");
            return View();

        }





        public ActionResult AnnouncementCount()
        {

            ViewBag.count = am.counter(User.Identity.Name);
            //(db.contactUs.ToList().Where(x => x.read.Equals(false))).Count();
            return View();
        }

        // POST: Announcements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[]
        public ActionResult SendByStudent( Announcement announcement)
        {

          
                if (ModelState.IsValid)
                {
                     announcement.classroomId = 0;
                     am.InsertAnnouncements(announcement,User.Identity.Name);
                     am.newParentAnnouce( announcement.learnerId);
                    return RedirectToAction("Index");
                }
            
            return View(announcement);
        }

        public ActionResult AnnouncementList()
        {
            return View(am.AnnouncementList());
        }
    }
}