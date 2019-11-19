using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.Service;
using System.Net.Mail;
using System.IO;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class FeeBussiness
    {
        DataContext db = new DataContext();
        public List<Model.Fees> getFees()
        {

            using (var leaveRepo = new FeeRepository  ())
            {
                return leaveRepo.GetAll().Select(x => new Model.Fees() {FeeId=x.FeeId,learnerId=x.learnerId,classRoomId=x.classRoomId,stationaryfee=getstationarFee(x.classRoomId),schoolFee=getGradeFee(x.classRoomId),feeAmount=x.feeAmount,datetimeCreated=x.datetimeCreated,dateCreated=x.datetimeCreated.ToShortDateString(),grade=x.classRoom.className }).ToList();
            }
        }




        public invoiceReport getInvoice(int feeId)
        {
            var li = db.fees.Where(l => l.FeeId == feeId).Select(p => new { p.learnerId, p.classRoom.className, p.feeAmount }).FirstOrDefault();
            invoiceReport invoiceReport = new invoiceReport();

            invoiceReport.feeId = feeId;
            invoiceReport.learnerName = db.learnerProfiles.Where(l=>l.learnerId==li.learnerId).Select(op=>op.lname).FirstOrDefault();
            invoiceReport.grade = li.className;
            
            invoiceReport.dateCreated = DateTime.Now.ToShortDateString();

            //load payments
            using (var leaveRepo = new PaymentRepository  ())
            {
                invoiceReport.payments= leaveRepo.GetAll().Where(k=>k.feeId==feeId).Select(x => new Model.Payment() {pymentId=x.pymentId,createdatetime=x.datetimeCreated.ToLongDateString(),payer=getName(x.parentId),amountPayed=x.amountPayed }).ToList();
            }
            foreach(var item in invoiceReport.payments)
            {
                
                invoiceReport.totalPayed += item.amountPayed;

            }
            invoiceReport.schoolfee += li.feeAmount+invoiceReport.totalPayed;
            invoiceReport.owedAmount = li.feeAmount;
            return invoiceReport;

        }

        public string getName(int id)
        {
            var n = db.parents.Where(o => o.parentId == id).Select(u => u.name).FirstOrDefault();
            return (n);
        }
        public double getstationarFee(int id)
        {
            var n = db.classRooms.Where(o => o.classRoomId == id).Select(u => u.graddId).FirstOrDefault();
            var st = db.grades.Where(i => i.gradeId == n).Select(op => op.StationaryFee).FirstOrDefault();
            return (st);
        }
        public double getGradeFee(int id)
        {
            var n = db.classRooms.Where(o => o.classRoomId == id).Select(u => u.graddId).FirstOrDefault();
            var st = db.grades.Where(i => i.gradeId == n).Select(op => op.gradeFee).FirstOrDefault();
            return (st);
        }

        public void createPayment(Model.Payment x)
        {

            using (var leaveRepo = new PaymentRepository())
            {
                if (x != null)
                {

                    var leaveCreate = new Data.Payment() { amountPayed = x.amountPayed, parentId = x.parentId, feeId = x.feeId, datetimeCreated=DateTime.Now,pymentId=x.pymentId };
                    leaveRepo.Insert(leaveCreate);
                }
            }

        }

        public void updateFee(int feeId,double amount )
        {

                    var leaveCreate = db.fees.Where(l => l.FeeId == feeId).FirstOrDefault();
                    leaveCreate.feeAmount -= amount;
                    db.Entry(leaveCreate).State = EntityState.Modified;
                    db.SaveChanges();
        }
        public void sendReport(Stream pdf, string filename,string email)
        {
            
                try
                {
                    MailMessage msg = new MailMessage();

                    //var em = db.parents.Where(k => k.parentId == yu).Select(l => l.emailaddress).FirstOrDefault();
                    //string fileName = Path.GetFileName(fileUploader.FileName);

                    msg.Attachments.Add(new Attachment(pdf, filename));

                    //}
                    msg.From = new MailAddress("abantwanaweb@gmail.com");
                    msg.To.Add(new MailAddress(email));
                    msg.Subject = "Successful Payment";
                    msg.Body = "Please Find Attached Payment Invoice.";
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
                    System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("abantwanaweb@gmail.com", "#Account{2019}");
                    smtpClient.Credentials = credentials;
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(msg);
                }
                catch { }
            

        }

    }
}
