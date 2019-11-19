using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class GradeRepository : IGradeRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Grade> _OrderRepository;

        public GradeRepository()
        {
            _datacontext = new DataContext();
            _OrderRepository = new RepositoryService<Grade>(_datacontext);
            
        }

        public Grade GetById(int id)
        {
           return _OrderRepository.GetById(id);
        }

        public List<Grade> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public void Insert(Grade model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(Grade model)
        {
            _OrderRepository.Update(model);
        }

        public void Delete(Grade model)
        {
            _OrderRepository.Delete(model);
        }

        public IEnumerable<Grade> Find(Func<Grade, bool> predicate)
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
