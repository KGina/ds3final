using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: Login
        [AllowAnonymous]
        public ActionResult Index()
        {
            var loginview = new LoginModel();
            return View(loginview);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Index(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var loginbusiness = new LoginBusiness();
                var result = await loginbusiness.LogUserIn(model, AuthenticationManager);
                if (result)       
                    return RedirectToLocal(returnUrl);
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");
                }
            }
            //User.Identity.Name;

            return View(model);
        }
        
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}