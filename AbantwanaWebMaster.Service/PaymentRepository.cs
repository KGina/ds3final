using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class PaymentRepository : IPaymentRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Payment> _OrderRepository;

        public PaymentRepository()
        {
            _datacontext = new DataContext();
            _OrderRepository = new RepositoryService<Payment>(_datacontext);
            
        }

        public Payment GetById(int id)
        {
           return _OrderRepository.GetById(id);
        }

        public List<Payment> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public void Insert(Payment model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(Payment model)
        {
            _OrderRepository.Update(model);
        }

        public void Delete(Payment model)
        {
            _OrderRepository.Delete(model);
        }

        public IEnumerable<Payment> Find(Func<Payment, bool> predicate)
        {
           return _OrderRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
