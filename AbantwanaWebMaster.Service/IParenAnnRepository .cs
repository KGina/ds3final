using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IParenAnnRepository : IDisposable
    {
        ParentAnnouncement GetById(Int32 id);
        List<ParentAnnouncement> GetAll();
        void Insert(ParentAnnouncement model);
        void Update(ParentAnnouncement model);
        void Delete(ParentAnnouncement model);
        IEnumerable<ParentAnnouncement> Find(Func<ParentAnnouncement, bool> predicate);   

    }
}
