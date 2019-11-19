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
    public class saveSupplier
    {
        [TestMethod]
        public void insertTest()
        {
            try
            {
                DataContext db = new DataContext();
                // IParentRepository studentRepository = new IParentRepository();
                Supplier student = new Supplier()
                {
                    SupplierId = 0,
                    name = "Jabu",
                    
                    phonenumber = 0765467656,
                    email = "jb@gmail.com",
                    
                    physicaladdress = "45 steve biko",
                    //dob = DateTime.Now,
                };
                db.Suppliers.Add(student);
                //Assert.AreNotEqual(0, student.parentId);
            }
            catch
            {

            }

        }
    }
}
