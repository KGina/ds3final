using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class ConnectionRepository : IConnectionRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Connection> _AnnouncementRepository;

        public ConnectionRepository()
        {
            _datacontext = new DataContext();
            _AnnouncementRepository = new RepositoryService<Connection>(_datacontext);
            
        }

        public Connection GetById(int id)
        {
           return _AnnouncementRepository.GetById(id);
        }

        public List<Connection> GetAll()
        {
            return _AnnouncementRepository.GetAll().ToList();
        }

        public void Insert(Connection model)
        {
            _AnnouncementRepository.Insert(model);
        }

        public void Update(Connection model)
        {
            _AnnouncementRepository.Update(model);
        }

        public void Delete(Connection model)
        {
            _AnnouncementRepository.Delete(model);
        }

        public IEnumerable<Connection> Find(Func<Connection, bool> predicate)
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
