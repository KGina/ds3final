using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Data
{
   public class Supplier
    {
        public int SupplierId { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string physicaladdress { get; set; }
        public int phonenumber { get; set; }

        public virtual ICollection<Item> Items { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }
        public bool archive { get; set; }
    }
}
