using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class YearRepository : IYearRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Year> _OrderRepository;

        public YearRepository()
        {
            _datacontext = new DataContext();
            _OrderRepository = new RepositoryService<Year>(_datacontext);
            
        }

        public Year GetById(int id)
        {
           return _OrderRepository.GetById(id);
        }

        public List<Year> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public void Insert(Year model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(Year model)
        {
            _OrderRepository.Update(model);
        }

        public void Delete(Year model)
        {
            _OrderRepository.Delete(model);
        }

        public IEnumerable<Year> Find(Func<Year, bool> predicate)
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
