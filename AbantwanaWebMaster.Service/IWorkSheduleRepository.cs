using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IWorkScheduleRepository: IDisposable
    {
        WorkSchedule GetById(Int32 id);
        List<WorkSchedule> GetAll();
        void Insert(WorkSchedule model);
        void Update(WorkSchedule model);
        void Delete(WorkSchedule model);
        IEnumerable<WorkSchedule> Find(Func<WorkSchedule, bool> predicate);   

    }
}
