using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AbantwanaWebMaster.Model
{
    public class ClassRoom
    {
        public int classRoomId { get; set; }
        [DisplayName("Room Number")]
        [Required]
        public string roomnumber { get; set; }
        [DisplayName("Class Name")]
        [Required]
        public string className { get; set; }
        public string gradename { get; set; }
        [DisplayName("Teacher")]
        public string teachername { get; set; }
        [DisplayName("Teacher")]
        [Required]
        public int staffId { get; set; }
        public virtual StaffMember Staff { get; set; }
        [DisplayName("Grade")]
        public int graddId { get; set; }
        public virtual Grade grade { get; set; }


    
      }
    public class GoToReport
    {
        [DisplayName("Grade")]
        public int graddId { get; set; }
        [DisplayName("Year")]
        public int yearId { get; set; }
        [DisplayName("Term")]
        public int termId { get; set; }
       
      }
}
