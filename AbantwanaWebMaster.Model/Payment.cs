using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AbantwanaWebMaster.Model
{
    public class Payment
    {
        public int pymentId { get; set; }
        //public virtual Year year { get; set; }

        public int parentId { get; set; }
        // public virtual Parent parent { get; set; }
        [DisplayName("Reference No.")]
        public int feeId { get; set; }
        //public virtual Fees fees { get; set; }

        public DateTime datetimeCreated { get; set; }
        public string createdatetime { get; set; }
        public string payer { get; set; }
        [DisplayName("Amount")]

        public double amountPayed { get; set; }

    }

}
