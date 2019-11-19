using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbantwanaWebMaster.Model
{
    [Bind(Exclude = "OrderId")]
    public  class Order
    {
        public int OrderId { get; set; }
       
        public System.DateTime OrderDate { get; set; }
      
        public decimal TotalCost { get; set; }
        public string approval { get; set; }
        public string creator { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}