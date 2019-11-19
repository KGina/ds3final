using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.Service;
using System.Web.Mvc;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Net.Mail;

namespace AbantwanaWebMaster.BusinessLogic
{
   public class OrderBusiness
    {
        DataContext db = new DataContext();
        public List<Model.Order> getOrders()
        {

            using (var leaveRepo = new OrderRepository())
            {
                //return leaveRepo.GetAll().Select(x => new Model.Order() { OrderId = x.OrderId, OrderDate = x.OrderDate,approval=x.approval,TotalCost=x.TotalCost }).ToList();
                List<Model.Order> kl = new List<Model.Order>();
                foreach (var item in leaveRepo.GetAll().ToList() )
                {
                 Model.Order neworder=   new Model.Order() { OrderId = item.OrderId, OrderDate = item.OrderDate, approval = item.approval, TotalCost = item.TotalCost, creator=db.Carts.Where(x=>x.orderId==item.OrderId).Select(k=>k.UserId).FirstOrDefault()};
                    kl.Add(neworder);
                }
                return kl;

            }
        }
        public List<Model.Supplier> getSuppliers()
        {

            using (var leaveRepo = new SupplierRepository())
            {
                return leaveRepo.GetAll().Select(x => new Model.Supplier() { supplierID = x.SupplierId, name = x.name }).ToList();
            }
        }
        //public void approveOrder(int id)
        //{
            
        //}
        //pdf code

        public void approveOrder(int id)
        {

            var leavedate = db.orders.Where(k => k.OrderId == id).FirstOrDefault();
            leavedate.approval = "Approved";
            db.Entry(leavedate).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void sendToSupplier(int id,int suppID)
        {

            var items = db.Carts.Where(k=>k.orderId==id).ToList();
            var supEmail = db.Suppliers.Where(k => k.SupplierId == suppID).Select(p => p.email).FirstOrDefault();
           
        }
        public string getsupplierEmail(int suppID)
        {
            var supEmail = db.Suppliers.Where(k => k.SupplierId == suppID).Select(p => p.email).FirstOrDefault();
            return supEmail;
        }
        public string getorderTotal(int id)
        {
            var tot = db.orders.Where(k => k.OrderId == id).Select(p => p.TotalCost).FirstOrDefault();
            return tot.ToString();
        }
        public List<Model.Cart> GetAllOrderItems(int id)
        {
            using (var cartrepo = new CartRepository())
            {
                return cartrepo.GetAll().Where(k=>k.orderId==id).Select(x => new Model.Cart()
                {
                    CartId = x.CartId,
                    Quantity = x.Quantity,
                    ItemId = x.ItemId,
                    DateCreated = x.DateCreated,
                    CheckOut = x.CheckOut,
                    Price = x.Item.Price,
                    description = x.Item.ItemDesciption,
                    itemname = x.Item.ItemName,
                    subTotal = x.Quantity * x.Item.Price


                }).ToList();
            }
        }
        public void rejectOrder(int id)
        {
            var leavedate = db.orders.Where(k => k.OrderId == id).FirstOrDefault();
            leavedate.approval = "Rejected";
            db.Entry(leavedate).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
