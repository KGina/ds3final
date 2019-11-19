using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.Service;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class staffRegBusiness
    {
        DataContext db = new DataContext();
        public List<Model.StaffMember> GetStaffMembers()
        {

            using (var staffRepo = new StaffMemberRepository())
            {
                return staffRepo.GetAll().Select(x => new Model.StaffMember() { staffMemberId = x.staffMemberId, UserPhoto=x.UserPhoto,StaffMemberName = x.StaffMemberName,phonenumber=x.phonenumber,StaffMemberSurname=x.StaffMemberSurname,email=x.email }).ToList();
            }
        }

        public void regStaffMembers(Model.StaffMember staff)
        {
           
            using (var staffRepo = new StaffMemberRepository())
            {
                if (staff != null)
                {
                    var stafReg = new Data.StaffMember { UserPhoto = staff.UserPhoto,staffMemberId = staff.staffMemberId, StaffMemberName = staff.StaffMemberName, StaffMemberSurname = staff.StaffMemberSurname, phonenumber = staff.phonenumber, email = staff.email };
                    staffRepo.Insert(stafReg);

                }
            }
       
        }

    }
}
