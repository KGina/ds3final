using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IYearLearnerClassRoomRepository : IDisposable
    {
        YearLearnerClassRoom GetById(Int32 id);
        List<YearLearnerClassRoom> GetAll();
        void Insert(YearLearnerClassRoom model);
        void Update(YearLearnerClassRoom model);
        void Delete(YearLearnerClassRoom model);
        IEnumerable<YearLearnerClassRoom> Find(Func<YearLearnerClassRoom, bool> predicate);   

    }
}
