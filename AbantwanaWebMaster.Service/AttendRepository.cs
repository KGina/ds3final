using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;


namespace AbantwanaWebMaster.Service
{
    public class AttendRepository : IAttendRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<Attendance> _AssessmentRepository;

        public AttendRepository()
        {
            _datacontext = new DataContext();
            _AssessmentRepository = new RepositoryService<Attendance>(_datacontext);

        }

        public Attendance GetById(int id)
        {
            return _AssessmentRepository.GetById(id);
        }

        public List<Attendance> GetAll()
        {
            return _AssessmentRepository.GetAll().ToList();
        }

        public void Insert(Attendance model)
        {
            _AssessmentRepository.Insert(model);
        }

        public void Update(Attendance model)
        {
            _AssessmentRepository.Update(model);
        }

        public void Delete(Attendance model)
        {
            _AssessmentRepository.Delete(model);
        }


        public IEnumerable<Attendance> Find(Func<Attendance, bool> predicate)
        {
            return _AssessmentRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }

    }
}
