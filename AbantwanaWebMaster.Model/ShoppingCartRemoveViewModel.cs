using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AbantwanaWebMaster.Model
{
    public class ShoppingCartRemoveViewModel
    {
        public string Message { get; set; }
        public decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int Quatity { get; set; }

        public int DeleteId { get; set; }
    }
}