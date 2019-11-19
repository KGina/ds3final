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
    public class RegistrationBusiness
    {
        public UserManager<AbantwanaWebMaster.Data.ApplicationUser> UserManager { get; set; }
        DataContext db = new DataContext();
       
        public RegistrationBusiness()
        {
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new DataContext()));
        }

        public List<Model.ParentView> GetAllParents()
        {
            using (var parentrepo = new ParentRepository())
            {
                return parentrepo.GetAll().Select(x => new ParentView()
                {
                    parentid = x.parentId,
                    name = x.name,
                    surname = x.surname,
                    dob = x.dob,
                    phonenumber = x.phonenumber,
                    physicaladdress = x.physicaladdress,
                    emailaddress = x.emailaddress,
                    homephonenumber = x.homephonenumber,
                    IdDocument=x.IdDocument,
                   
                    proofofresidence=x.proofofresidence
                }).ToList();
            }
        }
        public int GetParentID()
        {
            using (var parentrepo = new ParentRepository())
            {
                var max= parentrepo.GetAll().Select(x =>  x.parentId).FirstOrDefault();
                if (max>0)
                {
                    return parentrepo.GetAll().Select(x => x.parentId).Max();
                }
                else
                {
                    return max;
                }
            }
        }
        public byte[] GetPDFProofOfRes(int id)
        {
            using (var parentrepo = new ParentRepository())
            {
                return parentrepo.GetAll().Where(x=>x.parentId==id).Select(x =>x.proofofresidence).FirstOrDefault();
            }
        }
        public byte[] GetPDFIdDoc(int id)
        {
            using (var parentrepo = new ParentRepository())
            {
                return parentrepo.GetAll().Where(x => x.parentId == id).Select(x => x.IdDocument).FirstOrDefault();
            }
        }
        public int findByEmail( string email)
        {
            return db.parents.Where(j => j.emailaddress == email).Count();
        }
        public void linkChild( string email,string userName)
        {
         var oldPid  =db.parents.Where(m => m.emailaddress == userName).Select(m => m.parentId).FirstOrDefault();
            var newPid = db.parents.Where(k => k.emailaddress == email).Select(k=>k.parentId).FirstOrDefault();
            if(oldPid!=0)
            {
                var li = db.ParentLearners.Where(k => k.parentid == oldPid).Select(l=>l.learnerId).ToList();
                foreach(var item in li)
                {
                    Data.ParentLearner kl = new ParentLearner();
                    kl.learnerId = item;
                    kl.parentid =newPid ;
                    db.ParentLearners.Add(kl);
                    db.SaveChanges();

                }
            }
        }
        public void AddParent(ParentView objPV)
        {
            using (var parentrepo = new ParentRepository())
            {
                var parent = new Parent
                {
                    parentId = objPV.parentid,
                    name = objPV.name,
                    surname = objPV.surname,
                    dob = objPV.dob,
                    phonenumber = objPV.phonenumber,
                    physicaladdress = objPV.physicaladdress,
                    emailaddress = objPV.emailaddress,
                    homephonenumber = objPV.homephonenumber,
                    IdDocument = objPV.IdDocument,
                    proofofresidence = objPV.proofofresidence,
                    

                    //User = newuser
                };
                parentrepo.Insert(parent);
            }
           



        }
    }
}