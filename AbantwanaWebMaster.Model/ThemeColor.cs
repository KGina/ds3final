using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Model
{
    public class ThemeColor
    {
            public int colorID { get; set; }
            [DisplayName("Color Name")]
            public string colorName { get; set; }
            public bool archived { get; set; }
    }
}
