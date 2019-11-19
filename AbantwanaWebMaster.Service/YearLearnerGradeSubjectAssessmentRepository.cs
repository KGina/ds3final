using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class YearLearnerGradeSubjectAssessmentRepository : IYearLearnerGradeSubjectAssessmentRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<YearLearnerGradeSubjectAssessment> _OrderRepository;

        public YearLearnerGradeSubjectAssessmentRepository()
        {
            _datacontext = new DataContext();
            _OrderRepository = new RepositoryService<YearLearnerGradeSubjectAssessment>(_datacontext);
            
        }

        public YearLearnerGradeSubjectAssessment GetById(int id)
        {
           return _OrderRepository.GetById(id);
        }

        public List<YearLearnerGradeSubjectAssessment> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public void Insert(YearLearnerGradeSubjectAssessment model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(YearLearnerGradeSubjectAssessment model)
        {
            _OrderRepository.Update(model);
        }

        public void Delete(YearLearnerGradeSubjectAssessment model)
        {
            _OrderRepository.Delete(model);
        }

        public IEnumerable<YearLearnerGradeSubjectAssessment> Find(Func<YearLearnerGradeSubjectAssessment, bool> predicate)
        {
           return _OrderRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
