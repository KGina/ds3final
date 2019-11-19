using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IConnectionRepository : IDisposable
    {
        Connection GetById(Int32 id);
        List<Connection> GetAll();
        void Insert(Connection model);
        void Update(Connection model);
        void Delete(Connection model);
        IEnumerable<Connection> Find(Func<Connection, bool> predicate);   

    }
}
