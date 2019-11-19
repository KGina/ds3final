using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class YearLearnerClassRoomRepository : IYearLearnerClassRoomRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<YearLearnerClassRoom> _OrderRepository;

        public YearLearnerClassRoomRepository()
        {
            _datacontext = new DataContext();
            _OrderRepository = new RepositoryService<YearLearnerClassRoom>(_datacontext);
            
        }

        public YearLearnerClassRoom GetById(int id)
        {
           return _OrderRepository.GetById(id);
        }

        public List<YearLearnerClassRoom> GetAll()
        {
            return _OrderRepository.GetAll().ToList();
        }

        public void Insert(YearLearnerClassRoom model)
        {
            _OrderRepository.Insert(model);
        }

        public void Update(YearLearnerClassRoom model)
        {
            _OrderRepository.Update(model);
        }

        public void Delete(YearLearnerClassRoom model)
        {
            _OrderRepository.Delete(model);
        }

        public IEnumerable<YearLearnerClassRoom> Find(Func<YearLearnerClassRoom, bool> predicate)
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
