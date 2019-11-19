using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.Service;
using System.Web;
using System.IO;
using System.Threading.Tasks;

using System.Data.Entity;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class supplierBusiness
    {
        public UserManager<AbantwanaWebMaster.Data.ApplicationUser> UserManager { get; set; }

        public supplierBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));
        }
        DataContext db = new DataContext();


        public List<Model.Supplier> GetAllSuppliers()
        {
            using (var cartrepo = new SupplierRepository())
            {
                return cartrepo.GetAll().Select(x => new Model.Supplier()
                {
                    supplierID = x.SupplierId,
                    name = x.name,
                    phonenumber = x.phonenumber,
                    physicaladdress = x.physicaladdress,
                    email=x.email,
                    archive=x.archive
                    
                    
                }).ToList();
            }
        }
        public void arch(int id)
        {
           // var pID = db.ParentLearners.Where(x => x.learnerId == id).Select(k => k.parentid).FirstOrDefault();
            var learnerApp = db.Suppliers.Where(k => k.SupplierId == id).FirstOrDefault();
            learnerApp.archive = true;
            db.Entry(learnerApp).State = EntityState.Modified;
            db.SaveChanges();

        }
        public void Restore(int id)
        {
           // var pID = db.ParentLearners.Where(x => x.learnerId == id).Select(k => k.parentid).FirstOrDefault();
            var learnerApp = db.Suppliers.Where(k => k.SupplierId == id).FirstOrDefault();
            learnerApp.archive = false;
            db.Entry(learnerApp).State = EntityState.Modified;
            db.SaveChanges();

        }
        public List<Model.Cart> GetCartItems(string userId)
        {
            using (var cartrepo = new CartRepository())
            {
                return cartrepo.GetAll().Where(n=>n.UserId==userId &&n.CheckOut==false).Select(x => new Model.Cart()
                {
                    CartId = x.CartId,
                    Quantity = x.Quantity,
                    DateCreated = x.DateCreated,
                    CheckOut = x.CheckOut,
                    ItemId=x.ItemId,
                    UserId=x.UserId,
                    itemname=x.Item.ItemName,
                    Price=x.Item.Price

                }).ToList();
            }
        }
        public decimal GetTotal(string userId)
        {
            decimal total = 0;
            var h = db.Carts.Where(u => u.UserId == userId&&u.CheckOut==false).FirstOrDefault();
            if (h!=null)
            {
                total = (from cartItems in db.Carts
                         where cartItems.UserId == userId && cartItems.CheckOut == false
                         select cartItems.Quantity *
                         cartItems.Item.Price).Sum();
            }

            return (total );
        }
        public string ItemName(int cartid)
        {

            string name = db.Carts.Where(v => v.CartId == cartid && v.CheckOut == false).Select(v => v.Item.ItemName).FirstOrDefault();
                             

            return name;
        }
        public object Entry(object item)
        {
            throw new NotImplementedException();
        }
        public void addsupplier(Model.Supplier objPV)
        {
            using (var cartrepo = new SupplierRepository())
            {
                var cart = new Data.Supplier
                {
                    SupplierId = objPV.supplierID,
                    name = objPV.name,
                    phonenumber = objPV.phonenumber,
                    physicaladdress = objPV.physicaladdress,
                    email = objPV.email
                   
                };
                cartrepo.Insert(cart);
            }
            
        }
        public void AddToCart(int id, string username)
        {
            var cartItem = db.Carts.SingleOrDefault(
                c => c.UserId == username
                && c.ItemId ==id&&c.CheckOut==false);

            if (cartItem == null)
            {

                cartItem = new Data.Cart
                {
                    ItemId = id,
                    UserId = username,
                    Quantity = 1,
                    DateCreated = DateTime.Now
                };
                db.Carts.Add(cartItem);
            }
            else
            {

                cartItem.Quantity++;
            }
            db.SaveChanges();
            
        }
        public int GetCart(string userId)
        {
            return db.Carts.Where(x => x.UserId == userId && x.CheckOut == false).Count();
        }
        public int RemoveFromCart(int id,string username)
        {

            var cartItem = db.Carts.Single(
                cart => cart.UserId == username
                && cart.CartId == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    cartItem.CheckOut = true;
                    db.Entry(cartItem).State = EntityState.Modified;
                    //db.Carts.Remove(cartItem);
                }

                db.SaveChanges();
            }
            return itemCount;
        }
        public void deleteFromCart(int id)
        {
            var order = db.Carts.Find(id);
            order.CheckOut = true;
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
        }
       
        public void EmptyCart( string username)
        {
            var cartItems = db.Carts.Where(
                cart => cart.UserId == username);

            foreach (var cartItem in cartItems)
            {
                cartItem.CheckOut = true;
                db.Entry(cartItem).State = EntityState.Modified;
                //db.Carts.Remove(cartItem);
            }

            db.SaveChanges();
        }
        public int UpdateCartCount(int id,int cartCount)
        {
            int itemCount = 0;
            var cartItems = db.Carts.Where(cart => cart.CartId == id).FirstOrDefault();
            cartItems.Quantity = cartCount;
            cartCount = cartItems.Quantity;
            db.Entry(cartItems).State = EntityState.Modified;
            db.SaveChanges();
            return itemCount;
        }
        public void updateCounter(CartModify cartModify)
        {
            
            var cartItems = db.Carts.Where(cart => cart.CartId == cartModify.Id).FirstOrDefault();
            cartItems.Quantity = cartModify.Count;
            
            db.Entry(cartItems).State = EntityState.Modified;
            db.SaveChanges();
          
        }
        public int GetCount(string username)
        {

            int? count = (from cartItems in db.Carts
                          where cartItems.UserId == username
                          select (int?)cartItems.Quantity).Sum();

            return count ?? 0;
        }

        public int CreateOrder(string username)
        {
            decimal orderTotal = 0;
            Data.Order orderz = new Data.Order();
            var cartItems =db.Carts.Where(v=>v.UserId== username).ToList();
            if (cartItems != null)
            {
                
                orderz.OrderDate = DateTime.Now;
                orderz.approval = "Waiting For Approval";
                orderz.TotalCost = 0;
                db.orders.Add(orderz);
                db.SaveChanges();
                foreach (var item in cartItems)
                {
                    item.orderId = orderz.OrderId;
                    item.CheckOut = true;
                    db.Entry(item).State = EntityState.Modified;
                    // db.workSchedules.Remove(wrks);
                    db.SaveChanges();

                    
                    orderTotal += (item.Quantity * item.Item.Price);
                }
                orderz.TotalCost = orderTotal;
                db.Entry(orderz).State = EntityState.Modified;
                db.SaveChanges();
            }
            

            return orderz.OrderId;
        }
    }
}

