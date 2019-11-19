using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbantwanaWebMaster.Data
{
    public class Cart
    {
        public object parentId;

        [Key]
       
        public int CartId { get; set; }
        public string UserId { get; set; }
        public int ItemId { get; set; }
        // public int Count { get; set; }
        [Required(AllowEmptyStrings = true, ErrorMessage = " ")]
        [Range(0, 100, ErrorMessage = "Quantity must be between 0 and 100")]
        //DisplayName("Quantity")]
        public int Quantity { get; set; }

        public int? orderId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool CheckOut { get; set; }

        public virtual Item Item { get; set; }

        public virtual Order Orders { get; set; }
    }
}


