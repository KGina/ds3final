using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Data
{
    // [Bind(Exclude = "OrderId")]
    public partial class Order
    {
        //[ScaffoldColumn(false)]
        public int OrderId { get; set; }
        

       // [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }     
        //[ScaffoldColumn(true)]
        public decimal TotalCost { get; set; }
        public string approval { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }

        //public List<OrderDetail> OrderDetails { get; set; }
        //public virtual ICollection<Order> Orders { get; set; }

    }
}