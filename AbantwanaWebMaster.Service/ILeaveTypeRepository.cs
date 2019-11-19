using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface ILeaveTypeRepository : IDisposable
    {
        LeaveType GetById(Int32 id);
        List<LeaveType> GetAll();
        void Insert(LeaveType model);
        void Update(LeaveType model);
        void Delete(LeaveType model);
        IEnumerable<LeaveType> Find(Func<LeaveType, bool> predicate);   

    }
}
