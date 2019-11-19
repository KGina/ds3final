
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
    public class ScheduleBussiness
    {
        DataContext db = new DataContext();
        public List<resourceModel> GetworkTeacherSchedules(string UserName)
        {

            //DataContext db = new DataContext();

            db.Configuration.ProxyCreationEnabled = false;
            var staffId = db.staffMembers.Where(x => x.email == UserName).Select(c => c.staffMemberId).FirstOrDefault();
            var workSchedules = db.workSchedules.Where(m => m.staffMemberId == staffId && m.archived == false).ToList();
            //Tempory holder for resrouces
            List<resourceModel> resList = new List<resourceModel>();
            foreach (var wrks in workSchedules)
            {
                //Finds Employee Linked to Event
                AbantwanaWebMaster.Data.StaffMember tempStaff = new AbantwanaWebMaster.Data.StaffMember();
                tempStaff = db.staffMembers.Where(c => c.staffMemberId == wrks.staffMemberId).FirstOrDefault();
                var grd = db.classRooms.Where(v => v.classRoomId == wrks.classRoomId).Select(m => m.className).FirstOrDefault();
                //Saves All information about event to temporary result model
                resourceModel res = new resourceModel();

                res.title = grd;
                //res.id
                res.scheduleId = wrks.scheduleId;
                res.staffMemberId = wrks.staffMemberId;
                res.classRoomId = wrks.classRoomId;
                res.scheduleStartDate = wrks.scheduleStartDate;
                res.scheduleEndDate = wrks.scheduleEndDate;
                res.ThemeColor = wrks.ThemeColor;
                res.Description = tempStaff.StaffMemberName + " " + tempStaff.StaffMemberSurname;
                resList.Add(res);
            }

            //return WorkSchedulerepo.GetAll().Select(x => new ClinicView() { ClinicId = x.ClinicId, ClinicName = x.ClinicName }).ToList();
            return resList;
        }
        public List<resourceModel> GetworkSchedules()
        {

            //DataContext db = new DataContext();

            db.Configuration.ProxyCreationEnabled = false;
            var workSchedules = db.workSchedules.Where(m => m.archived == false).ToList();
            //Tempory holder for resrouces
            List<resourceModel> resList = new List<resourceModel>();


            foreach (var wrks in workSchedules)
            {
                //Finds Employee Linked to Event
                AbantwanaWebMaster.Data.StaffMember tempStaff = new AbantwanaWebMaster.Data.StaffMember();
                tempStaff = db.staffMembers.Where(c => c.staffMemberId == wrks.staffMemberId).FirstOrDefault();
                var grd = db.classRooms.Where(v => v.classRoomId == wrks.classRoomId).Select(m => m.className).FirstOrDefault();
                //Saves All information about event to temporary result model
                resourceModel res = new resourceModel();

                res.title = grd;
                //res.id
                res.scheduleId = wrks.scheduleId;
                res.staffMemberId = wrks.staffMemberId;
                res.classRoomId = wrks.classRoomId;
                res.scheduleStartDate = wrks.scheduleStartDate;
                res.scheduleEndDate = wrks.scheduleEndDate;
                res.ThemeColor = wrks.ThemeColor;
                res.Description = tempStaff.StaffMemberName + " " + tempStaff.StaffMemberSurname;
                resList.Add(res);
            }

            //return WorkSchedulerepo.GetAll().Select(x => new ClinicView() { ClinicId = x.ClinicId, ClinicName = x.ClinicName }).ToList();
            return resList;
        }
        public List<AbantwanaWebMaster.Model.ClassRoom> GetClassroms()
        {

            //DataContext db = new DataContext();

            //ApplicationDbContext db = new ApplicationDbContext();

            db.Configuration.ProxyCreationEnabled = false;
            var workSchedules = db.classRooms.ToList();
            //Tempory holder for resrouces
            List<AbantwanaWebMaster.Model.ClassRoom> resList = new List<AbantwanaWebMaster.Model.ClassRoom>();


            foreach (var wrks in workSchedules)
            {
                //Finds Employee Linked to Event


                //Saves All information about event to temporary result model
                Model.ClassRoom res = new Model.ClassRoom();

                res.roomnumber = wrks.roomNumber;

                res.classRoomId = wrks.classRoomId;
                res.className = wrks.className;
                //TimeSpan? timeDif = res.scheduleEndDate - res.scheduleStartDate;
                //res.Description = tempEmp.Occupation + ", works " + timeDif.Value.TotalHours + " hours today.";

                resList.Add(res);
            }
            //return WorkSchedulerepo.GetAll().Select(x => new ClinicView() { ClinicId = x.ClinicId, ClinicName = x.ClinicName }).ToList();
            return resList;
        }

        public List<AbantwanaWebMaster.Model.ThemeColor> GetThemeColors()
        {

            //DataContext db = new DataContext();

            //ApplicationDbContext db = new ApplicationDbContext();

            db.Configuration.ProxyCreationEnabled = false;
            var workSchedules = db.colors.ToList();
            //Tempory holder for resrouces
            List<AbantwanaWebMaster.Model.ThemeColor> resList = new List<AbantwanaWebMaster.Model.ThemeColor>();


            foreach (var wrks in workSchedules)
            {
                //Finds Employee Linked to Event


                //Saves All information about event to temporary result model
                Model.ThemeColor res = new Model.ThemeColor();

                res.colorName = wrks.colorName;


                resList.Add(res);
            }
            //return WorkSchedulerepo.GetAll().Select(x => new ClinicView() { ClinicId = x.ClinicId, ClinicName = x.ClinicName }).ToList();
            return resList;
        }
        public List<resourceModel> GetResources()
        {

            db.Configuration.ProxyCreationEnabled = false;
            var resources = db.staffMembers.ToList();

            //Tempory holder for resrouces
            List<resourceModel> resList = new List<resourceModel>();


            foreach (var stf in resources)
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
            return resList;
        }
        public AbantwanaWebMaster.Model.schedulelist checkWorkSchedule(AbantwanaWebMaster.Model.WorkSchedule wrks)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var status = false;
            wrks.scheduleStartDate = new DateTime(wrks.scheduleStartDate.Year, wrks.scheduleStartDate.Month, wrks.scheduleStartDate.Day, wrks.scheduleStartDate.Hour + 2, wrks.scheduleStartDate.Minute, 0);
            wrks.scheduleEndDate = new DateTime(wrks.scheduleEndDate.Year, wrks.scheduleEndDate.Month, wrks.scheduleEndDate.Day, wrks.scheduleEndDate.Hour + 2, wrks.scheduleEndDate.Minute, 0);

            var ClassSchedule = db.workSchedules.Where(a => a.classRoomId == wrks.classRoomId && (a.archived == false) && ((a.scheduleStartDate <= wrks.scheduleStartDate && (a.scheduleStartDate.Hour <= wrks.scheduleStartDate.Hour && a.scheduleEndDate.Hour >= wrks.scheduleStartDate.Hour) && wrks.scheduleStartDate < a.scheduleEndDate))).Select(h => h.scheduleId).FirstOrDefault();

            var sfaName = "";
            if (ClassSchedule == 0)
            {
                //SaveWorkSchedule(wrks);

                status = true;
            }
            else
            {
                sfaName = db.workSchedules.Where(a => a.scheduleId == ClassSchedule).Select(h => h.StaffMember.StaffMemberName).FirstOrDefault();
                status = false;
            }
            schedulelist obj = new schedulelist();
            obj.ClassSchedule = ClassSchedule;
            obj.status = status;
            obj.sfaName = sfaName;
            return obj;
        }
        public bool saveWork(AbantwanaWebMaster.Model.WorkSchedule wrks)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var status = false;
            wrks.scheduleStartDate = new DateTime(wrks.scheduleStartDate.Year, wrks.scheduleStartDate.Month, wrks.scheduleStartDate.Day, wrks.scheduleStartDate.Hour + 2, wrks.scheduleStartDate.Minute, 0);
            wrks.scheduleEndDate = new DateTime(wrks.scheduleEndDate.Year, wrks.scheduleEndDate.Month, wrks.scheduleEndDate.Day, wrks.scheduleEndDate.Hour + 2, wrks.scheduleEndDate.Minute, 0);
            //If the event ID is bigger than zero its a existing event.
            if (wrks.scheduleId > 0)
            {
                //Grabs event with given ID from the database
                var oldwrks = db.workSchedules.Where(a => a.scheduleId == wrks.scheduleId).FirstOrDefault();

                if (oldwrks != null)
                {
                    //Replaces fields that has been updated
                    //oldEvent. = wrks.EventID;
                    oldwrks.scheduleId = wrks.scheduleId;
                    oldwrks.staffMemberId = wrks.staffMemberId;
                    oldwrks.classRoomId = wrks.classRoomId;
                    oldwrks.scheduleStartDate = wrks.scheduleStartDate;
                    oldwrks.scheduleEndDate = wrks.scheduleEndDate;
                    // oldEvent.IsFullDay = wrks.IsFullDay;
                    //oldEvent.Description = wrks.Description;
                    oldwrks.ThemeColor = wrks.ThemeColor;
                    db.Entry(oldwrks).State = EntityState.Modified;
                }
            }
            //If a new event is added, it just adds the new event to DB
            else
            {
                Data.WorkSchedule workSchedule = new Data.WorkSchedule();
                workSchedule.archived = wrks.archived;
                workSchedule.classRoomId = wrks.classRoomId;
                workSchedule.scheduleEndDate = wrks.scheduleEndDate;
                workSchedule.scheduleId = wrks.scheduleId;
                workSchedule.scheduleStartDate = wrks.scheduleStartDate;
                workSchedule.ThemeColor = wrks.ThemeColor;
                workSchedule.staffMemberId = wrks.staffMemberId;
                db.workSchedules.Add(workSchedule);
            }

            db.SaveChanges();
            status = true;
            return (status);
        }

        public bool updateWorkSchedule(AbantwanaWebMaster.Model.WorkSchedule wrks)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var status = false;
            var leavedate = db.leaveRequests.Where(n => n.staffmemberId == wrks.staffMemberId && ((n.startdate <= wrks.scheduleStartDate && n.enddate >= wrks.scheduleStartDate) || (n.startdate <= wrks.scheduleEndDate && n.enddate >= wrks.scheduleEndDate)) && (n.status == "Approved")).FirstOrDefault();

            if (leavedate == null)
            {
                wrks.scheduleStartDate = new DateTime(wrks.scheduleStartDate.Year, wrks.scheduleStartDate.Month, wrks.scheduleStartDate.Day, wrks.scheduleStartDate.Hour + 2, wrks.scheduleStartDate.Minute, 0);
                wrks.scheduleEndDate = new DateTime(wrks.scheduleEndDate.Year, wrks.scheduleEndDate.Month, wrks.scheduleEndDate.Day, wrks.scheduleEndDate.Hour + 2, wrks.scheduleEndDate.Minute, 0);

                var scheduleId = db.workSchedules.Where(a => a.classRoomId == wrks.classRoomId && (a.archived == false) && ((a.scheduleStartDate <= wrks.scheduleStartDate && (a.scheduleStartDate.Hour <= wrks.scheduleStartDate.Hour && a.scheduleEndDate.Hour >= wrks.scheduleStartDate.Hour) && wrks.scheduleStartDate < a.scheduleEndDate))).Select(h => h.scheduleId).FirstOrDefault();
                if (scheduleId == 0)
                {
                    scheduleId = db.workSchedules.Where(a => (a.classRoomId == wrks.classRoomId) && (a.archived == false) && ((a.scheduleStartDate <= wrks.scheduleStartDate && a.scheduleEndDate >= wrks.scheduleStartDate) || (a.scheduleStartDate <= wrks.scheduleEndDate && a.scheduleEndDate >= wrks.scheduleEndDate))).Select(h => h.scheduleId).FirstOrDefault();
                }
                //var scheduleId = db.workSchedules.Where(a => a.classRoomId == wrks.classRoomId && ((a.scheduleStartDate >= wrks.scheduleStartDate && a.scheduleStartDate.Hour > wrks.scheduleStartDate.Hour && a.scheduleStartDate <= wrks.scheduleEndDate) || (a.scheduleEndDate >= wrks.scheduleStartDate && a.scheduleEndDate <= wrks.scheduleEndDate))).Select(h => h.scheduleId).FirstOrDefault();

                var oldStart = db.workSchedules.Where(c => c.scheduleId == scheduleId).Select(m => m.scheduleStartDate).FirstOrDefault();
                var oldEnd = db.workSchedules.Where(c => c.scheduleId == scheduleId).Select(m => m.scheduleEndDate).FirstOrDefault();

                var oldwrk = db.workSchedules.Where(a => a.scheduleId == scheduleId).FirstOrDefault();
                var oldwrkBackUp = oldwrk;

                // db.SaveChanges();
                if (oldwrkBackUp != null)
                {
                    if (wrks.scheduleEndDate <= oldEnd)
                    {
                        Data.WorkSchedule newSch = new Data.WorkSchedule();
                        newSch.scheduleId = 0;
                        newSch.scheduleStartDate = new DateTime(wrks.scheduleEndDate.Date.AddDays(1).Year, wrks.scheduleEndDate.Date.AddDays(1).Month, wrks.scheduleEndDate.Date.AddDays(1).Day, wrks.scheduleStartDate.Hour, wrks.scheduleStartDate.Minute, 0);
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
                    if (oldStart < wrks.scheduleStartDate)
                    {
                        //oldwrk.scheduleStartDate = wrks.scheduleStartDate;
                        oldwrk.scheduleEndDate = new DateTime(wrks.scheduleStartDate.AddDays(-1).Year, wrks.scheduleStartDate.AddDays(-1).Month, wrks.scheduleStartDate.AddDays(-1).Day, oldwrk.scheduleEndDate.Hour, oldwrk.scheduleEndDate.Minute, 0);
                    }
                    else
                    {
                        oldwrk.archived = true;
                    }

                    db.Entry(oldwrk).State = EntityState.Modified;
                    db.SaveChanges();
                    status = true;

                }

                Data.WorkSchedule workSchedule = new Data.WorkSchedule();
                workSchedule.archived = wrks.archived;
                workSchedule.classRoomId = wrks.classRoomId;
                workSchedule.scheduleEndDate = wrks.scheduleEndDate;
                workSchedule.scheduleId = wrks.scheduleId;
                workSchedule.scheduleStartDate = wrks.scheduleStartDate;
                workSchedule.ThemeColor = wrks.ThemeColor;
                workSchedule.staffMemberId = wrks.staffMemberId;
                db.workSchedules.Add(workSchedule);
                db.SaveChanges();
                status = true;
            }
            return (status);
        }
        public bool delSchedule(int scheduleId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var status = false;

            //Finds event by ID which should be deleted
            var wrks = db.workSchedules.Where(a => a.scheduleId == scheduleId).FirstOrDefault();

            if (wrks != null)
            {
                //Removes event from DB
                wrks.archived = true;
                db.Entry(wrks).State = EntityState.Modified;
                // db.workSchedules.Remove(wrks);
                db.SaveChanges();
                status = true;

            }
            return (status);
        }
    }
}
