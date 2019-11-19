using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.BusinessLogic;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class StoreController : Controller
    {
        CategoryBusiness categories = new CategoryBusiness();
        //private object Customerlist;

        // GET: Store

        public ActionResult Index()
        {
            
            return View(categories.GetAllCategorys());
        }
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            //var categories = storeDB.Categories.ToList();
            return PartialView(categories.GetAllCategorys());

        }
        public ActionResult Browse(string category)
        {
            //var categoryModel = storeDB.Categories.Include("Items")
            //    .Single(c => c.Name == category);
            return View(categories.Browse(category));
        }
        public ActionResult Details(int id)
        {
            var Item =categories.Find(id);
            return View(categories.Find(id));
        }


        public ActionResult BrowsItem()

        {

            //Using foreach loop fill data from custmerlist to List<CustomerVM>.

            return View(categories.browserList()); //List of CustomerVM (ViewModel)

        }

    }

}

