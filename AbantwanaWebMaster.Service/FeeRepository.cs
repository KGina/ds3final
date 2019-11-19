using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class FeeRepository : IFeeRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Fees> _OrderRepository;

        public FeeRepository()
        {
            _datacontext = new DataContext();
            _OrderRepository = new RepositoryService<Fees>(_datacontext);
            
        }

        public Fees GetById(int id)
        {
           return _OrderRepository.GetById(id);
        }

        public List<Fees> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public void Insert(Fees model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(Fees model)
        {
            _OrderRepository.Update(model);
        }

        public void Delete(Fees model)
        {
            _OrderRepository.Delete(model);
        }

        public IEnumerable<Fees> Find(Func<Fees, bool> predicate)
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
