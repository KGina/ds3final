using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface ISubjectRepository : IDisposable
    {
        Subject GetById(Int32 id);
        List<Subject> GetAll();
        void Insert(Subject model);
        void Update(Subject model);
        void Delete(Subject model);
        IEnumerable<Subject> Find(Func<Subject, bool> predicate);
    }
}
