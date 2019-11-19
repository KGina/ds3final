using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class ThemeColorController : Controller
    {
        ThemeColorBusiness business = new ThemeColorBusiness();
        // GET: LeaveTypes

        public ActionResult Index()
        {
            return View(business.GetThemeColors());
        }



        // GET: LeaveTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "colorID,colorName,archived")] ThemeColor leaveType)
        {
            if (ModelState.IsValid)
            {
                business.createLeaveType(leaveType);
                return RedirectToAction("Index");
            }

            return View(leaveType);
        }


        //[HttpPost, ActionName("Delete")]
        // GET: LeaveTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var ig = (id||0);
            if (business.acrhiveType(id ?? default(int)))
            {
                return RedirectToAction("Index");
                // return HttpNotFound();
            }
            else
            {
                return HttpNotFound();
            }

        }
    }
}