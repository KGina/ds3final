using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface ILearnerProfileRepository : IDisposable
    {
        LearnerProfile GetById(Int32 id);
        List<LearnerProfile> GetAll();
        void Insert(LearnerProfile model);
        void Update(LearnerProfile model);
        void Delete(LearnerProfile model);
        IEnumerable<LearnerProfile> Find(Func<LearnerProfile, bool> predicate);   

    }
}
