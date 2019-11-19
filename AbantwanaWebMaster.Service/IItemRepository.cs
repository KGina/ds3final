using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IItemRepository: IDisposable
    {
        Item GetById(Int32 id);
        List<Item> GetAll();
        void Insert(Item model);
        void Update(Item model);
        void Delete(Item model);
        IEnumerable<Item> Find(Func<Item, bool> predicate);   

    }
}
