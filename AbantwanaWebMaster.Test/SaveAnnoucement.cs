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

    public class SaveAnnoucement
    {
        [TestMethod]
        public void insertTest()
        {
            try
            {
                DataContext db = new DataContext();
                // IParentRepository studentRepository = new IParentRepository();
                Announcement announcement = new Announcement()
                {
                    announcementid = 0,
                    title = "Parents Meeting",
                    datecreated = DateTime.Now,
                    message = "There will be a meeting held at ....",
                    expirydate = DateTime.Now,
                    reciever = "Helen",
                    sender = "Admin",
                    // phonenumber = 0765467656,
                    // email = "jb@gmail.com",

                    // physicaladdress = "45 steve biko",
                    //dob = DateTime.Now,
                };
                db.announcements.Add(announcement);
                //Assert.AreNotEqual(0, student.parentId);
            }
            catch
            {



            }
        }
    }
}
