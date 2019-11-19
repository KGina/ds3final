using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;

using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;
using System.Threading.Tasks;
using System.IO;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class StaffMembersController : Controller
    {
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        // GET: StaffMembers
        public ActionResult Index()
        {
            var registerbusiness = new AbantwanaWebMaster.BusinessLogic.staffRegBusiness();
            return View(registerbusiness.GetStaffMembers());
        }
        // GET: StaffMembers/Create
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Exclude = "UserPhoto")] StaffMember staffMember)
        {
            if (ModelState.IsValid)
            {
                var registerbusiness = new AbantwanaWebMaster.BusinessLogic.RegisterBusiness();

                if (registerbusiness.FindUser(staffMember.email, AuthenticationManager))
                {
                    ModelState.AddModelError("", "User already exists");
                    return View(staffMember);
                }
                byte[] imageData = null;
                if (Request.Files.Count > 0)
                {
                    HttpPostedFileBase poImgFile = Request.Files["UserPhoto"];

                    using (var binary = new BinaryReader(poImgFile.InputStream))
                    {
                        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    }
                }
                staffMember.UserPhoto = imageData;

                RegisterModel objRegisterModel = new RegisterModel()
                {
                   Password = registerbusiness.GeneratePassword(8),
                   UserName = staffMember.email
                 };
                
                var emalBusiness = new AbantwanaWebMaster.BusinessLogic.EmailService();
                emalBusiness.CaptureEmail(objRegisterModel.UserName,"Your Account was successfully Created" ,"Your User Name is : "+objRegisterModel.UserName+"\n Your Password is : "+objRegisterModel.Password);
                var result = await registerbusiness.RegisterUser(objRegisterModel, AuthenticationManager);
                var stafReg = new AbantwanaWebMaster.BusinessLogic.staffRegBusiness();
               
                if (result)
                {
                    registerbusiness.AddUserToRole(staffMember.email,"Teacher");
                    stafReg.regStaffMembers(staffMember);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result.ToString());
                }

            }

            return View(staffMember);
        }
    }
}