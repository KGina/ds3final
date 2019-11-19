using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class TermRepository : ITermRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Term> _AnnouncementRepository;

        public TermRepository()
        {
            _datacontext = new DataContext();
            _AnnouncementRepository = new RepositoryService<Term>(_datacontext);
            
        }

        public Term GetById(int id)
        {
           return _AnnouncementRepository.GetById(id);
        }

        public List<Term> GetAll()
        {
            return _AnnouncementRepository.GetAll().ToList();
        }

        public void Insert(Term model)
        {
            _AnnouncementRepository.Insert(model);
        }

        public void Update(Term model)
        {
            _AnnouncementRepository.Update(model);
        }

        public void Delete(Term model)
        {
            _AnnouncementRepository.Delete(model);
        }

        public IEnumerable<Term> Find(Func<Term, bool> predicate)
        {
           return _AnnouncementRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
