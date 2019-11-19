using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class SuppliersController : Controller
    {
        // GET: Suppliers
        supplierBusiness supplier = new supplierBusiness();
        public ActionResult Index()
        {
            return View(supplier.GetAllSuppliers().Where(g => g.archive == false));
        }

        

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        [HttpPost]
        public ActionResult Create(Supplier supplier100)
        {
            try
            {
                // TODO: Add insert logic here
                supplier.addsupplier(supplier100);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ArchiveSupplier(int? id)
        {
            var l = supplier.GetAllSuppliers().Where(g => g.archive == true);
            return View(l);
        }

        public ActionResult arch(int id)
        {
            supplier.arch(id);
            return RedirectToAction("ArchiveSupplier");
        }public ActionResult Restore(int id)
        {
            supplier.Restore(id);
            return RedirectToAction("Index");
        }

    }
}
