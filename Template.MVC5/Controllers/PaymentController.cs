using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PayFast;
using PayFast.AspNet;
using System.Configuration;
using System.Threading.Tasks;
using System.Net;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.BusinessLogic;
using System.IO;
using Rotativa;
namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class PaymentController : Controller
    {
        #region Fields

        private readonly PayFastSettings payFastSettings;
        FeeBussiness fb = new FeeBussiness();

        #endregion Fields

        #region Constructor

        public PaymentController()
        {
            this.payFastSettings = new PayFastSettings();
            this.payFastSettings.MerchantId = ConfigurationManager.AppSettings["MerchantId"];
            this.payFastSettings.MerchantKey = ConfigurationManager.AppSettings["MerchantKey"];
            this.payFastSettings.PassPhrase = ConfigurationManager.AppSettings["PassPhrase"];
            this.payFastSettings.ProcessUrl = ConfigurationManager.AppSettings["ProcessUrl"];
            this.payFastSettings.ValidateUrl = ConfigurationManager.AppSettings["ValidateUrl"];
            this.payFastSettings.ReturnUrl = ConfigurationManager.AppSettings["ReturnUrl"];
            this.payFastSettings.CancelUrl = ConfigurationManager.AppSettings["CancelUrl"];
            this.payFastSettings.NotifyUrl = ConfigurationManager.AppSettings["NotifyUrl"];
        }

        #endregion Constructor

        #region Methods

        public ActionResult Index(int FeeId)
        {
            return View(fb.getInvoice(FeeId));
        }
        public ActionResult Create(int feeId,string na,string s)
        {
            Payment payment = new Payment();
            ViewBag.lName = na;
            ViewBag.SName = s;
            payment.feeId = feeId;
            return View(payment);
        }
        [HttpPost]
        public ActionResult Create(Payment payment)
        {
            if(ModelState.IsValid)
            { var kl = fb.getFees().Where(k => k.FeeId == payment.feeId).Select(l => l.feeAmount).FirstOrDefault();
                if (kl >=payment.amountPayed&&payment.amountPayed!=0)
                {
                    return RedirectToAction("OnceOff", payment);
                }
                else
                {
                    ModelState.AddModelError("", "Your Amount cannot be greater than :" + kl);
                    return View(payment);
                    
                }
            }
            return View(payment);
        }

        public ActionResult PrintReport(int FeeId)
        {
            var report = new ActionAsPdf("Index", new { FeeId = FeeId });
            return report;
        }

        public ActionResult OnceOff(Payment payment)
        {
            var onceOffRequest = new PayFastRequest(this.payFastSettings.PassPhrase);
            //var callbackUrl = Url.Action("Create", "Parents",null, protocol: Request.Url.Scheme);
            var callbackUrl = Url.Action("Return", "Payment", payment);

            // Merchant Details
            onceOffRequest.merchant_id = this.payFastSettings.MerchantId;
            onceOffRequest.merchant_key = this.payFastSettings.MerchantKey;
            onceOffRequest.SetPassPhrase(this.payFastSettings.PassPhrase);
            //onceOffRequest.return_url = this.payFastSettings.ReturnUrl;
            onceOffRequest.return_url = this.payFastSettings.ReturnUrl;

            onceOffRequest.cancel_url = this.payFastSettings.CancelUrl;
            //onceOffRequest.notify_url = this.payFastSettings.NotifyUrl;

            // Buyer Details
            onceOffRequest.email_address = "sbtu01@payfast.co.za";

            // Transaction Details 4e8d1379-688c-4d12-8d88-e9ec6078358f
            onceOffRequest.m_payment_id = "8d00bf49-e979-4004-228c-08d452b86380";
            onceOffRequest.amount = payment.amountPayed;
            onceOffRequest.item_name = "Once off option";
            onceOffRequest.item_description = "Some details about the once off payment";

            // Transaction Options
            onceOffRequest.email_confirmation = true;
            onceOffRequest.confirmation_address = "suphiwok@gmail.com";
            //invoice 

            RegistrationBusiness rg = new RegistrationBusiness();
            payment.parentId = rg.GetAllParents().Where(k => k.emailaddress == User.Identity.Name).Select(l => l.parentid).FirstOrDefault();

            fb.createPayment(payment);
            fb.updateFee(payment.feeId, payment.amountPayed);
            ViewBag.feeId = payment.feeId;
            var report = new ActionAsPdf("Index", new { feeId = payment.feeId }) { FileName = "Invoice.pdf" };

            //byte[] applicationPDFData = report.BuildPdf(this.ControllerContext);
            byte[] applicationPDFData = report.BuildFile(this.ControllerContext);
            Stream stream1 = new MemoryStream(applicationPDFData);
            fb.sendReport(stream1, report.FileName, User.Identity.Name);

            var redirectUrl = $"{this.payFastSettings.ProcessUrl}{onceOffRequest.ToString()}";
           // fb.createPayment(payment);
            //fb.updateFee(payment.feeId, payment.amountPayed);
            return Redirect(redirectUrl);
        }
        
        public ActionResult Return(Payment payment)
        {
           
            return View();
        }

        public ActionResult Cancel()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Notify([ModelBinder(typeof(PayFastNotifyModelBinder))]PayFastNotify payFastNotifyViewModel)
        {
            payFastNotifyViewModel.SetPassPhrase(this.payFastSettings.PassPhrase);

            var calculatedSignature = payFastNotifyViewModel.GetCalculatedSignature();

            var isValid = payFastNotifyViewModel.signature == calculatedSignature;

            System.Diagnostics.Debug.WriteLine($"Signature Validation Result: {isValid}");

            // The PayFast Validator is still under developement
            // Its not recommended to rely on this for production use cases
            var payfastValidator = new PayFastValidator(this.payFastSettings, payFastNotifyViewModel, IPAddress.Parse(this.HttpContext.Request.UserHostAddress));

            var merchantIdValidationResult = payfastValidator.ValidateMerchantId();

            System.Diagnostics.Debug.WriteLine($"Merchant Id Validation Result: {merchantIdValidationResult}");

            var ipAddressValidationResult = payfastValidator.ValidateSourceIp();

            System.Diagnostics.Debug.WriteLine($"Ip Address Validation Result: {merchantIdValidationResult}");

            // Currently seems that the data validation only works for successful payments
            if (payFastNotifyViewModel.payment_status == PayFastStatics.CompletePaymentConfirmation)
            {
                var dataValidationResult = await payfastValidator.ValidateData();

                System.Diagnostics.Debug.WriteLine($"Data Validation Result: {dataValidationResult}");
            }

            if (payFastNotifyViewModel.payment_status == PayFastStatics.CancelledPaymentConfirmation)
            {
                System.Diagnostics.Debug.WriteLine($"Subscription was cancelled");
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        public ActionResult Error()
        {
            return View();
        }

        #endregion Methods
    }
}
