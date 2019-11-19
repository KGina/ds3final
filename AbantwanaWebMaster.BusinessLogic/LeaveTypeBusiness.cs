using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.Service;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class LeaveTypeBusiness
    {
        DataContext db = new DataContext();
        public List<Model.LeaveType>  getLeaveType()
        {

            using (var leaveRepo = new LeaveTypeRepository  ())
            {
                return leaveRepo.GetAll().Where(k=>k.archived==false).Select(x => new Model.LeaveType() {leaveTypeID=x.leaveTypeID, typeName=x.typeName }).ToList();
            }
        }
        public bool acrhiveType(int ReqID )
        {
            if (ReqID!=0)
            {
                var leavedate = db.leaveTypes.Where(k => k.leaveTypeID == ReqID).FirstOrDefault();
                leavedate.archived = true;
                db.Entry(leavedate).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public void createLeaveType(Model.LeaveType leave)
        {
            
            using (var leaveRepo = new LeaveTypeRepository())
            {
                if (leave != null)
                {
                    
                    var leaveCreate = new Data.LeaveType() { leaveTypeID=leave.leaveTypeID,typeName=leave.typeName};
                    leaveRepo.Insert(leaveCreate);
                }
            }
       
        }

        public void updateLeaveType(Model.LeaveType leave)
        {

            using (var leaveRepo = new LeaveTypeRepository())
            {
                if (leave != null)
                {

                    var leaveCreate = new Data.LeaveType() { leaveTypeID = leave.leaveTypeID, typeName = leave.typeName };
                    leaveRepo.Update(leaveCreate);
                }
            }

        }



    }
}
