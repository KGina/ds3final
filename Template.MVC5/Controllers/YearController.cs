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
    public class YearController : Controller
    {
        YearBussiness business = new YearBussiness();
        // GET: LeaveTypes
       
        public ActionResult Index()
        {
            return View(business.getYear());
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
        public ActionResult Create( Year x)
        {
            if (ModelState.IsValid)
            {
                if (business.getYear().Where(k => k.year == x.year).Count() == 0)
                {
                    business.createYear(x);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Year Already Exist");
                    return View(x);

                }

            }

            return View(x);
        }

        
    }
}