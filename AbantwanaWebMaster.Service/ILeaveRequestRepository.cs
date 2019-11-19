using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface ILeaveRequestRepository : IDisposable
    {
        LeaveRequest GetById(Int32 id);
        List<LeaveRequest> GetAll();
        void Insert(LeaveRequest model);
        void Update(LeaveRequest model);
        void Delete(LeaveRequest model);
        IEnumerable<LeaveRequest> Find(Func<LeaveRequest, bool> predicate);   

    }
}
