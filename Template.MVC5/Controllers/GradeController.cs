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
    public class GradeController : Controller
    {
        GradeBussiness business = new GradeBussiness();
        // GET: LeaveTypes
       
        public ActionResult Index()
        {
            return View(business.getGrade());
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
        public ActionResult Create( Grade x)
        {
            if (ModelState.IsValid)
            {
                if (business.getGrade().Where(k => k.gradeName.ToLower() == x.gradeName.ToLower()).Count() == 0)
                {
                    business.createGrade(x);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Grade Already Exist");
                    return View(x);

                }

            }

            return View(x);
        }

        
    }
}