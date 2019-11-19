using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class ThemeColorRepository : IThemeColorRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<ThemeColor> _ThemeColorRepository;

        public ThemeColorRepository()
        {
            _datacontext = new DataContext();
            _ThemeColorRepository = new RepositoryService<ThemeColor>(_datacontext);
            
        }

        public ThemeColor GetById(int id)
        {
           return _ThemeColorRepository.GetById(id);
        }

        public List<ThemeColor> GetAll()
        {
            return _ThemeColorRepository.GetAll().ToList();
        }

        public void Insert(ThemeColor model)
        {
            _ThemeColorRepository.Insert(model);
        }

        public void Update(ThemeColor model)
        {
            _ThemeColorRepository.Update(model);
        }

        public void Delete(ThemeColor model)
        {
            _ThemeColorRepository.Delete(model);
        }

        public IEnumerable<ThemeColor> Find(Func<ThemeColor, bool> predicate)
        {
           return _ThemeColorRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
