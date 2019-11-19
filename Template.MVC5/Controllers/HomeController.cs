using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.BusinessLogic;

namespace AbantwanaWebMaster.MVC.Controllers
{
    ///[Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        CartBusiness Cart = new CartBusiness();
        connectionBussiness co = new connectionBussiness();
        public ActionResult Index()
        {
            //var clinicbusiness = new ClinicBusiness();

            return View(Cart.GetAllCarts());
        }
        public ActionResult ViewMenu()
        {
            // var Cata = db.GetAllCategorys();
            return View();

        }
        [Authorize]
        public ActionResult Chat()
        {
            Session["UserName"] = User.Identity.Name;
            return View();
        }
        public JsonResult VerifyUserNameInUse(string userName)
        {
            try
            {
                //userName=User.Identity.Name;

               
                    return Json(new { Success = true, InUse = co.GetConnection().Where(x => x.UserName.ToLower() == userName.ToLower() && x.IsOnline).SingleOrDefault() != null }, JsonRequestBehavior.AllowGet);
                
            }
            catch
            {
                return Json(new { Success = false, ErrorMessage = "Something wrong happened." }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}
