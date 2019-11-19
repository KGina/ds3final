using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface ICartRepository : IDisposable
    {
        Cart GetById(Int32 id);
        List<Cart> GetAll();
        void Insert(Cart model);
        void Update(Cart model);
        void Delete(Cart model);
        IEnumerable<Cart> Find(Func<Cart, bool> predicate);

    }
}
