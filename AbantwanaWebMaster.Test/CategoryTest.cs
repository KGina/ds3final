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
    public class CategoryTest
    {
        [TestMethod]
        public void insertTest()
        {
            try
            {
                DataContext db = new DataContext();
                // IParentRepository studentRepository = new IParentRepository();
                Category category = new Category()
                {

                    CategoryId = 0,
                    Name = "food",
                    Description = "edible product"




                    // phonenumber = 0765467656,
                    // email = "jb@gmail.com",

                    // physicaladdress = "45 steve biko",
                    //dob = DateTime.Now,
                };
                db.Categories.Add(category);
                //Assert.AreNotEqual(0, student.parentId);
            }
            catch
            {




            }
        }
    }
}
