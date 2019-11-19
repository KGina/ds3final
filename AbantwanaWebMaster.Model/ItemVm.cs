using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AbantwanaWebMaster.Model
{
    public class ItemVm
    {
       public  int ItemVMId { get; set; }

        public string Title { get; set; }
       
        public decimal Price { get; set; }
      
        public byte[] Picture { get; set; }
         
        public string ItemDesciption { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}