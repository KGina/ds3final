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
    public class StoreManagerBusiness
    {    DataContext db = new DataContext();
        public UserManager<AbantwanaWebMaster.Data.ApplicationUser> UserManager { get; set; }

        public StoreManagerBusiness()
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
        public List<Model.Category> GetAllCatergory()
        {
            using (var categoryrepo = new CategoryRepository())
            {
                return categoryrepo.GetAll().Select(x => new Model.Category()
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name
                }).ToList();
            }
        }

        public List<Model.Supplier> GetAllSuppliers()
        {
            using (var categoryrepo = new SupplierRepository())
            {
                return categoryrepo.GetAll().Select(x => new Model.Supplier()
                {
                    supplierID = x.SupplierId,
                    name = x.name
                }).ToList();
            }
        }
        public List<Model.Category> Browse(string category)
        {
            using (var categoryrepo = new CategoryRepository())
            {
                return categoryrepo.GetAll().Where(c=>c.Name==category).Select(x => new Model.Category()
                {
                    CategoryId = x.CategoryId,
                    Name = x.Name,
                    Description = x.Description
                    
                }).ToList();
            }
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
                    Picture=x.Picture

                }).FirstOrDefault();
            }
        }
        public bool deleteItem(int id)
        { 
            try
            {
                var itm = db.items.Where(i => i.ItemId == id).FirstOrDefault();
                itm.archive = true;
                db.Entry(itm).State = EntityState.Modified;
                //db.items.Remove(itm);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        public void addNewItem(Model.Item item)
        {
            using (var itemRepo = new ItemRepository())
            {
                var newItem= new Data.Item()
                {
                    ItemId = item.CategoryId,
                    CategoryId = item.CategoryId,
                    Price = item.Price,
                    ItemName = item.ItemName,
                   // SupplierId = item.SupplierId,
                    ItemDesciption = item.ItemDesciption,
                    Picture = item.Picture
                };
                itemRepo.Insert(newItem);
            }
        }
        public List<Model.Item> itemList()
        {
            using (var categoryrepo = new ItemRepository())
            {
                return categoryrepo.GetAll().Where(x=>x.archive==false).Select(x => new Model.Item()
                {
                    ItemId = x.CategoryId,
                    CategoryId = x.CategoryId,
                    Price = x.Price,
                    ItemName = x.ItemName,
                    //SupplierId = x.SupplierId,
                    ItemDesciption = x.ItemDesciption,
                    Picture = x.Picture,
                   // supplierName=x.Supplier.name,
                    catergoryName=x.Category.Name

                }).ToList();
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

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        
    }
}
