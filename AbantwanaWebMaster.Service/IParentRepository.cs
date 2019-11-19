using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IParentRepository : IDisposable
    {
        Parent GetById(Int32 id);
        List<Parent> GetAll();
        void Insert(Parent model);
        void Update(Parent model);
        void Delete(Parent model);
        IEnumerable<Parent> Find(Func<Parent, bool> predicate);   

    }
}
