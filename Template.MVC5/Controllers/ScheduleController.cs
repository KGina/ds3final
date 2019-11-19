using AbantwanaWebMaster.BusinessLogic;
using AbantwanaWebMaster.Model;
using System.Web.Mvc;

namespace AbantwanaWebMaster.MVC5.Controllers
{
    public class ScheduleController : Controller
    {
        ScheduleBussiness scheduleObj = new ScheduleBussiness();
        ThemeColorBusiness ThemeColor = new ThemeColorBusiness();
        // GET: Schedule
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TeacherIndex()
        {
            return View();
        }
        public JsonResult GetworkTeacherSchedules()
        {

            return new JsonResult { Data = scheduleObj.GetworkTeacherSchedules(User.Identity.Name), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetworkSchedules()
        {
            
            return new JsonResult { Data = scheduleObj.GetworkSchedules(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetClassRooms()
        {
           
            return new JsonResult { Data = scheduleObj.GetClassroms(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetThemeColors()
        {
            return new JsonResult { Data = ThemeColor.GetThemeColors(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        public JsonResult GetResources()
        {

            return new JsonResult { Data = scheduleObj.GetResources(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public JsonResult checkWorkSchedule(WorkSchedule wrks)
        {
            return new JsonResult { Data = scheduleObj.checkWorkSchedule(wrks), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
        [HttpPost]
        public JsonResult SaveWorkSchedule(WorkSchedule wrks)
        {
            return new JsonResult { Data = new { status = scheduleObj.saveWork(wrks) } };
        }
        [HttpPost]
        public JsonResult updateWorkSchedule(WorkSchedule wrks)
        {
            return new JsonResult { Data = new { status = scheduleObj.updateWorkSchedule(wrks) } };
        }
        [HttpPost]
        public JsonResult DeleteEvent(int scheduleId)
        {
            return new JsonResult { Data = new { status = scheduleObj.delSchedule(scheduleId) } };
        }
        }
}