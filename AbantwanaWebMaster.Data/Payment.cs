using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   public class Payment
    {
        public int pymentId { get; set; }
        //public virtual Year year { get; set; }

        public int parentId { get; set; }
        public virtual Parent parent { get; set; }
        public int feeId { get; set; }
        public virtual Fees fees { get; set; }

        public DateTime datetimeCreated { get; set; }
        public double amountPayed { get; set; }

    }

}
