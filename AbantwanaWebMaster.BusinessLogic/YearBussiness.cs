using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbantwanaWebMaster.Data;
using AbantwanaWebMaster.Model;
using AbantwanaWebMaster.Service;

namespace AbantwanaWebMaster.BusinessLogic
{
    public class YearBussiness
    {
        DataContext db = new DataContext();
        public List<Model.Year> getYear()
        {

            using (var leaveRepo = new YearRepository  ())
            {
                return leaveRepo.GetAll().Select(x => new Model.Year() {yearId=x.yearId,year=x.year }).ToList();
            }
        }
        
        public void createYear(Model.Year x)
        {
            
            using (var leaveRepo = new YearRepository())
            {
                if (x != null)
                {
                    
                    var leaveCreate = new Data.Year() { yearId = x.yearId, year = x.year };
                    leaveRepo.Insert(leaveCreate);
                }
            }
       
        }

        public void updateYear(Model.Year x)
        {

            using (var leaveRepo = new YearRepository())
            {
                if (x != null)
                {

                    var leaveCreate = new Data.Year() { yearId = x.yearId, year = x.year };
                    leaveRepo.Update(leaveCreate);
                }
            }

        }



    }
}
