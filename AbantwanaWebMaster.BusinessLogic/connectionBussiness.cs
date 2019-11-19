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
    public class connectionBussiness
    {
        DataContext db = new DataContext();


        public List<Model.Connection> GetConnection()
        {
            using (var AssessmentRep = new ConnectionRepository())
            {
                return AssessmentRep.GetAll().Select(x => new Model.Connection()
                {
                   Id=x.Id,
                   ConnectionId=x.ConnectionId,
                   UserName=x.UserName,
                   IsOnline=x.IsOnline
                }).ToList();
            }


        }
        public List<Model.Connection> GetAssessmentsConnections(string subId)
        {
            using (var AssessmentRep = new ConnectionRepository())
            {
                return AssessmentRep.GetAll().Where(k=>k.ConnectionId==subId).Select(x => new Model.Connection()
                {
                    Id = x.Id,
                    ConnectionId = x.ConnectionId,
                    UserName = x.UserName,
                    IsOnline = x.IsOnline

                }).ToList();
            }


        }
       
        
        public int counter()
        {

            using (var AssessmentRep = new AssessmentRepository())
            {
                return AssessmentRep.GetAll().Count();
            }
        }

        public void addConnection(Model.Connection connection)
        {

            using (var AssessmentRep = new ConnectionRepository())
            {

                var addAssess = new Data.Connection
                {
                    Id = connection.Id,
                    ConnectionId = connection.ConnectionId,
                    UserName = connection.UserName,
                    IsOnline = connection.IsOnline
                    //subjectId=assessment.subjectId

                };
                AssessmentRep.Insert(addAssess);
            }
        }
        public void updateConnection(Model.Connection connection)
        {

            using (var AssessmentRep = new ConnectionRepository())
            {

                var addAssess = new Data.Connection
                {
                    Id = connection.Id,
                    ConnectionId = connection.ConnectionId,
                    UserName = connection.UserName,
                    IsOnline = connection.IsOnline
                    //subjectId=assessment.subjectId

                };
                AssessmentRep.Update(addAssess);
            }
        }
        public void newLearnerMark(Model.LearnerAssessment assessment)
        {

            using (var AssessmentRep = new YearLearnerGradeSubjectAssessmentRepository())
            {

                var addAssess = new Data.YearLearnerGradeSubjectAssessment
                {
                    assessmentId = assessment.assessmentId,
                    learnerId = assessment.learnerId,
                    mark=assessment.AssessmentMark
                };
                
                    AssessmentRep.Insert(addAssess);
                
            }
        }
    }
}

