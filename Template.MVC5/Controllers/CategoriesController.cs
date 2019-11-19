using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.BusinessLogic;
using System.Web;
using System.IO;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class CategoriesController : Controller
    {
       
        CategoryBusiness db = new CategoryBusiness();

        // GET: Categories
        public ActionResult Index()
        {
            var Cata = db.GetAllCategorys();
            return View(Cata);

        }
        

       
        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                db.AddCategory(category);
                
                return RedirectToAction("Index");
            }

            return View(category);
        }
        
    }
}
