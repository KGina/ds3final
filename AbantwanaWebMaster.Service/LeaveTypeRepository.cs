using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<LeaveType> _OrderRepository;

        public LeaveTypeRepository()
        {
            _datacontext = new DataContext();
            _OrderRepository = new RepositoryService<LeaveType>(_datacontext);
            
        }

        public LeaveType GetById(int id)
        {
           return _OrderRepository.GetById(id);
        }

        public List<LeaveType> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public void Insert(LeaveType model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(LeaveType model)
        {
            _OrderRepository.Update(model);
        }

        public void Delete(LeaveType model)
        {
            _OrderRepository.Delete(model);
        }

        public IEnumerable<LeaveType> Find(Func<LeaveType, bool> predicate)
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
