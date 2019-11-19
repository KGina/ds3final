using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public interface IPaymentRepository : IDisposable
    {
        Payment GetById(Int32 id);
        List<Payment> GetAll();
        void Insert(Payment model);
        void Update(Payment model);
        void Delete(Payment model);
        IEnumerable<Payment> Find(Func<Payment, bool> predicate);

    }
}
