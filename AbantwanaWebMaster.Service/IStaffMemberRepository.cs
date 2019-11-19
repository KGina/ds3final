using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IStaffMemberRepository : IDisposable
    {
        StaffMember GetById(Int32 id);
        List<StaffMember> GetAll();
        void Insert(StaffMember model);
        void Update(StaffMember model);
        void Delete(StaffMember model);
        IEnumerable<StaffMember> Find(Func<StaffMember, bool> predicate);   

    }
}
