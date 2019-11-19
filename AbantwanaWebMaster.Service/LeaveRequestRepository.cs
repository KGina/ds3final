using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class LeaveRequestRepository: ILeaveRequestRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<LeaveRequest> _LeaveRequestRepository;

        public LeaveRequestRepository()
        {
            _datacontext = new DataContext();
            _LeaveRequestRepository = new RepositoryService<LeaveRequest>(_datacontext);
            
        }

        public LeaveRequest GetById(int id)
        {
           return _LeaveRequestRepository.GetById(id);
        }

        public List<LeaveRequest> GetAll()
        {
            return _LeaveRequestRepository.GetAll().ToList();
        }

        public void Insert(LeaveRequest model)
        {
            _LeaveRequestRepository.Insert(model);
        }

        public void Update(LeaveRequest model)
        {
            _LeaveRequestRepository.Update(model);
        }

        public void Delete(LeaveRequest model)
        {
            _LeaveRequestRepository.Delete(model);
        }

        public IEnumerable<LeaveRequest> Find(Func<LeaveRequest, bool> predicate)
        {
           return _LeaveRequestRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
