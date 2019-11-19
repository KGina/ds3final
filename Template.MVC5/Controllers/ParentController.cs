using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
//using AbantwanaWebMaster.Service;
//using AbantwanaWebMaster.Data;

namespace Template.MVC5.Controllers
{

    public class ParentController : Controller
    {
        RegistrationBusiness registerBusiness = new RegistrationBusiness();
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        public ActionResult Index()
        {
            var p = registerBusiness.GetAllParents();
            return View(p);
        }
        public FileResult OpenPDFProofOfresidence(int paID)
        {
            var fl = registerBusiness.GetPDFProofOfRes(paID);
            byte[] pdfByte = fl;
            return File(pdfByte, "application/pdf");
        }
        
        public FileResult OpenPDFIdDoc(int id)
        {
            var fl =registerBusiness.GetPDFIdDoc(id);
            byte[] pdfByte = fl;
            return File(pdfByte, "application/pdf");
        }
        
        public ActionResult Create()
        {
            List<ParentView> parents = new List<ParentView>();
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Parent")]
        public async Task<ActionResult> CreateByParent([Bind(Exclude = "IdDocument,proofofresidence")]ParentView parent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    byte[] imageData = null;
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase poImgFile = Request.Files["IdDocument"];

                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            imageData = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                    byte[] imageData2 = null;
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase poImgFile = Request.Files["proofofresidence"];

                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            imageData2 = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                    parent.proofofresidence = imageData2;
                    parent.IdDocument = imageData;
                    var registerbusiness = new AbantwanaWebMaster.BusinessLogic.RegisterBusiness();
                    RegisterModel objRegisterModel = new RegisterModel()
                    {
                        Password = registerbusiness.GeneratePassword(8),
                        UserName = parent.emailaddress
                    };
                    var emalBusiness = new AbantwanaWebMaster.BusinessLogic.EmailService();

                    if (registerBusiness.findByEmail(parent.emailaddress) == 0)
                    {
                        var result = await registerbusiness.RegisterUser(objRegisterModel, AuthenticationManager);
                        if (result)
                        {
                            var stafReg = new AbantwanaWebMaster.BusinessLogic.staffRegBusiness();
                            registerbusiness.AddUserToRole(objRegisterModel.UserName, "Parent");
                            emalBusiness.CaptureEmail(objRegisterModel.UserName, "Your Account Linked Successfully"," Please use the following credentails to login. " + "\nYour User Name is : " + objRegisterModel.UserName + "\n Your Password is : " + objRegisterModel.Password);
                        }
                        registerBusiness.AddParent(parent);
                        registerBusiness.linkChild(parent.emailaddress,User.Identity.Name);
                        string email = parent.emailaddress;
                        return RedirectToAction("AppSuccess", "LearnerProfile", new { email });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Unable to save changes. " +
                     "Try again, and Use a different email.");
                        //string email = parent.emailaddress;
                        return View();
                        //return RedirectToAction("Create");
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                  "Try again, and if the problem persists see your system administrator.");
            }
            return View(parent);
        }
        [Authorize(Roles = "Parent")]
        public ActionResult CreateByParent()
        {
            List<ParentView> parents = new List<ParentView>();
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "IdDocument,proofofresidence")]ParentView parent)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    byte[] imageData = null;
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase poImgFile = Request.Files["IdDocument"];

                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            imageData = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                    byte[] imageData2 = null;
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase poImgFile = Request.Files["proofofresidence"];

                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            imageData2 = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                    parent.proofofresidence = imageData2;
                    parent.IdDocument = imageData;
                   if(registerBusiness.findByEmail(parent.emailaddress)==0)
                    {
                        registerBusiness.AddParent(parent);
                        string email = parent.emailaddress;
                        return RedirectToAction("Create", "LearnerProfile", new { email });
                    }
                    else
                    {
                        string email = parent.emailaddress;
                        return RedirectToAction("Create", "LearnerProfile", new { email });
                        //return RedirectToAction("Create");
                    }
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                  "Try again, and if the problem persists see your system administrator.");
            }
            return View(parent);
        }
       // [HttpPost]
        public JsonResult save( List<ParentView> parent)
        {
            
                    if (parent == null)
                    {
                        parent = new List<ParentView>();
                    }
                    //Loop and insert records.
                    foreach (ParentView customer in parent)
                    {
                        registerBusiness.AddParent(customer);
                    }

                    //byte[] imageData = null;
                    //if (Request.Files.Count > 0)
                    //{
                    //    HttpPostedFileBase poImgFile = Request.Files["IdDocument"];

                    //    using (var binary = new BinaryReader(poImgFile.InputStream))
                    //    {
                    //        imageData = binary.ReadBytes(poImgFile.ContentLength);
                    //    }
                    //}
                    //byte[] imageData2 = null;
                    //if (Request.Files.Count > 0)
                    //{
                    //    HttpPostedFileBase poImgFile = Request.Files["proofofresidence"];

                    //    using (var binary = new BinaryReader(poImgFile.InputStream))
                    //    {
                    //        imageData2 = binary.ReadBytes(poImgFile.ContentLength);
                    //    }
                    //}
                    //parent.proofofresidence = imageData2;
                    //parent.IdDocument = imageData;
                    //if (registerBusiness.findByEmail(parent.emailaddress) == 0)
                    //{
                    //    registerBusiness.AddParent(parent);
                    //    //return RedirectToAction("Create", "LearnerProfile", registerBusiness.GetParentID());
                    //}
                    //else
                    //{
                    //    //return RedirectToAction("Create");
                    //}
              
            return Json("hi");
        }



    }
    }

    

       
   