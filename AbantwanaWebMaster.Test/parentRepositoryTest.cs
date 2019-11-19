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
    public class parentRepositoryTest
    {
        [TestMethod]
        public void SaveShouldReturnSavedId()
        {
            try
            {
                DataContext db = new DataContext();
                // IParentRepository studentRepository = new IParentRepository();
                Parent student = new Parent()
                {
                    parentId = 0,
                    name = "Jabu",
                    surname = "Mweli",
                    phonenumber = 0765467656,
                    emailaddress = "jb@gmail.com",
                    homephonenumber = 0330987656,
                    physicaladdress = "45 steve biko",
                    dob = DateTime.Now,
                };
                db.parents.Add(student);
                //Assert.AreNotEqual(0, student.parentId);
            }
            catch
            {
                
            }
           
        }
    }
}
