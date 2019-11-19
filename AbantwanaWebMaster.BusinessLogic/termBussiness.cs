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
    public class termBussiness
    {
        DataContext db = new DataContext();
        public List<Model.Term>  getTerm()
        {

            using (var leaveRepo = new TermRepository  ())
            {
                return leaveRepo.GetAll().Select(x => new Model.Term() {termId=x.termId, name=x.name }).ToList();
            }
        }
        
        public void createTerm(Model.Term leave)
        {
            
            using (var leaveRepo = new TermRepository())
            {
                if (leave != null)
                {
                    
                    var leaveCreate = new Data.Term() { termId=leave.termId,name=leave.name};
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
