
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Service;

namespace AbantwanaWebMaster.Service
{
    public class SubjectRepository : ISubjectRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Subject> _SubjectRepository;

        public SubjectRepository()
        {
            _datacontext = new DataContext();
            _SubjectRepository = new RepositoryService<Subject>(_datacontext);

        }

        public Subject GetById(int id)
        {
            return _SubjectRepository.GetById(id);
        }

        public List<Subject> GetAll()
        {
            return _SubjectRepository.GetAll().ToList();
        }

        public void Insert(Subject model)
        {
            _SubjectRepository.Insert(model);
        }

        public void Update(Subject model)
        {
            _SubjectRepository.Update(model);
        }

        public void Delete(Subject model)
        {
            _SubjectRepository.Delete(model);
        }


        public IEnumerable<Subject> Find(Func<Subject, bool> predicate)
        {
            return _SubjectRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
