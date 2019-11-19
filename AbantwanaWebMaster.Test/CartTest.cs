using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AbantwanaWebMaster.Service;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebTest
{
    [TestClass]
    public class CartTest
    {

        [TestMethod]
        public void insertTest()
        {
            try
            {
                DataContext db = new DataContext();
                // IParentRepository studentRepository = new IParentRepository();
                Cart cart = new Cart()
                {
                    CartId = 0,
                    UserId = "",
                   ItemId = 0,
                    Quantity = 2,
                    DateCreated=DateTime.Now,
                    CheckOut= true
                };
                db.Carts.Add(cart);
                //Assert.AreNotEqual(0, student.parentId);
            }
            catch
            {

            }




        }
    }
}
