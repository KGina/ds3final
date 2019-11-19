using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class AnnouncementRepository:IAnnouncementRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Announcement> _AnnouncementRepository;

        public AnnouncementRepository()
        {
            _datacontext = new DataContext();
            _AnnouncementRepository = new RepositoryService<Announcement>(_datacontext);
            
        }

        public Announcement GetById(int id)
        {
           return _AnnouncementRepository.GetById(id);
        }

        public List<Announcement> GetAll()
        {
            return _AnnouncementRepository.GetAll().ToList();
        }

        public void Insert(Announcement model)
        {
            _AnnouncementRepository.Insert(model);
        }

        public void Update(Announcement model)
        {
            _AnnouncementRepository.Update(model);
        }

        public void Delete(Announcement model)
        {
            _AnnouncementRepository.Delete(model);
        }

        public IEnumerable<Announcement> Find(Func<Announcement, bool> predicate)
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
