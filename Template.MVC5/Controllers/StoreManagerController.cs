using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.BusinessLogic;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    //[Authorize(Users = "Ali@gmail.com,Ahmed@gmail.com")]
    public class StoreManagerController : Controller
    {
        // private  db = new ApplicationDbContext();
        StoreManagerBusiness business = new StoreManagerBusiness();
        // GET: StoreManager
        public ActionResult Index()
        {
            //var items = db.Items.Include(i => i.Category).Include(i => i.Producer);
            return View(business.itemList());
        }
        public ActionResult View1()
        {
            //var items = db.Items.Include(i => i.Category).Include(i => i.Producer);
            return View(business.itemList());
        }

        // GET: StoreManager/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            if (business.Find(id??default(int)) == null)
            {
                return HttpNotFound();
            }
            return View(business.Find(id??default(int)));
        }

        // GET: StoreManager/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(business.GetAllCatergory(), "CategoryId", "Name");
            //ViewBag.SupplierId = new SelectList(business.GetAllSuppliers(), "supplierID", "name");
            return View();
        }

        // POST: StoreManager/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item, HttpPostedFileBase image1)
        {
            //var db = new ApplicationDbContext();
            if (image1 != null)
            {
                item.Picture = new byte[image1.ContentLength];
                image1.InputStream.Read(item.Picture, 0, image1.ContentLength);
            }
            if (ModelState.IsValid)
            {
                business.addNewItem(item);
               // db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.CategoryId = new SelectList(business.GetAllCatergory(), "CategoryId", "Name");
           // ViewBag.ProducerId = new SelectList(business.GetAllSuppliers(), "supplierID", "name");
            ViewBag.CategoryId = new SelectList(business.GetAllCatergory(), "CategoryId", "Name", item.CategoryId);
            //ViewBag.SupplierId = new SelectList(business.GetAllSuppliers(), "supplierID", "name", item.SupplierId);
            return View(item);
        }

        // GET: StoreManager/Edit/5
       

        // GET: StoreManager/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           // Item item = db.Items.Find(id);
            if (business.Find(id??default(int)) == null)
            {
                return HttpNotFound();
            }
            return View(business.Find(id ?? default(int)));
        }

        // POST: StoreManager/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int id)
        {
            

            return new JsonResult { Data = new { status = business.deleteItem(id)} };
        }

        
    }
}
