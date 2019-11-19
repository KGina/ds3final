using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IYearRepository : IDisposable
    {
        Year GetById(Int32 id);
        List<Year> GetAll();
        void Insert(Year model);
        void Update(Year model);
        void Delete(Year model);
        IEnumerable<Year> Find(Func<Year, bool> predicate);   

    }
}
