using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class OrderRepository:IOrderRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Order> _OrderRepository;

        public OrderRepository()
        {
            _datacontext = new DataContext();
            _OrderRepository = new RepositoryService<Order>(_datacontext);
            
        }

        public Order GetById(int id)
        {
           return _OrderRepository.GetById(id);
        }

        public List<Order> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public void Insert(Order model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(Order model)
        {
            _OrderRepository.Update(model);
        }

        public void Delete(Order model)
        {
            _OrderRepository.Delete(model);
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
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
