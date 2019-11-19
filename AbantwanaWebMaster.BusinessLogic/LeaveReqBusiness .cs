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
    public class LeaveReqBusiness
    {
        DataContext db = new DataContext();

        public DateTime conv( DateTime h)
        {
            return new DateTime(h.Year,h.Month,h.Day);
        }
        public List<Model.LeaveRequest>  getLeaveReqs()
        {

            using (var leaveRepo = new LeaveRequestRepository())
            {
                return leaveRepo.GetAll().Where(k=>k.archived==false).Select(x => new Model.LeaveRequest() {requestid=x.requestid,startdate=x.startdate,enddate=x.enddate,reason=x.reason,status=x.status,staffmemberId=x.staffmemberId ,leaveTypeID=x.leaveTypeID,createDate=x.createDate,createdBy =x.leavetype.typeName,StaffMemberName=x.StaffMember.StaffMemberName }).ToList();
            }
        }
        public List<Model.LeaveRequest> getLeaveReqs(string username)
        {
            var id = db.staffMembers.Where(k => k.email == username).Select(k => k.staffMemberId).FirstOrDefault();
            using (var leaveRepo = new LeaveRequestRepository())
            {
                return leaveRepo.GetAll().Where(k =>k.staffmemberId==id&& k.archived == false).Select(x => new Model.LeaveRequest() { requestid = x.requestid, startdate = x.startdate, enddate = x.enddate, reason = x.reason, status = x.status, staffmemberId = x.staffmemberId, leaveTypeID = x.leaveTypeID, createDate = x.createDate, createdBy = x.leavetype.typeName, StaffMemberName = x.StaffMember.StaffMemberName }).ToList();
            }
        }
        public bool acrhiveType(int ReqID)
        {
            if (ReqID != 0)
            {
                var leavedate = db.leaveRequests.Where(k => k.requestid == ReqID).FirstOrDefault();
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

        public List<Model.LeaveType> getLeaveTypes()
        {

            using (var leaveRepo = new LeaveTypeRepository())
            { 
                return leaveRepo.GetAll().Where(k=>k.archived==false).Select(x => new Model.LeaveType() { typeName=x.typeName, leaveTypeID = x.leaveTypeID }).ToList();
            }
        }

        public Model.LeaveRequest getLeaveReqs(int id)
        {

            using (var leaveRepo = new LeaveRequestRepository())
            {
                return leaveRepo.GetAll().Where(b=>b.requestid==id&&b.archived==false).Select(x => new Model.LeaveRequest() { requestid = x.requestid, startdate = x.startdate, enddate = x.enddate, reason = x.reason, status = x.status, staffmemberId = x.staffmemberId, leaveTypeID = x.leaveTypeID }).FirstOrDefault();
            }
        }
        public int counter()
        {

            using (var leaveRepo = new LeaveRequestRepository())
            {
                return leaveRepo.GetAll().Where(b => b.status == "Waiting for Approval"&&b.archived==false).Count();
            }
        }

        public bool ReplaceTeacher(Model.LeaveRequest leave )
        {
            var leavedate = db.leaveRequests.Where(b => b.requestid == leave.requestid).FirstOrDefault();
            if (leave.status == "Approved")
            {
                ScheduleBussiness schBuss = new ScheduleBussiness();
                Model.WorkSchedule newWork = new Model.WorkSchedule();
               
                var wrkstaffID = db.workSchedules.Where(n => (n.scheduleStartDate <= leavedate.startdate && n.scheduleEndDate >= leavedate.startdate) || (n.scheduleStartDate <= leavedate.enddate && n.scheduleEndDate >= leavedate.enddate)).Select(v => new { v.staffMemberId, v.classRoomId }).ToList();
                var affectedClass = db.workSchedules.Where(n => (n.staffMemberId == leavedate.staffmemberId) && (n.scheduleStartDate <= leavedate.startdate && n.scheduleEndDate >= leavedate.startdate) || (n.scheduleStartDate <= leavedate.enddate && n.scheduleEndDate >= leavedate.enddate)).Select(v => new { v.staffMemberId, v.classRoomId, v.ThemeColor, v.scheduleEndDate, v.scheduleStartDate }).FirstOrDefault();
                var staffID = db.staffMembers.Select(c => c.staffMemberId).ToList();
                //int c1 = 0;
                int c2 = 0;
                if (staffID != null && wrkstaffID != null && affectedClass != null)
                {
                    foreach (var ty in staffID)
                    {
                        c2 = 0;
                        foreach (var item in wrkstaffID)
                        {
                            if (item.staffMemberId == ty)
                            {
                                c2 = c2 + 1;
                            }
                        }
                        if (c2 == 0)
                        {

                            newWork.classRoomId = affectedClass.classRoomId;
                            newWork.staffMemberId = ty;
                            newWork.scheduleStartDate = new DateTime(leavedate.startdate.Year, leavedate.startdate.Month, leavedate.startdate.Day, affectedClass.scheduleStartDate.Hour - 2, affectedClass.scheduleStartDate.Minute, 0);
                            newWork.scheduleEndDate = new DateTime(leavedate.enddate.Year, leavedate.enddate.Month, leavedate.enddate.Day, affectedClass.scheduleEndDate.Hour - 2, affectedClass.scheduleEndDate.Minute, 0);
                            //newWork.scheduleEndDate = leavedate.enddate;
                            newWork.ThemeColor = affectedClass.ThemeColor;
                            leavedate.status = "Approved";

                            db.Entry(leavedate).State = EntityState.Modified;
                            db.SaveChanges();

                            return schBuss.updateWorkSchedule(newWork);

                        }
                    }
                    return false;
                }
                leavedate.status = "Approved";

                db.Entry(leavedate).State = EntityState.Modified;
                db.SaveChanges();

                return true;
                
            }
            else
            {
                leavedate.status = "Rejected";
                db.Entry(leavedate).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }

        }
        public void createLeaveReq(Model.LeaveRequest leave,string Username)
        {
            
            using (var leaveRepo = new LeaveRequestRepository())
            {
                if (leave != null)
                {
                    leave.staffmemberId = db.staffMembers.Where(s => s.email == Username).Select(k => k.staffMemberId).FirstOrDefault();
                    var leaveCreate = new Data.LeaveRequest { requestid = leave.requestid, startdate = leave.startdate, enddate = leave.enddate, reason = leave.reason, status = "Waiting for Approval",leaveTypeID=leave.leaveTypeID,createDate=DateTime.Now.Date ,staffmemberId = leave.staffmemberId };
                    leaveRepo.Insert(leaveCreate);
                }
            }
       
        }


        public bool ReplaceWithTeacher(Model.LeaveRequest work)
        {
            ScheduleBussiness schBuss = new ScheduleBussiness();
            Model.WorkSchedule newWork = new Model.WorkSchedule();
            var leavedate = db.leaveRequests.Where(b => b.requestid == work.requestid).FirstOrDefault();
            var wrkstaffID = db.workSchedules.Where(n => (n.scheduleStartDate <= leavedate.startdate && n.scheduleEndDate >= leavedate.startdate) || (n.scheduleStartDate <= leavedate.enddate && n.scheduleEndDate >= leavedate.enddate)).Select(v => new { v.staffMemberId, v.classRoomId }).ToList();
            var affectedClass = db.workSchedules.Where(n => (n.staffMemberId == leavedate.staffmemberId) && (n.scheduleStartDate <= leavedate.startdate && n.scheduleEndDate >= leavedate.startdate) || (n.scheduleStartDate <= leavedate.enddate && n.scheduleEndDate >= leavedate.enddate)).Select(v => new { v.staffMemberId, v.classRoomId, v.ThemeColor, v.scheduleEndDate, v.scheduleStartDate }).FirstOrDefault();
            var staffID = work.staffmemberId;
            //int c1 = 0;
            var scheduleId = db.workSchedules.Where(a => a.staffMemberId == work.staffmemberId && (a.archived == false) && ((a.scheduleStartDate <= leavedate.startdate &&  leavedate.startdate <= a.scheduleEndDate)|| (a.scheduleStartDate <= leavedate.enddate && leavedate.enddate <= a.scheduleEndDate))).Select(h => h.scheduleId).FirstOrDefault();


            var oldStart = db.workSchedules.Where(c => c.scheduleId == scheduleId).Select(m => m.scheduleStartDate).FirstOrDefault();
            var oldEnd = db.workSchedules.Where(c => c.scheduleId == scheduleId).Select(m => m.scheduleEndDate).FirstOrDefault();

            var oldwrk = db.workSchedules.Where(a => a.scheduleId == scheduleId).FirstOrDefault();
            var oldwrkBackUp = oldwrk;
            if (staffID != 0 && affectedClass != null)
            {
                if (oldwrkBackUp != null)
                {
                    if (leavedate.enddate <= oldEnd)
                    {
                        Data.WorkSchedule newSch = new Data.WorkSchedule();
                        newSch.scheduleId = 0;
                        newSch.scheduleStartDate = new DateTime(leavedate.enddate.Date.AddDays(1).Year, leavedate.enddate.Date.AddDays(1).Month, leavedate.enddate.Date.AddDays(1).Day, oldwrkBackUp.scheduleStartDate.Hour, oldwrkBackUp.scheduleStartDate.Minute, 0);
                        newSch.staffMemberId = oldwrkBackUp.staffMemberId;
                        newSch.classRoomId = oldwrkBackUp.classRoomId;
                        newSch.scheduleEndDate = oldwrkBackUp.scheduleEndDate;
                        newSch.ThemeColor = oldwrkBackUp.ThemeColor;
                        db.workSchedules.Add(newSch);
                        db.SaveChanges();
                    }
                }
                if (oldwrk != null)
                {
                    if (oldStart < leavedate.startdate)
                    {
                        //oldwrk.scheduleStartDate = wrks.scheduleStartDate;
                        oldwrk.scheduleEndDate = new DateTime(leavedate.startdate.AddDays(-1).Year, leavedate.startdate.AddDays(-1).Month, leavedate.startdate.AddDays(-1).Day, oldwrk.scheduleEndDate.Hour, oldwrk.scheduleEndDate.Minute, 0);
                    }
                    else
                    {
                        oldwrk.archived = true;
                    }

                    db.Entry(oldwrk).State = EntityState.Modified;
                    db.SaveChanges();
                    //status = true;

                }




                        newWork.classRoomId = affectedClass.classRoomId;
                        newWork.staffMemberId = staffID;
                        newWork.scheduleStartDate = new DateTime(leavedate.startdate.Year, leavedate.startdate.Month, leavedate.startdate.Day, affectedClass.scheduleStartDate.Hour - 2, affectedClass.scheduleStartDate.Minute, 0);
                        newWork.scheduleEndDate = new DateTime(leavedate.enddate.Year, leavedate.enddate.Month, leavedate.enddate.Day, affectedClass.scheduleEndDate.Hour - 2, affectedClass.scheduleEndDate.Minute, 0);
                        //newWork.scheduleEndDate = leavedate.enddate;
                        newWork.ThemeColor = affectedClass.ThemeColor;
                        leavedate.status = "Approved";

                        db.Entry(leavedate).State = EntityState.Modified;
                        db.SaveChanges();

                        return schBuss.updateWorkSchedule(newWork);

              
            }
            else
            {
                return false;
            }

        }

        public List<resourceModel> GetResources(int reqId)
        {

            db.Configuration.ProxyCreationEnabled = false;
            var resources = db.staffMembers.ToList();
            var sf = db.leaveRequests.Where(n=>n.requestid==reqId).Select(v=>v.staffmemberId).FirstOrDefault();
            //Tempory holder for resrouces
            List<resourceModel> resList = new List<resourceModel>();


            foreach (var stf in resources)
            {
                if (sf!=stf.staffMemberId)
                {
                    resourceModel res = new resourceModel();
                    res.title = stf.StaffMemberName + " " + stf.StaffMemberSurname;
                    res.staffMemberId = stf.staffMemberId;
                    res.resourceId = stf.staffMemberId;
                    res.phonenumber = stf.phonenumber;
                    res.email = stf.email;
                    //res.dateOfBirth = stf.dateOfBirth;
                    res.groupId = "Teacher";
                    res.id = stf.staffMemberId;
                    resList.Add(res);
                }

            }
            return resList;
        }
    }
}
