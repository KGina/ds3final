using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace AbantwanaWebMaster.Model
{
    [Bind(Exclude = "ItemId")]
    public class Item
    {

        [ScaffoldColumn(false)]
        public int ItemId { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        //[DisplayName("Supplier")]
        //public int SupplierId { get; set; }
        [Required(ErrorMessage = "An Item name is required")]
        [StringLength(160)]
        [DisplayName("Name")]
        public string ItemName { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0.1, 1000000, ErrorMessage = "price Must be between 0.1 and 100")]

        public decimal Price { get; set; }
        [DisplayName("Picture")]
        public byte[] Picture { get; set; }
        [StringLength(500)]
        public string ItemDesciption { get; set; }
        //public string supplierName { get; set; }
        public string catergoryName { get; set; }
        public bool archive { get; set; }

        public virtual Category Category { get; set; }
        //public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }



    }
}