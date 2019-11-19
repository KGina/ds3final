using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AbantwanaWebMaster.Data;

namespace AbantwanaWebMaster.Service
{
    public class StaffMemberRepository: IStaffMemberRepository
    {
        private DataContext _datacontext = null;
        private readonly IRepository<StaffMember> _StaffMemberRepository;

        public StaffMemberRepository()
        {
            _datacontext = new DataContext();
            _StaffMemberRepository = new RepositoryService<StaffMember>(_datacontext);
            
        }

        public StaffMember GetById(int id)
        {
           return _StaffMemberRepository.GetById(id);
        }

        public List<StaffMember> GetAll()
        {
            return _StaffMemberRepository.GetAll().ToList();
        }

        public void Insert(StaffMember model)
        {
            _StaffMemberRepository.Insert(model);
        }

        public void Update(StaffMember model)
        {
            _StaffMemberRepository.Update(model);
        }

        public void Delete(StaffMember model)
        {
            _StaffMemberRepository.Delete(model);
        }

        public IEnumerable<StaffMember> Find(Func<StaffMember, bool> predicate)
        {
           return _StaffMemberRepository.Find(predicate).ToList();
        }

        public void Dispose()
        {
            _datacontext.Dispose();
            _datacontext = null;
        }
    }
}
