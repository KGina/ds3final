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
    public class ThemeColorBusiness
    {
        DataContext db = new DataContext();
        public List<Model.ThemeColor>  GetThemeColors()
        {

            using (var leaveRepo = new ThemeColorRepository  ())
            {
                return leaveRepo.GetAll().Where(k=>k.archived==false).Select(x => new Model.ThemeColor() {colorID=x.colorID, colorName=x.colorName }).ToList();
            }
        }
        public bool acrhiveType(int ReqID )
        {
            if (ReqID!=0)
            {
                var colors = db.colors.Where(k => k.colorID == ReqID).FirstOrDefault();
                colors.archived = true;
                db.Entry(colors).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
        public void createLeaveType(Model.ThemeColor leave)
        {
            
            using (var colorRepo = new ThemeColorRepository())
            {
                if (leave != null)
                {
                    
                    var colorCreate = new Data.ThemeColor() { colorID=leave.colorID,colorName=leave.colorName};
                    colorRepo.Insert(colorCreate);
                }
            }
       
        }

        public void updateLeaveType(Model.ThemeColor leave)
        {

            using (var colorRepo = new ThemeColorRepository())
            {
                if (leave != null)
                {

                    var colorCreate = new Data.ThemeColor() { colorID = leave.colorID, colorName = leave.colorName };
                    colorRepo.Update(colorCreate);
                }
            }

        }



    }
}
