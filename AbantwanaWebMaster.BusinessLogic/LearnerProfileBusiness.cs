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
using System.Net.Mail;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class LearnerProfileBusiness
    {
        public UserManager<AbantwanaWebMaster.Data.ApplicationUser> UserManager { get; set; }
        
        public LearnerProfileBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));
        }
        DataContext db = new DataContext();

        public List<int> GetAllLearnerWithGrade(int termid, int gradeId, int yearId)
        {
            var l = db.Assessments.Where(o => o.termId == termid && o.gradeId == gradeId && o.yearId == yearId).Select(p=>p.assessmentId).FirstOrDefault();
            var k = db.yearLearnerGradeSubjectAssessments.Where(o => o.assessmentId == l).Select(i => i.learnerId).ToList();
            return k;
        }
        public List<LearnerProfileView> GetAllLearnerWithGrade2(int termid, int gradeId, int yearId)
        {
            var l1 = db.Assessments.Where(o => o.termId == termid && o.gradeId == gradeId && o.yearId == yearId).Select(p => p.assessmentId).FirstOrDefault();
            var k = db.yearLearnerGradeSubjectAssessments.Where(o => o.assessmentId == l1).Select(i => i.learnerId).ToList();

            List<int> learnId = new List<int>();
            List<LearnerProfileView> learnPor = new List<LearnerProfileView>();
            foreach (var hi in k)
            {
                learnId.Add(db.yearLearnerClassRooms.Where(p => p.classRoomId == hi && p.yearId == yearId).Select(o => o.learnerId).FirstOrDefault());
            }
            using (var learnrepo = new LearnerProfileRepository())
            {
                var termL = db.terms.ToList();
                List<Model.Term> terms = new List<Model.Term>();
                foreach (var it in termL)
                {
                    Model.Term kl = new Model.Term();
                    kl.termId = it.termId;
                    kl.name = it.name;
                    terms.Add(kl);

                }


                foreach (var hi in learnId)
                {
                    learnPor.Add(
                learnrepo.GetAll().Where(l => l.status == "Approved" && l.learnerId == hi).Select(x => new LearnerProfileView()
                {
                    learnerId = x.learnerId,
                    Picture = x.Picture,
                    lname = x.lname,
                    lsurname = x.lsurname,
                    lidnumber = x.lidnumber,
                    dateofbith = x.dateofbith,
                    grade = x.grade,
                    medicaldetails = x.medicaldetails,
                    medicalCertificate = x.medicalCertificate,
                    BirthCertificate = x.BirthCertificate,
                    status = x.status,
                    archive = x.archive,
                    terms = terms
                }).FirstOrDefault());
                    //learnId.Add(db.yearLearnerClassRooms.Where(p => p.classRoomId == hi && p.yearId == yearId).Select(o => o.learnerId).FirstOrDefault());
                }
            }
            return learnPor;
        }


        public List<Model.LearnerProfileView> GetAllLearnerWithTerms(int gradeId, int yearId)
        {
            var classId = db.classRooms.Where(p => p.graddId == gradeId).Select(o => o.classRoomId).ToList();
            List<int> learnId = new List<int>();
            List<LearnerProfileView> learnPor = new List<LearnerProfileView>();
            foreach (var hi in classId)
            {
                learnId.Add(db.yearLearnerClassRooms.Where(p => p.classRoomId == hi && p.yearId == yearId).Select(o => o.learnerId).FirstOrDefault());
            }
            using (var learnrepo = new LearnerProfileRepository())
            {
                var termL = db.terms.ToList();
                List<Model.Term> terms = new List<Model.Term>();
                foreach (var it in termL)
                {
                    Model.Term kl = new Model.Term();
                    kl.termId = it.termId;
                    kl.name = it.name;
                    terms.Add(kl);

                }

            
            foreach (var hi in learnId)
            {
                    learnPor.Add(
                learnrepo.GetAll().Where(l => l.status == "Approved"&&l.learnerId==hi).Select(x => new LearnerProfileView()
                {
                    learnerId = x.learnerId,
                    Picture = x.Picture,
                    lname = x.lname,
                    lsurname = x.lsurname,
                    lidnumber = x.lidnumber,
                    dateofbith = x.dateofbith,
                    grade = x.grade,
                    medicaldetails = x.medicaldetails,
                    medicalCertificate = x.medicalCertificate,
                    BirthCertificate = x.BirthCertificate,
                    status = x.status,
                    archive = x.archive,
                    terms = terms
                }).FirstOrDefault());
                //learnId.Add(db.yearLearnerClassRooms.Where(p => p.classRoomId == hi && p.yearId == yearId).Select(o => o.learnerId).FirstOrDefault());
            }
        }

            return learnPor;
        }
            public List<Model.LearnerProfileView> GetAllLearners(int? id)
        {
            if (id==0) {
                using (var learnrepo = new LearnerProfileRepository())
                {
                    return learnrepo.GetAll().Where(l=>l.status== "Approved").Select(x => new LearnerProfileView()
                    {
                        learnerId = x.learnerId,
                        Picture = x.Picture,
                        lname = x.lname,
                        lsurname = x.lsurname,
                        lidnumber = x.lidnumber,
                        dateofbith = x.dateofbith,
                        grade = x.grade,
                        medicaldetails = x.medicaldetails,
                        medicalCertificate = x.medicalCertificate,
                        BirthCertificate = x.BirthCertificate,
                        status = x.status,
                        archive = x.archive
                    }).ToList();
                }
            }
            else
            {
                using (var learnrepo = new LearnerProfileRepository())
                {
                    var ls = db.ParentLearners.Where(k=>k.parentid==id).ToList();
                    List<LearnerProfileView> lList = new List<LearnerProfileView>();
                    foreach (var it in ls)
                    {
                        lList.Add(learnrepo.GetAll().Where(k => k.learnerId==it.learnerId).Select(x => new LearnerProfileView()
                        {
                            learnerId = x.learnerId,
                            Picture = x.Picture,
                            lname = x.lname,
                            lsurname = x.lsurname,
                            lidnumber = x.lidnumber,
                            dateofbith = x.dateofbith,
                            grade = x.grade,
                            medicaldetails = x.medicaldetails,
                            medicalCertificate = x.medicalCertificate,
                            BirthCertificate = x.BirthCertificate,
                            status = x.status,
                            archive = x.archive
                        }).FirstOrDefault());
                    }
                    return lList;
                }
            }
        }
        public List<Model.LearnerProfileView> GetAllRejectedLearners()
        {
           
                using (var learnrepo = new LearnerProfileRepository())
                {
                    return learnrepo.GetAll().Where(l => l.status == "Rejected").Select(x => new LearnerProfileView()
                    {
                        learnerId = x.learnerId,
                        Picture = x.Picture,
                        lname = x.lname,
                        lsurname = x.lsurname,
                        lidnumber = x.lidnumber,
                        dateofbith = x.dateofbith,
                        grade = x.grade,
                        medicaldetails = x.medicaldetails,
                        medicalCertificate = x.medicalCertificate,
                        BirthCertificate = x.BirthCertificate,
                        status = x.status,
                        archive = x.archive
                    }).ToList();
                }
            //}
            
        }

        public List<Model.LearnerProfileView> GetAllL(int? id,int yearId)
        {
            using (var learnrepo = new LearnerProfileRepository())
            {
                var ls = db.yearLearnerClassRooms.Where(k => k.classRoomId == id&&k.yearId==yearId).Select(l => l.learnerId).ToList();
                List<LearnerProfileView> llist = new List<LearnerProfileView>();
                foreach (var it in ls)
                {
                    llist.Add(learnrepo.GetAll().Where(k => k.learnerId == it).Select(x => new LearnerProfileView()
                    {
                        learnerId = x.learnerId,
                        lname = x.lname,
                    }).FirstOrDefault());
                }
                return llist;
            }
        }
        
        public List<Model.LearnerProfileView> GetAllLean()
        {
                using (var learnrepo = new LearnerProfileRepository())
                {
                    var ls = db.learnerProfiles.ToList();
                    List<LearnerProfileView> lList = new List<LearnerProfileView>();
                    foreach (var it in ls)
                    {
                        lList.Add(learnrepo.GetAll().Select(x => new LearnerProfileView()
                        {
                            learnerId = x.learnerId,
                            lname = x.lname,
                           // learnerId = x.learnerId,
                            Picture = x.Picture,
                           // lname = x.lname,
                            lsurname = x.lsurname,
                            lidnumber = x.lidnumber,
                            dateofbith = x.dateofbith,
                            grade = x.grade,
                            medicaldetails = x.medicaldetails,
                            medicalCertificate = x.medicalCertificate,
                            BirthCertificate = x.BirthCertificate,
                            status = x.status,
                            archive = x.archive
                        }).FirstOrDefault());
                    }
                    return lList;
            }
        }public string GetLearnerName(int id)
        {
            var n = db.learnerProfiles.Where(p => p.learnerId == id).Select(l => l.lname).FirstOrDefault();
            return n;
        }
        public string GetLearnerSurName(int id)
        {
            var n = db.learnerProfiles.Where(p => p.learnerId == id).Select(l => l.lsurname).FirstOrDefault();
            return n;
        }

        public List<Model.LearnerProfileView> GetAllLearnersForp(string username)
        {
            var id = db.parents.Where(l => l.emailaddress == username).Select(j => j.parentId).FirstOrDefault();
           
                using (var learnrepo = new LearnerProfileRepository())
                {
                    var ls = db.ParentLearners.Where(k=>k.parentid==id).ToList();
                    List<LearnerProfileView> lList = new List<LearnerProfileView>();
                    foreach (var it in ls)
                    {
                        lList.Add(learnrepo.GetAll().Where(k => k.learnerId==it.learnerId).Select(x => new LearnerProfileView()
                        {
                            learnerId = x.learnerId,
                            Picture = x.Picture,
                            lname = x.lname,
                            lsurname = x.lsurname,
                            lidnumber = x.lidnumber,
                            dateofbith = x.dateofbith,
                            grade = x.grade,
                            medicaldetails = x.medicaldetails,
                            medicalCertificate = x.medicalCertificate,
                            BirthCertificate = x.BirthCertificate,
                            status = x.status,
                             archive = x.archive
                        }).FirstOrDefault());
                    }
                    return lList;
                
            }
        }
        public List<Model.ClassRoom> GetLearnerProfileByClassroom()
        {

            using (var announcementRep = new ClassroomRepository())
            {
                return announcementRep.GetAll().Select(x => new Model.ClassRoom() { classRoomId= x.classRoomId, graddId = x.graddId,className=x.className,staffId=x.staffId, gradename=Getgradename(x.graddId) }).ToList();
            }
        }
        public string Getgradename(int id)
        {
            var gr = db.grades.Where(k => k.gradeId == id).Select(i => i.gradeName).FirstOrDefault();
            return gr;
        }
        public void sendReport(Stream pdf,string filename,int id )
        {
            var pid = db.ParentLearners.Where(l => l.learnerId == id).Select(k => k.parentid).ToList();
            foreach (var yu in pid)
            {
                try{ 
                MailMessage msg = new MailMessage();

                var em = db.parents.Where(k => k.parentId == yu).Select(l => l.emailaddress).FirstOrDefault();
                //string fileName = Path.GetFileName(fileUploader.FileName);

                msg.Attachments.Add(new Attachment(pdf, filename));

                //}
                msg.From = new MailAddress("abantwanaweb@gmail.com");
                msg.To.Add(new MailAddress(em));
                msg.Subject = "End Of Term Report";
                msg.Body = "Please Find Attached Term Report.";
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("abantwanaweb@gmail.com", "#Account{2019}");
                smtpClient.Credentials = credentials;
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
            }
                catch { }
            }
           
        }
        public List<Model.LearnerProfileView> GetLearnerProfileByGrade(int? classroomid)
        {
            if (classroomid == 0) {
                using (var learnrepo = new LearnerProfileRepository())
                {
                    return learnrepo.GetAll().Select(x => new LearnerProfileView()
                    {
                        learnerId = x.learnerId,
                        Picture = x.Picture,
                        lname = x.lname,
                        lsurname = x.lsurname,
                        lidnumber = x.lidnumber,
                        dateofbith = x.dateofbith,
                        grade = x.grade,
                        medicaldetails = x.medicaldetails,
                        medicalCertificate = x.medicalCertificate,
                        BirthCertificate = x.BirthCertificate,
                        status = x.status,
                        archive = x.archive
                    }).ToList();
                }
            }
            else
            {
                using (var learnrepo = new LearnerProfileRepository())
                {
                    var ls = db.ParentLearners.Where(k=>k.parentid== classroomid).ToList();
                    List<LearnerProfileView> lList = new List<LearnerProfileView>();
                    foreach (var it in ls)
                    {
                        lList.Add(learnrepo.GetAll().Where(k => k.learnerId==it.learnerId).Select(x => new LearnerProfileView()
                        {
                            learnerId = x.learnerId,
                            Picture = x.Picture,
                            lname = x.lname,
                            lsurname = x.lsurname,
                            lidnumber = x.lidnumber,
                            dateofbith = x.dateofbith,
                            grade = x.grade,
                            medicaldetails = x.medicaldetails,
                            medicalCertificate = x.medicalCertificate,
                            BirthCertificate = x.BirthCertificate,
                            status = x.status,
                            archive = x.archive
                        }).FirstOrDefault());
                    }
                    return lList;
                }
            }
        }
        public byte[] getPic(int id)
        {
            return (db.learnerProfiles.Where(k=>k.learnerId==id).Select(k=>k.Picture).FirstOrDefault());
        }




        public string  emailapproval (int id)
        {
            var pID = db.ParentLearners.Where(x => x.learnerId == id).Select(k => k.parentid).FirstOrDefault();
            var learnerApp = db.learnerProfiles.Where(k => k.learnerId == id).FirstOrDefault();
            learnerApp.status = "Approved";
            db.Entry(learnerApp).State = EntityState.Modified;
            db.SaveChanges();
           
            // ClassRoom Allocation

            //var cID = db.classRooms.Where(k => k.grade.g==learnerApp.grade).Select(k=>k.classRoomId).FirstOrDefault();
            //YearLearnerClassRoom roomLearner = new YearLearnerClassRoom();
            //roomLearner.classRoomId = cID;
            //roomLearner.learnerId = learnerApp.learnerId;
            //roomLearner.dateCreated = DateTime.Now;
            //db.classRoomLearner.Add(roomLearner);
            db.SaveChanges();
            //Create  Account
            var email = db.parents.Where(k => k.parentId == pID).Select(k => k.emailaddress).FirstOrDefault();

            return email;
        }
        public string  emailRejected (int id)
        {
            var pID = db.ParentLearners.Where(x => x.learnerId == id).Select(k => k.parentid).FirstOrDefault();
            var learnerApp = db.learnerProfiles.Where(k => k.learnerId == id).FirstOrDefault();
            learnerApp.status = "Rejected";
            db.Entry(learnerApp).State = EntityState.Modified;
            db.SaveChanges();
            //Create  Account
            var email = db.parents.Where(k => k.parentId == pID).Select(k => k.emailaddress).FirstOrDefault();

            return email;
        }
        public void arch(int id)
        {
            var pID = db.ParentLearners.Where(x => x.learnerId == id).Select(k => k.parentid).FirstOrDefault();
            var learnerApp = db.learnerProfiles.Where(k => k.learnerId == id).FirstOrDefault();
            learnerApp.archive = true;
            db.Entry(learnerApp).State = EntityState.Modified;
            db.SaveChanges();
            
        }
        public void Restore(int id)
        {
            var pID = db.ParentLearners.Where(x => x.learnerId == id).Select(k => k.parentid).FirstOrDefault();
            var learnerApp = db.learnerProfiles.Where(k => k.learnerId == id).FirstOrDefault();
            learnerApp.archive = false;
            db.Entry(learnerApp).State = EntityState.Modified;
            db.SaveChanges();
            
        }
        public string  emailCallBack (int id)
        {
            var pID = db.ParentLearners.Where(x => x.learnerId == id).Select(k => k.parentid).FirstOrDefault();
            var learnerApp = db.learnerProfiles.Where(k => k.learnerId == id).FirstOrDefault();
            learnerApp.status = "Called For Interview";
            db.Entry(learnerApp).State = EntityState.Modified;
            db.SaveChanges();
            //Create  Account
            var email = db.parents.Where(k => k.parentId == pID).Select(k => k.emailaddress).FirstOrDefault();

            return email;
        }
        public string  learnerName (int id)
        {
            var name = db.learnerProfiles.Where(x => x.learnerId == id).Select(k => k.lname).FirstOrDefault();
            
            return name;
        }

        public byte[] OpenPDFMeDoc(int id)
        {
            using (var parentrepo = new LearnerProfileRepository())
            {
                return parentrepo.GetAll().Where(x => x.learnerId == id).Select(x => x.medicalCertificate).FirstOrDefault();
            }
        }
        public byte[] GetPDFIdDoc(int id)
        {
            using (var parentrepo = new LearnerProfileRepository())
            {
                return parentrepo.GetAll().Where(x => x.learnerId == id).Select(x => x.BirthCertificate).FirstOrDefault();
            }
        }
        public void AddLearner(LearnerProfileView obj)
        {
            using (var parentrepo = new LearnerProfileRepository())
            {
                var parent = new LearnerProfile
                {

                    learnerId = obj.learnerId,
                    Picture = obj.Picture,
                    lname = obj.lname,
                    lsurname = obj.lsurname,
                    lidnumber = obj.lidnumber,
                    dateofbith = obj.dateofbith,
                    grade = obj.grade,
                    medicaldetails = obj.medicaldetails,
                    medicalCertificate = obj.medicalCertificate,
                    BirthCertificate = obj.BirthCertificate,
                    status = "Waiting For Approval"
                    //User = newuser
                };
                parentrepo.Insert(parent);
                
            }
            var p = db.parents.Where(j => j.emailaddress == obj.parentEmail).Select(j => j.parentId).FirstOrDefault();
            var l = db.learnerProfiles.Select(j => j.learnerId).Max();
            using (var parentLeanerrepo = new ParentLearnerRepository())
            {
                var parentL = new ParentLearner
                {

                    parentid = p,
                    learnerId = l
                };
            parentLeanerrepo.Insert(parentL);
            }
            var lp = db.ParentLearners.Where(k => k.parentid == p).Select(o => o.learnerId).ToList();
            foreach(var iy in lp)
            {
                var pid = db.ParentLearners.Where(k => k.learnerId == iy).Select(ki=>ki.parentid).ToList();
                if (pid!=null)
                {
                    foreach(var iu in pid)
                    {
                        if (iu!=0)
                        {
                            using (var parentLeanerrepo = new ParentLearnerRepository())
                            {
                                var parentL = new ParentLearner
                                {

                                    parentid = iu,
                                    learnerId = l
                                };
                                parentLeanerrepo.Insert(parentL);
                            }
                        }

                    }
                    break;

                }
            }

        }
    }
}
