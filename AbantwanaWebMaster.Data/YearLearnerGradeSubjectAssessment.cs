﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   
    public class YearLearnerGradeSubjectAssessment
    {
        public int yearId { get; set; }
        public virtual Year year { get; set; }
        public int learnerId { get; set; }
        public virtual LearnerProfile learnerProfiles { get; set; }
        public int gradeId { get; set; }
        public virtual Grade grade { get; set; }
        public int subjectId { get; set; }
        public virtual Subject subject { get; set; }
        public int assessmentId { get; set; }
        public virtual Assessment assessment { get; set; }
        public int mark { get; set; }

    }
    
}
