using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IAttendRepository : IDisposable
    {
        Attendance GetById(Int32 id);
        List<Attendance> GetAll();
        void Insert(Attendance model);
        void Update(Attendance model);
        void Delete(Attendance model);
        IEnumerable<Attendance> Find(Func<Attendance, bool> predicate);   

    }
}
