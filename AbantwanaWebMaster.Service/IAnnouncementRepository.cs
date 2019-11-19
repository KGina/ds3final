using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IAnnouncementRepository: IDisposable
    {
        Announcement GetById(Int32 id);
        List<Announcement> GetAll();
        void Insert(Announcement model);
        void Update(Announcement model);
        void Delete(Announcement model);
        IEnumerable<Announcement> Find(Func<Announcement, bool> predicate);   

    }
}
