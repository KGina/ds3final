using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class ClassroomRepository: IClassRoomRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<ClassRoom> _ClassroomRepository;

        public ClassroomRepository()
        {
            _datacontext = new DataContext();
            _ClassroomRepository = new RepositoryService<ClassRoom>(_datacontext);
            
        }

        public ClassRoom GetById(int id)
        {
           return _ClassroomRepository.GetById(id);
        }

        public List<ClassRoom> GetAll()
        {
            return _ClassroomRepository.GetAll().ToList();
        }

        public void Insert(ClassRoom model)
        {
            _ClassroomRepository.Insert(model);
        }

        public void Update(ClassRoom model)
        {
            _ClassroomRepository.Update(model);
        }

        public void Delete(ClassRoom model)
        {
            _ClassroomRepository.Delete(model);
        }

        public IEnumerable<ClassRoom> Find(Func<ClassRoom, bool> predicate)
        {
           return _ClassroomRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
