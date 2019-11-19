using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
  //  public string comment { get; set; }
    public class gradeSubject
    {
        [Display(Name = "Subject Name")]
        public string Name { get; set; }
        [Display(Name = "Pass Rate")]
        public int passRate { get; set; }
        [Display(Name = "Fail Rate")]
        public int failRate { get; set; }
        [Display(Name = "Average")]
        public int average { get; set; }
        
    }
    public class gradeReport
    {
      
        [Display(Name = "Grade Name")]
        public string gradeName { get; set; }
        [Display(Name = "Term")]
        public string term { get; set; }
        [Display(Name = "Term Number")]
        public string termNumber { get; set; }
        [Display(Name = "Date Generated")]
        public string dateGenerated { get; set; }
        public IList<gradeSubject> gradeSubjects { get; set; }
        
    }
}