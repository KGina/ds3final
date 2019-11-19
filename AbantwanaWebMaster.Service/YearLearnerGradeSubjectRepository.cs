using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class YearLearnerGradeSubjectRepository : IYearLearnerGradeSubjectRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<YearLearnerGradeSubject> _OrderRepository;

        public YearLearnerGradeSubjectRepository()
        {
            _datacontext = new DataContext();
            _OrderRepository = new RepositoryService<YearLearnerGradeSubject>(_datacontext);
            
        }

        public YearLearnerGradeSubject GetById(int id)
        {
           return _OrderRepository.GetById(id);
        }

        public List<YearLearnerGradeSubject> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public void Insert(YearLearnerGradeSubject model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(YearLearnerGradeSubject model)
        {
            _OrderRepository.Update(model);
        }

        public void Delete(YearLearnerGradeSubject model)
        {
            _OrderRepository.Delete(model);
        }

        public IEnumerable<YearLearnerGradeSubject> Find(Func<YearLearnerGradeSubject, bool> predicate)
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
