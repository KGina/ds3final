using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class ParentRepository:IParentRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Parent> _ParentRepository;

        public ParentRepository()
        {
            _datacontext = new DataContext();
            _ParentRepository = new RepositoryService<Parent>(_datacontext);
            
        }

        public Parent GetById(int id)
        {
           return _ParentRepository.GetById(id);
        }

        public List<Parent> GetAll()
        {
            return _ParentRepository.GetAll().ToList();
        }

        public void Insert(Parent model)
        {
            _ParentRepository.Insert(model);
        }

        public void Update(Parent model)
        {
            _ParentRepository.Update(model);
        }

        public void Delete(Parent model)
        {
            _ParentRepository.Delete(model);
        }

        public IEnumerable<Parent> Find(Func<Parent, bool> predicate)
        {
           return _ParentRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
