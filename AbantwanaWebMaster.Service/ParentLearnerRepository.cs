using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class ParentLearnerRepository : IParentLearnerRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<ParentLearner> _ParentRepository;

        public ParentLearnerRepository()
        {
            _datacontext = new DataContext();
            _ParentRepository = new RepositoryService<ParentLearner>(_datacontext);
            
        }

        public ParentLearner GetById(int id)
        {
           return _ParentRepository.GetById(id);
        }

        public List<ParentLearner> GetAll()
        {
            return _ParentRepository.GetAll().ToList();
        }

        public void Insert(ParentLearner model)
        {
            _ParentRepository.Insert(model);
        }

        public void Update(ParentLearner model)
        {
            _ParentRepository.Update(model);
        }

        public void Delete(ParentLearner model)
        {
            _ParentRepository.Delete(model);
        }

        public IEnumerable<ParentLearner> Find(Func<ParentLearner, bool> predicate)
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
