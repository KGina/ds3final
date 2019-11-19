using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
    public class ParentLearner
    {
        public int parentid { get; set; }
        public virtual Parent Parent { get; set; }

        public int learnerId { get; set; }
        public virtual LearnerProfile LearnerProfile { get; set; }


    }
}
