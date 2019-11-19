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
    public class GradeBussiness
    {
        DataContext db = new DataContext();
        public List<Model.Grade> getGrade()
        {

            using (var leaveRepo = new GradeRepository  ())
            {
                return leaveRepo.GetAll().Select(x => new Model.Grade() {gradeId=x.gradeId, gradeName=x.gradeName,StationaryFee=x.StationaryFee,gradeFee=x.gradeFee }).ToList();
            }
        }
        
        public void createGrade(Model.Grade x)
        {
            
            using (var leaveRepo = new GradeRepository())
            {
                if (x != null)
                {
                    
                    var leaveCreate = new Data.Grade() { gradeId = x.gradeId, gradeName = x.gradeName, StationaryFee = x.StationaryFee, gradeFee = x.gradeFee };
                    leaveRepo.Insert(leaveCreate);
                }
            }
       
        }

        public void updateGrade(Model.Grade x)
        {

            using (var leaveRepo = new GradeRepository())
            {
                if (x != null)
                {

                    var leaveCreate = new Data.Grade() { gradeId = x.gradeId, gradeName = x.gradeName, StationaryFee = x.StationaryFee, gradeFee = x.gradeFee };
                    leaveRepo.Update(leaveCreate);
                }
            }

        }



    }
}
