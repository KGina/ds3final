using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
  //  public string comment { get; set; }
    public class learnerSubject
    {
        [Display(Name = "Subject Name")]
        public string Name { get; set; }
        [Display(Name = "Mark")]
        public int mark { get; set; }
        [Display(Name = "Average")]
        public int average { get; set; }
        [Display(Name = "Comment")]
        public string comment { get; set; }
       

    }

    public class learnerReportv
    {
        public IList<learnerReport> learnerReports { get; set; }
    }

        public class learnerReport
    {
      
        [Display(Name = "Learner ID")]
        public string learnerId { get; set; }
        [Display(Name = "Learner ID")]
        public string learnerName { get; set; }
        [Display(Name = "Term Number")]
        public string termNumber { get; set; }
        [Display(Name = "Grade")]
        public string grade { get; set; }
        public string teacher { get; set; }
        [Display(Name = "Result")]
        public string results { get; set; }
        public int daysAbseent { get; set; }
        public string year { get; set; }
        public IList<learnerSubject> learnerSubjects { get; set; }
        
    }
    public class invoiceReport
    {
      
        [Display(Name = "Invoice #")]
        public int feeId { get; set; }
        [Display(Name = "Learner Name")]
        public string learnerName { get; set; }
        
        [Display(Name = "Grade")]
        public string grade { get; set; }
        [Display(Name = "Date Created")]
        public string dateCreated { get; set; }
        public double schoolfee { get; set; }
        public double totalPayed { get; set; }
        public double owedAmount { get; set; }
       
        public IList<Payment> payments { get; set; }
        
    }
    public class learnerMark
    {

        //[Display(Name = "Subject")]
        public string name { get; set; }
        public List<int> mark { get; set; }
        public string result { get; set; }
        public int total { get; set; }
    }
    public class subjectReport
    {
      
        [Display(Name = "Subject")]
        public string name { get; set; }
        [Display(Name = "Learner Name")]
        public string learnerName { get; set; }
        [Display(Name = "Term Number")]
        public string termNumber { get; set; }
        [Display(Name = "Grade")]
        public string grade { get; set; }
        [Display(Name = "Requirement")]
        public string requirement { get; set; }
        // public int daysAbseent { get; set; }
        [Display(Name = "Year")]
        public string year { get; set; }
        public string result { get; set; }
        public int total { get; set; }
        public int wetotal { get; set; }
        public IList<Assessment> assess { get; set; }
        public IList<learnerMark> learnerAssessment { get; set; }
        
    }
}