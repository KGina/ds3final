using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AbantwanaWebMaster.Model
{
   public class Term
    {
        public int termId { get; set; }
        [DisplayName("Term")]
        public string name { get; set; }
        public virtual ICollection<Assessment> Assessments { get; set; }
       // public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
