using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class WorkScheduleRepository:IWorkScheduleRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<WorkSchedule> _WorkScheduleRepository;

        public WorkScheduleRepository()
        {
            _datacontext = new DataContext();
            _WorkScheduleRepository = new RepositoryService<WorkSchedule>(_datacontext);
            
        }

        public WorkSchedule GetById(int id)
        {
           return _WorkScheduleRepository.GetById(id);
        }

        public List<WorkSchedule> GetAll()
        {
            return _WorkScheduleRepository.GetAll().ToList();
        }

        public void Insert(WorkSchedule model)
        {
            _WorkScheduleRepository.Insert(model);
        }

        public void Update(WorkSchedule model)
        {
            _WorkScheduleRepository.Update(model);
        }

        public void Delete(WorkSchedule model)
        {
            _WorkScheduleRepository.Delete(model);
        }

        public IEnumerable<WorkSchedule> Find(Func<WorkSchedule, bool> predicate)
        {
           return _WorkScheduleRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
