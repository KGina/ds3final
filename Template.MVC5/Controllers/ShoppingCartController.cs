
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class ShoppingCartController : Controller
    {
        CartBusiness CartBusiness = new CartBusiness();
        //[AuthorizeRoles]
        //[Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var cart = CartBusiness.GetCart(User.Identity.Name);


            var viewModel = new ShoppingCartViewModel
            {
                CartItems = CartBusiness.GetCartItems(User.Identity.Name),
                CartTotal = CartBusiness.GetTotal(User.Identity.Name)
            };

            return View(viewModel);
        }



        //AddToCart
        public ActionResult AddToCart(int id)
        {

            CartBusiness.AddToCart(id, User.Identity.Name);
            //cart.AddToCart(addedItem, User.Identity.Name);


            return RedirectToAction("Index");
        }


        [HttpPost]
        public ActionResult UpdateCartCount(int id, int cartCount)
        {
            ShoppingCartRemoveViewModel results = null;
            try
            {
                // Get the cart 

                // Get the name of the album to display confirmation 
                string ItemName = CartBusiness.ItemName(id);

                // Update the cart count 
                int itemCount = CartBusiness.UpdateCartCount(id, cartCount);

                //Prepare messages
                string msg = "The quantity of " + Server.HtmlEncode(ItemName) +
                        " has been refreshed in your shopping cart.";
                if (itemCount == 0) msg = Server.HtmlEncode(ItemName) +
                        " has been removed from your shopping cart.";
                //
                // Display the confirmation message 
                results = new ShoppingCartRemoveViewModel
                {
                    Message = msg,
                    CartTotal = CartBusiness.GetTotal(User.Identity.Name),
                    CartCount = CartBusiness.GetCount(User.Identity.Name),
                    ItemCount = itemCount,
                    DeleteId = id
                };
            }
            catch
            {
                results = new ShoppingCartRemoveViewModel
                {
                    Message = "Error occurred or invalid input...",
                    CartTotal = -1,
                    CartCount = -1,
                    ItemCount = -1,
                    DeleteId = id
                };
            }
            return Json(results);
        }

        public JsonResult updateCounter(CartModify modify)
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            bool st = false;
           
            if (ModelState.IsValid)
            {
                if (modify != null)
                {
                    CartBusiness.updateCounter(modify);
                    st = true;
                }
               
               
            }

            return new JsonResult { Data=new { status=st}, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        //Remove From Cart
        public ActionResult RemoveFromCart(int id)
        {

            CartBusiness.deleteFromCart(id);
            return RedirectToAction("Index");
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
           
            var cart =CartBusiness.GetCart(User.Identity.Name);

            ViewData["CartCount"] = cart   ;
            return PartialView("CartSummary");
        }


        //Edit Cart
        // GET: Producers/Edit/5
       
        //public ActionResult RemoveFromCart(int id)
        //{

        //    var cart = ShoppingCart.GetCart(this.HttpContext);


        //    string itemName = storeDB.Carts
        //        .Single(item => item.RecordId == id).Item.Title;


        //    int itemCount = cart.RemoveFromCart(id);


        //    var results = new ShoppingCartRemoveViewModel
        //    {
        //        Message = Server.HtmlEncode(itemName) +
        //            " has been removed from your shopping cart.",
        //        CartTotal = cart.GetTotal(),
        //        CartCount = cart.GetCount(),
        //        ItemCount = itemCount,
        //        DeleteId = id
        //    };
        //    return Json(results);




        //    ApplicationDbContext db = new ApplicationDbContext();

        //    Cart order = db.Carts.Find(id);
        //    db.Carts.Remove(order);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}



    }
}