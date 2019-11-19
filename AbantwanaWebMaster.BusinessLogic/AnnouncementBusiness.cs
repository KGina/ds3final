using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.Service;
using AbantwanaWebMaster.Data;
using System.Data.Entity;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class AnnouncementBusiness
    {
        DataContext db = new DataContext();
        public List<Model.Announcement> GetAnnouncements()
        {

            using (var announcementRep = new AnnouncementRepository())
            {
                return announcementRep.GetAll().Select(x => new Model.Announcement() { announcementid=x.announcementid, reciever =x.reciever,datecreateddisplay=x.datecreated.ToShortDateString(),expiredisplay=x.expirydate.ToShortDateString(),sender=x.sender,datecreated =x.datecreated, expirydate=x.expirydate, title=x.title, message= x.message}).ToList();
            }
        }
        public List<Model.Announcement> GetAnnouncements(string user)
        {
            var pId = db.parents.Where(k => k.emailaddress == user).Select(k => k.parentId).FirstOrDefault();
            var aa = db.ParentAnnouncements.Where(f => f.ReceiverId == pId).ToList();
            List<Model.Announcement> lkl = new List<Model.Announcement>();

            using (var announcementRep = new AnnouncementRepository())
            {
                foreach (var itemx in aa)
                {

                    itemx.Status = true;
                    db.Entry(itemx).State= EntityState.Modified;
                    db.SaveChanges();

                    lkl.Add(announcementRep.GetAll().Where(k=>k.announcementid==itemx.ParentAnnouncementId).Select(x => new Model.Announcement() { announcementid = x.announcementid, reciever = x.reciever, datecreated = x.datecreated, expirydate = x.expirydate,expiredisplay=x.expirydate.ToShortDateString(),datecreateddisplay=x.datecreated.ToShortDateString(),sender=x.sender,title = x.title, message = x.message }).FirstOrDefault());
                }
            }
            return lkl;
        }

        public void InsertAnnouncements(Model.Announcement ann,string user)
        {

            using (var AnnouncementRepo = new AnnouncementRepository())
            {
                if (ann != null)
                {
                    var receiver = "";
                    if (ann.learnerId!=0)
                    {
                        receiver = db.learnerProfiles.Where(d => d.learnerId == ann.learnerId).Select(l=>l.lname).FirstOrDefault();
                    }
                    if (ann.classroomId!=0)
                    {
                        receiver = db.classRooms.Where(d => d.classRoomId == ann.classroomId).Select(l=>l.className).FirstOrDefault();
                    }
                    var announcem = new Data.Announcement { announcementid = ann.announcementid, title = ann.title, datecreated = DateTime.Now.Date, message = ann.message, expirydate = ann.expirydate, reciever = receiver, sender=user };
                    AnnouncementRepo.Insert(announcem);

                }
            }

        }
        public void newParentAnnouce(int learnerId)
        {
            EmailService service = new EmailService();
            var stdName = db.learnerProfiles.Where(k => k.learnerId == learnerId).Select(n => n.lname).FirstOrDefault();
            var annID = db.announcements.Where(x => x.reciever == stdName).Select(v => v.announcementid).Max();
            if (annID != 0)
            {
              var  annonce = db.announcements.Where(x => x.announcementid==annID).Select(x=>new { x.title,x.message,x.announcementid,x.sender}).FirstOrDefault();
                var parents = db.ParentLearners.Where(x => x.learnerId == learnerId).Select(x=> x.parentid).ToList();


                foreach (var item in parents)
                {
                    var parentEmail = db.parents.Where(x => x.parentId == item).Select(x => x.emailaddress).FirstOrDefault();
                    
                    using (var parentAnnRepo = new ParentAnnouncementRepository())
                    {
                        var parentAa = new Data.ParentAnnouncement { ParentAnnouncementId = annonce.announcementid, ReceiverId = item };

                        parentAnnRepo.Insert(parentAa);
                    }
                    service.CaptureEmail(parentEmail,annonce.title,annonce.message+"\n Sent by : "+annonce.sender);
                }
            }
           

            //return learnerProfilesList;
        }
        public int counter(string username)
        {
           if(username!=" ")
            {
                var pId = db.parents.Where(x => x.emailaddress == username).Select(x => x.parentId).FirstOrDefault();
            using (var announceRep = new ParentAnnouncementRepository())
            {
                return announceRep.GetAll().Where(n=>n.ReceiverId==pId&&n.Status==false).Count();
            }

          }

            return 0;
        }
        public int getStaff(string user)
        {
           
            //Finds event by ID which should be deleted
            var wrks = db.staffMembers.Where(a => a.email == user).Select(k=>k.staffMemberId).FirstOrDefault();

           
            return (wrks);
        }
        public void addAnnouncements(Model.Announcement announcement,string username)
        {

            using (var announcementRep = new AnnouncementRepository())
            {
                
                var addAnn =new Data.Announcement { announcementid=announcement.announcementid,sender=username, reciever =announcement.reciever,datecreated =DateTime.Now.Date, expirydate=announcement.expirydate, title=announcement.title, message= announcement.message};
                announcementRep.Insert(addAnn);
            }
        }


        public List<Model.Announcement> AnnouncementList()
        {

            using (var announcementRep = new AnnouncementRepository())
            {
                return announcementRep.GetAll().Select(x => new Model.Announcement() { announcementid = x.announcementid,datecreateddisplay= x.datecreated.ToShortDateString(),expiredisplay=x.expirydate.ToShortDateString(), reciever = x.reciever, datecreated = x.datecreated, expirydate = x.expirydate, title = x.title, message = x.message }).ToList();
            }
        }



        public void CreateByGrade(Model.Announcement announcement, string user)
        {

            List<Model.LearnerProfileView> learnerProfilesList2 = new List<Model.LearnerProfileView>();
            var learners = db.yearLearnerClassRooms.Where(x => x.classRoomId == announcement.classroomId).ToList();
            List<int> ParentList = new List<int>();
            foreach (var item in learners)
            {
                if (!ParentList.Contains(db.ParentLearners.Where(n => n.learnerId == item.learnerId).Select(m => m.parentid).FirstOrDefault()))
                {
                    ParentList.Add(db.ParentLearners.Where(n => n.learnerId == item.learnerId).Select(m => m.parentid).FirstOrDefault());
                }
            }
            announcement.learnerId = announcement.classroomId;
            InsertAnnouncements(announcement, user);
            var annID = db.announcements.Where(x => x.reciever == announcement.classroomId.ToString()).Select(v => v.announcementid).FirstOrDefault();
            if (annID != 0)
            {
                annID = db.announcements.Where(x => x.reciever == announcement.classroomId.ToString()).Select(v => v.announcementid).Max();
                //var parents = db.ParentLearners.Where(x => x.learnerId == learnerId).Select(x => x.parentid).ToList();


                foreach (var item in ParentList)
                {
                    using (var parentAnnRepo = new ParentAnnouncementRepository())
                    {
                        var parentAa = new Data.ParentAnnouncement { ParentAnnouncementId = annID, ReceiverId = item };

                        parentAnnRepo.Insert(parentAa);
                    }
                }
            }
           


        }
    }
}
