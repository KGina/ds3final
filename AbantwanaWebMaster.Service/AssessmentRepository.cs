using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;


namespace AbantwanaWebMaster.Service
{
    public class AssessmentRepository : IAssessmentRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Assessment> _AssessmentRepository;

        public AssessmentRepository()
        {
            _datacontext = new DataContext();
            _AssessmentRepository = new RepositoryService<Assessment>(_datacontext);

        }

        public Assessment GetById(int id)
        {
            return _AssessmentRepository.GetById(id);
        }

        public List<Assessment> GetAll()
        {
            return _AssessmentRepository.GetAll().ToList();
        }

        public void Insert(Assessment model)
        {
            _AssessmentRepository.Insert(model);
        }

        public void Update(Assessment model)
        {
            _AssessmentRepository.Update(model);
        }

        public void Delete(Assessment model)
        {
            _AssessmentRepository.Delete(model);
        }


        public IEnumerable<Assessment> Find(Func<Assessment, bool> predicate)
        {
            return _AssessmentRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }

    }
}
