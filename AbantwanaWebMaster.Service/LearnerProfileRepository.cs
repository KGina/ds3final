using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class LearnerProfileRepository:ILearnerProfileRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<LearnerProfile> _LearnerProfileRepository;

        public LearnerProfileRepository()
        {
            _datacontext = new DataContext();
            _LearnerProfileRepository = new RepositoryService<LearnerProfile>(_datacontext);
            
        }

        public LearnerProfile GetById(int id)
        {
           return _LearnerProfileRepository.GetById(id);
        }

        public List<LearnerProfile> GetAll()
        {
            return _LearnerProfileRepository.GetAll().ToList();
        }

        public void Insert(LearnerProfile model)
        {
            _LearnerProfileRepository.Insert(model);
        }

        public void Update(LearnerProfile model)
        {
            _LearnerProfileRepository.Update(model);
        }

        public void Delete(LearnerProfile model)
        {
            _LearnerProfileRepository.Delete(model);
        }

        public IEnumerable<LearnerProfile> Find(Func<LearnerProfile, bool> predicate)
        {
           return _LearnerProfileRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
