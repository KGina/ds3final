
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.BusinessLogic;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        // storeDB = new ApplicationDbContext();
        const string PromoCode = "50";
        CartBusiness Business = new CartBusiness();
        public ActionResult AddressAndPayment()
        {
            return View();
        }
        public ActionResult checkoutOrder()
        {
            Business.CreateOrder(User.Identity.Name);

            return RedirectToAction("checkoutSucc");
        }

        public ActionResult checkoutSucc()
        {

            return View();
        }

        //[HttpPost]
        

       
    }
}