using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class GradeSubjectRepository : IGradeSubjectRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<GradeSubject> _OrderRepository;

        public GradeSubjectRepository()
        {
            _datacontext = new DataContext();
            _OrderRepository = new RepositoryService<GradeSubject>(_datacontext);
            
        }

        public GradeSubject GetById(int id)
        {
           return _OrderRepository.GetById(id);
        }

        public List<GradeSubject> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public void Insert(GradeSubject model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(GradeSubject model)
        {
            _OrderRepository.Update(model);
        }

        public void Delete(GradeSubject model)
        {
            _OrderRepository.Delete(model);
        }

        public IEnumerable<GradeSubject> Find(Func<GradeSubject, bool> predicate)
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
