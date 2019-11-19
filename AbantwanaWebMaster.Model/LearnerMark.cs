using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AbantwanaWebMaster.Model
{
    public class LearnerMark
    {
        public int SubjectId { get; set; }
        public int learnerId { get; set; }

        [DisplayName("Final Mark")]
        public decimal FinalMark { get; set; }
    }
}
