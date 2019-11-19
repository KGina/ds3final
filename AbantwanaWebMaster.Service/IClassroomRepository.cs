using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IClassRoomRepository: IDisposable
    {
        ClassRoom GetById(Int32 id);
        List<ClassRoom> GetAll();
        void Insert(ClassRoom model);
        void Update(ClassRoom model);
        void Delete(ClassRoom model);
        IEnumerable<ClassRoom> Find(Func<ClassRoom, bool> predicate);   

    }
}
