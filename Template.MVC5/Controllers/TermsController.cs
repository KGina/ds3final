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
    public class TermsController : Controller
    {
        termBussiness business = new termBussiness();
        // GET: LeaveTypes
       
        public ActionResult Index()
        {
            return View(business.getTerm());
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
        public ActionResult Create( Term leaveType)
        {
            if (ModelState.IsValid)
            {
               business.createTerm(leaveType);
                return RedirectToAction("Index");
            }

            return View(leaveType);
        }

        
    }
}