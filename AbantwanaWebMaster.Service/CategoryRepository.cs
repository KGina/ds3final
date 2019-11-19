using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class CategoryRepository : ICategoryRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Category> _CategoryRepository;

        public CategoryRepository()
        {
            _datacontext = new DataContext();
            _CategoryRepository = new RepositoryService<Category>(_datacontext);

        }

        public Category GetById(int id)
        {
            return _CategoryRepository.GetById(id);
        }

        public List<Category> GetAll()
        {
            return _CategoryRepository.GetAll().ToList();
        }

        public void Insert(Category model)
        {
            _CategoryRepository.Insert(model);
        }

        public void Update(Category model)
        {
            _CategoryRepository.Update(model);
        }

        public void Delete(Category model)
        {
            _CategoryRepository.Delete(model);
        }

        public IEnumerable<Category> Find(Func<Category, bool> predicate)
        {
            return _CategoryRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
