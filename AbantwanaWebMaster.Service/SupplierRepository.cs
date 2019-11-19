using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class SupplierRepository:ISupplierRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Supplier> _SupplierRepository;

        public SupplierRepository()
        {
            _datacontext = new DataContext();
            _SupplierRepository = new RepositoryService<Supplier>(_datacontext);
            
        }

        public Supplier GetById(int id)
        {
           return _SupplierRepository.GetById(id);
        }

        public List<Supplier> GetAll()
        {
            return _SupplierRepository.GetAll().ToList();
        }

        public void Insert(Supplier model)
        {
            _SupplierRepository.Insert(model);
        }

        public void Update(Supplier model)
        {
            _SupplierRepository.Update(model);
        }

        public void Delete(Supplier model)
        {
            _SupplierRepository.Delete(model);
        }

        public IEnumerable<Supplier> Find(Func<Supplier, bool> predicate)
        {
           return _SupplierRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
