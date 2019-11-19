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

namespace AbantwanaWebMaster.BusinessLogic
{
    public class CategoryBusiness
    { DataContext db = new DataContext();
        public UserManager<AbantwanaWebMaster.Data.ApplicationUser> UserManager { get; set; }

        public CategoryBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));
        }

        //GetAllCart
        public List<Model.Cart> GetAllCart()
        {
            using (var categoryrepo = new CartRepository())
            {
                return categoryrepo.GetAll().Select(x => new Model.Cart()
                {
                    CartId = x.CartId,
                    UserId = x.UserId,
                    ItemId = x.ItemId,

                }).ToList();
            }
        }
        public Model.Category Browse(string category)
        {
             var categoryModel = db.Categories.Include("Items")
                .Single(c => c.Name == category);

            var ct = new Model.Category();
            ct.CategoryId = categoryModel.CategoryId;
            ct.Description = categoryModel.Description;
            //ct.Items
            List<Model.Item> sho = new List<Model.Item>();
            foreach(var itm in categoryModel.Items.Where(p=>p.archive==false))
            {
                if (itm.archive==false) {
                    Model.Item it = new Model.Item();
                    it.ItemId = itm.ItemId;
                    // it.SupplierId = itm.SupplierId;
                    it.CategoryId = itm.CategoryId;
                    it.catergoryName = itm.Category.Name;
                    it.ItemDesciption = itm.ItemDesciption;
                    it.ItemName = itm.ItemName;
                    it.Picture = itm.Picture;
                    it.Price = itm.Price;
                    //it.supplierName = itm.Supplier.name;
                    sho.Add(it);
                }

            }
            ct.Items = sho;
           

            return ct;
            
        }

        public List<Model.Category> GetAllCategorys()
        {
            using (var categoryrepo = new CategoryRepository())
            {
                return categoryrepo.GetAll().Select(x => new Model.Category()
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Description = x.Description,

                }).ToList();
            }
        }
        public Model.Item Find(int id)
        {
            using (var categoryrepo = new ItemRepository())
            {
                return categoryrepo.GetAll().Where(k=>k.ItemId==id).Select(x => new Model.Item()
                {
                    ItemId = x.ItemId,
                    CategoryId = x.CategoryId,
                    Price=x.Price,
                    ItemName=x.ItemName,
                    //SupplierId = x.SupplierId,
                    ItemDesciption=x.ItemDesciption,
                    catergoryName=x.Category.Name,
                   // supplierName=x.Supplier.name,
                    Picture=x.Picture

                }).FirstOrDefault();
            }
        }
        public List<Model.ItemVm> browserList()
        {
            List<ItemVm> ItemVMlist = new List<ItemVm>();
            var customerlist = (from It in db.items

                                join Ord in db.Categories on It.ItemId equals Ord.CategoryId
                                select new { It.Picture, It.Price, It.ItemName, It.ItemDesciption, Ord.Description }).ToList();

            foreach (var item in customerlist)

            {

                ItemVm objcvm = new ItemVm(); // ViewModel

                objcvm.Picture = item.Picture;

                objcvm.Price = item.Price;

                objcvm.Title = item.ItemName;

                objcvm.ItemDesciption = item.ItemDesciption;

                objcvm.Description = item.Description;

                ItemVMlist.Add(objcvm);

            }
            return ItemVMlist;
        }

        public void AddCategory(Model.Category objPV)
        {
            using (var categoryrepo = new CategoryRepository())
            {
                var category = new Data.Category
                {
                    CategoryId = objPV.CategoryId,
                    Name = objPV.Name,
                    Description = objPV.Description,

                    //User = newuser
                };
                categoryrepo.Insert(category);
            }
            
        }

       
    }
}
