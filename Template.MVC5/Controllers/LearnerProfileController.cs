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
using System.Net;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class LearnerProfileController : Controller
    {
        LearnerProfileBusiness learners = new LearnerProfileBusiness();
        RegistrationBusiness registerBusiness = new RegistrationBusiness();
        FeeBussiness fb = new FeeBussiness();
        AbantwanaWebMaster.BusinessLogic.RegisterBusiness regibusiness = new AbantwanaWebMaster.BusinessLogic.RegisterBusiness();
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        // GET: LearnerProfile
        public ActionResult Index(int? id)
        {
            var l = learners.GetAllLearners(id);
            if (id==0)
            {
                return View( learners.GetAllLearnersForp(User.Identity.Name).Where(g => g.archive == false));
            }
            return View(l);
        }
        public ActionResult AllApproved(int? id)
        {
            var l = learners.GetAllLearners(0).Where(g => g.archive == false);
            return View(l);
        }
        public ActionResult ReJectedLearners(int? id)
        {
            var l = learners.GetAllRejectedLearners().Where(g => g.archive == false);
            return View(l);
        }
        public ActionResult ArchiveLearners(int? id)
        {
            var l = learners.GetAllLean().Where(g=>g.archive==true);
           
            
            return View(l);
        }
        public ActionResult FeeIndex(int id)
        {
            ViewBag.lName = learners.GetLearnerName(id);
            ViewBag.SName = learners.GetLearnerSurName(id);
            var l = fb.getFees();
            
            return View(l);
        }
        
        public ActionResult arch(int id)
        {
             learners.arch(id);
            return RedirectToAction("ReJectedLearners");
        }
        public ActionResult Restore(int id)
        {
             learners.Restore(id);
            return RedirectToAction("AllApproved");
        }
        public ActionResult parentIndex()
        {
            
                return View( learners.GetAllLearnersForp(User.Identity.Name));
          
        }
        public ActionResult Create(string email)
        {
            LearnerProfileView obj = new LearnerProfileView();
            ViewBag.grade = new SelectList(learners.GetLearnerProfileByClassroom(), "gradename", "gradename");
            obj.parentEmail = email;
            if (email == "")
            {
                obj.parentEmail = User.Identity.Name;
            }
            return View(obj);
        }
        //[HttpPost]
        public async Task<ActionResult> approve(int pId)
        {
            var registerbusiness = new AbantwanaWebMaster.BusinessLogic.RegisterBusiness();
            RegisterModel objRegisterModel = new RegisterModel()
            {
                Password = regibusiness.GeneratePassword(8),
                UserName = learners.emailapproval(pId)
            };
            var emalBusiness = new AbantwanaWebMaster.BusinessLogic.EmailService();
            
            if (regibusiness.FindUser(objRegisterModel.UserName, AuthenticationManager))
            {
               // emalBusiness.CaptureEmail(objRegisterModel.UserName, "Your Application was successfully", "Your Child " + learners.learnerName(pId) + " has been accepted to study at Abantwana Daycare.");
            }
            else
            {
                var result = await registerbusiness.RegisterUser(objRegisterModel, AuthenticationManager);
                if (result)
                {
                    var stafReg = new AbantwanaWebMaster.BusinessLogic.staffRegBusiness();
                    regibusiness.AddUserToRole(objRegisterModel.UserName, "Parent");
                   // emalBusiness.CaptureEmail(objRegisterModel.UserName, "Your Application was successfully", "Your Child " + learners.learnerName(pId) + " has been accepted to study at Abantwana Daycare. Please use the following credentails to login. " + "\nYour User Name is : " + objRegisterModel.UserName + "\n Your Password is : " + objRegisterModel.Password);
                }
            }
            //stafReg.regStaffMembers(staffMember);
            return RedirectToAction("LearnerAllocation","Classroom",new { id=pId});

        }
       // [HttpPost]
        public ActionResult Reject(int pId)
        {

           
            var emalBusiness = new AbantwanaWebMaster.BusinessLogic.EmailService();
            emalBusiness.CaptureEmail(learners.emailRejected(pId), "Your Application was Not Successful", "Your Child " + learners.learnerName(pId) + " was not accepted to study at Abantwana Daycare. ");
           
            return RedirectToAction("AppSuccess");

        }
        //[HttpPost]
        public ActionResult SendEmail(int pId)
        {


            //var emalBusiness = new AbantwanaWebMaster.BusinessLogic.EmailService();
            //emalBusiness.CaptureEmail(learners.emailapproval(pId), "Your Application was Not Successful", "Your Child " + learners.learnerName(pId) + " was not accepted to study at Abantwana Daycare. ");
            announce announce = new announce();
            announce.ToEmail = learners.emailCallBack(pId);
            return View(announce);

        }
        [HttpPost]
        public ActionResult SendEmail(announce announce)
        {


            var emalBusiness = new AbantwanaWebMaster.BusinessLogic.EmailService();
            //emalBusiness.CaptureEmail(learners.emailapproval(pId), "Your Application was Not Successful", "Your Child " + learners.learnerName(pId) + " was not accepted to study at Abantwana Daycare. ");

            return RedirectToAction("AppSuccess");

        }
        public ActionResult AppSuccess()
        {
            return View();
        }

        public FileContentResult UserPhotos(int learnerId)
        {

            if (learnerId == 0)
            {
                string fileName = HttpContext.Server.MapPath(@"~/Images/noImg.png");

                byte[] imageData = null;
                FileInfo fileInfo = new FileInfo(fileName);
                long imageFileLength = fileInfo.Length;
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)imageFileLength);

                return File(imageData, "image/png");

            }
            else
            {
                var pic = learners.getPic(learnerId);
                return new FileContentResult(pic, "image/jpeg");

            }



        }



        public FileResult OpenPDFIdDoc(int id)
        {
            var fl = learners.GetPDFIdDoc(id);
            byte[] pdfByte = fl;
            return File(pdfByte, "application/pdf");
        }

        public FileResult OpenPDFMedDoc(int id)
        {
            var fl = learners.OpenPDFMeDoc(id);
            byte[] pdfByte = fl;
            return File(pdfByte, "application/pdf");
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Picture,medicalCertificate,BirthCertificate")]LearnerProfileView learner)
        {
            try
            {
                
                    byte[] imageData = null;
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase poImgFile = Request.Files["medicalCertificate"];

                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            imageData = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                    byte[] imageData2 = null;
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase poImgFile = Request.Files["BirthCertificate"];

                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            imageData2 = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                    byte[] Pic = null;
                    if (Request.Files.Count > 0)
                    {
                        HttpPostedFileBase poImgFile = Request.Files["Picture"];

                        using (var binary = new BinaryReader(poImgFile.InputStream))
                        {
                            Pic = binary.ReadBytes(poImgFile.ContentLength);
                        }
                    }
                    learner.Picture = Pic;
                    learner.BirthCertificate = imageData2;
                    learner.medicalCertificate = imageData;
                    learners.AddLearner(learner);
                    return RedirectToAction("AppSuccess");
            }
            //}
            catch (Exception e)
            {
                ModelState.AddModelError(""+ e.ToString(), "Unable to save changes. " +
                 "Try again, and if the problem persists see your system administrator.");
                ViewBag.grade = new SelectList(learners.GetLearnerProfileByClassroom(), "gradename", "gradename");

                return RedirectToAction("AppSuccess");
            }
           
        }
    }
}