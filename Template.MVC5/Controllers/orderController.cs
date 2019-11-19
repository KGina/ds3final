using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;
using PagedList;
using System.IO;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class orderController : Controller
    {
        OrderBusiness OrderBusiness = new OrderBusiness();
        // GET: order
        public ActionResult Index()
        {
            int intPage = 1;
            int intPageSize = 5;
            int intTotalPageCount = 0;
            //LeaveRequest nm = new LeaveRequest();
            // nm.LeaveRequests = leaveReq.getLeaveReqs();

            var _UserDTOAsIPagedList =
                    new StaticPagedList<Order>
                    (
                        OrderBusiness.getOrders(), intPage, intPageSize, intTotalPageCount
                        );

            return View(_UserDTOAsIPagedList);
        }

        public ActionResult OrderItems(int? id)
        {
            //var clinicbusiness = new ClinicBusiness();

            return View(OrderBusiness.GetAllOrderItems(id??default(int)));
        }


        public ActionResult approve(int id)
        {
            ViewBag.supplierID = new SelectList(OrderBusiness.getSuppliers(), "supplierID", "name");
            Supplier sp = new Supplier();
            sp.orderID=id;
            return View("approve",sp);
        }
        [HttpPost]
        public ActionResult approve(Supplier supplier)
        {
            OrderBusiness.approveOrder(supplier.orderID);
            //  string strPDFFileName = string.Format("InvoicePdf.pdf");
            //PDFController order = new PDFController();
           // order.CreatePdf(supplier.orderID,supplier.supplierID);
          //string strAttachment = Server.MapPath(Url.Content("~/Content/" + strPDFFileName));
           // string strAttachment = Server.MapPath("~/Downloads/" + strPDFFileName);
           // string strAttachment = AppDomain.CurrentDomain.BaseDirectory+"/" + strPDFFileName;
            //OrderBusiness.sendToSupplier(supplier.orderID,supplier.supplierID);
            return RedirectToAction("Index");
        }
        public ActionResult reject(int id)
        {
            OrderBusiness.rejectOrder(id);
            return RedirectToAction("Index");
        }
    }
}