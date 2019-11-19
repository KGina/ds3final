using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.BusinessLogic;
using PagedList;
using System.Net;

namespace AbantwanaWebMaster.MVC5.Controllers
{
   
        // GET: Leave
        public class LeaveController : Controller
        {
        LeaveReqBusiness leaveReq = new LeaveReqBusiness();
        // GET: Leave
        [Authorize(Roles = "Teacher")]
        public ActionResult CreateRequest()
            {
            ViewBag.leaveTypeID = new SelectList(leaveReq.getLeaveTypes(), "leaveTypeID", "typeName");
            return View();
            }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var ig = (id||0);
            if (leaveReq.acrhiveType(id ?? default(int)))
            {
                return RedirectToAction("Index");
                // return HttpNotFound();
            }
            else
            {
                return HttpNotFound();
            }

        }
        public ActionResult Approve(int? id)
        {
            //Roster roster = db.rosters.Find(id);
            //EmployeeLeavel employeeLeavel = db.employeeLeavels.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View(leaveReq.getLeaveReqs(id??default(int)));

        }
        [HttpPost]
        [Authorize(Roles = "Teacher")]
        public ActionResult CreateRequest(LeaveRequest leave)
        {
            if (ModelState.IsValid)
            {
                //leave.staffmemberId = User.Identity.;
                leaveReq.createLeaveReq(leave,User.Identity.Name);
            }
            ViewBag.leaveTypeID = new SelectList(leaveReq.getLeaveTypes(), "leaveTypeID", "typeName");
            return View();
        }
        [ChildActionOnly]
        public ActionResult leavelist()
        {
            LeaveRequest nm = new LeaveRequest();
            nm.LeaveRequests = leaveReq.getLeaveReqs();
            return PartialView("_lleavelist",nm.LeaveRequests );
        }
        public ActionResult index()
        {
            int intPage = 1;
            int intPageSize = 5;
            int intTotalPageCount = 0;
            //LeaveRequest nm = new LeaveRequest();
            // nm.LeaveRequests = leaveReq.getLeaveReqs();

            var _UserDTOAsIPagedList =
                    new StaticPagedList<LeaveRequest>
                    (
                        leaveReq.getLeaveReqs(), intPage, intPageSize, intTotalPageCount
                        );


            return View(_UserDTOAsIPagedList);
        }
        public ActionResult Teacherindex()
        {
            int intPage = 1;
            int intPageSize = 5;
            int intTotalPageCount = 0;
            //LeaveRequest nm = new LeaveRequest();
            // nm.LeaveRequests = leaveReq.getLeaveReqs();

            var _UserDTOAsIPagedList =
                    new StaticPagedList<LeaveRequest>
                    (
                        leaveReq.getLeaveReqs(User.Identity.Name), intPage, intPageSize, intTotalPageCount
                        );


            return View(_UserDTOAsIPagedList);
        }
        [HttpPost]
        public ActionResult approve(LeaveRequest leave)
        {
            try
            {
                if (leaveReq.ReplaceTeacher(leave))
                {
                    return RedirectToAction("Index");
                }
            }
            catch(Exception e)
            {
                ViewBag.Message = "approval not saved. Error: " + e.Message;
            }
            ViewBag.Message = "approval not saved Please find a replacement Teacher ";
            return View(leaveReq.getLeaveReqs(leave.requestid));
        }

        //[HttpPost]
        //public JsonResult approveLeave(LeaveRequest leave)
        //{
        //    return new JsonResult { Data = new { status = leaveReq.ReplaceTeacher(leave) } };
        //}

        public ActionResult LeaveRequestCount()
        {
            
            ViewBag.count = leaveReq.counter();
            //(db.contactUs.ToList().Where(x => x.read.Equals(false))).Count();
            return View();
        }

        [HttpPost]
        public JsonResult replaceTeacher(LeaveRequest work)
        {
            return new JsonResult { Data = new { status = leaveReq.ReplaceWithTeacher(work) } };
        }


        //[HttpPost]
        public JsonResult getStaffList(int requestid)
        {
           
            return new JsonResult { Data = leaveReq.GetResources(requestid), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}