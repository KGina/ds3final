using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
   public class Term
    {
        public int termId { get; set; }
        public string name { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
       // public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
