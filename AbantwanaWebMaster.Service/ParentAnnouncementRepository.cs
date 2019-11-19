using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class ParentAnnouncementRepository : IParenAnnRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<ParentAnnouncement> _ParentRepository;

        public ParentAnnouncementRepository()
        {
            _datacontext = new DataContext();
            _ParentRepository = new RepositoryService<ParentAnnouncement>(_datacontext);
            
        }

        public ParentAnnouncement GetById(int id)
        {
           return _ParentRepository.GetById(id);
        }

        public List<ParentAnnouncement> GetAll()
        {
            return _ParentRepository.GetAll().ToList();
        }

        public void Insert(ParentAnnouncement model)
        {
            _ParentRepository.Insert(model);
        }

        public void Update(ParentAnnouncement model)
        {
            _ParentRepository.Update(model);
        }

        public void Delete(ParentAnnouncement model)
        {
            _ParentRepository.Delete(model);
        }

        public IEnumerable<ParentAnnouncement> Find(Func<ParentAnnouncement, bool> predicate)
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
