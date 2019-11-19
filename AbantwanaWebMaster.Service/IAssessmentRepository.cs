using AbantwanaWebMaster.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Service
{
    public interface IAssessmentRepository :IDisposable
    {
        Assessment GetById(Int32 id);
        List<Assessment> GetAll();
        void Insert(Assessment model);
        void Update(Assessment model);
        void Delete(Assessment model);
        IEnumerable< Assessment> Find(Func<Assessment, bool> predicate);
    }
}
