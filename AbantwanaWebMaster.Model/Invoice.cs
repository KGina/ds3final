using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Model
{
   public class Invoice
    {
        public int invoiceid { get; set; }
        public decimal totalcost { get; set; }

        public string type { get; set; }
        public DateTime date { get; set; }
    }
}
