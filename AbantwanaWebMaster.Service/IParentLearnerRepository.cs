using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IParentLearnerRepository : IDisposable
    {
        ParentLearner GetById(Int32 id);
        List<ParentLearner> GetAll();
        void Insert(ParentLearner model);
        void Update(ParentLearner model);
        void Delete(ParentLearner model);
        IEnumerable<ParentLearner> Find(Func<ParentLearner, bool> predicate);   

    }
}
