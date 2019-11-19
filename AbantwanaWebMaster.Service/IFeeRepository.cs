using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IFeeRepository : IDisposable
    {
        Fees GetById(Int32 id);
        List<Fees> GetAll();
        void Insert(Fees model);
        void Update(Fees model);
        void Delete(Fees model);
        IEnumerable<Fees> Find(Func<Fees, bool> predicate);

    }
}
