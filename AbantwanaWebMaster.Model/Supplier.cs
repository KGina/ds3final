using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace AbantwanaWebMaster.Model
{
   public class Supplier
    {
        [Display(Name = "Name")]
        public int supplierID { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Physical Address")]
        public string physicaladdress { get; set; }
        [Display(Name = "Phone Number")]
        public int phonenumber { get; set; }
        public int orderID { get; set; }
        public bool archive { get; set; }
    }
}
