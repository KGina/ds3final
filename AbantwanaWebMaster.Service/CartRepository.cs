using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class CartRepository : ICartRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Cart> _CartRepository;

        public CartRepository()
        {
            _datacontext = new DataContext();
            _CartRepository = new RepositoryService<Cart>(_datacontext);

        }

        public Cart GetById(int id)
        {
            return _CartRepository.GetById(id);
        }

        public List<Cart> GetAll()
        {
            return _CartRepository.GetAll().ToList();
        }

        public void Insert(Cart model)
        {
            _CartRepository.Insert(model);
        }

        public void Update(Cart model)
        {
            _CartRepository.Update(model);
        }

        public void Delete(Cart model)
        {
            _CartRepository.Delete(model);
        }

        public IEnumerable<Cart> Find(Func<Cart, bool> predicate)
        {
            return _CartRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
