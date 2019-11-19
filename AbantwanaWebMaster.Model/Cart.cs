using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AbantwanaWebMaster.Model
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public string UserId { get; set; }
        public int ItemId { get; set; }
       public string itemname { get; set; }
       public string description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal subTotal { get; set; }
        //public int Quatity { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool CheckOut { get; set; }

        public virtual Item Item { get; set; }
        public int? orderId { get; set; }
        public virtual Order Orders { get; set; }


    }
}


