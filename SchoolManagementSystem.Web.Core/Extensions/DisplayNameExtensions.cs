using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AbantwanaWebMaster.Core.Extensions
{
    public static class DisplayNameExtensions
    {
        public static MvcHtmlString EnumDisplayNameFor(this HtmlHelper html, Enum item)
        {
            var type = item.GetType();
            var member = type.GetMember(item.ToString());
            DisplayAttribute displayname = (DisplayAttribute)member[0].GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();

            if (displayname != null)
            {
                return new MvcHtmlString(displayname.Name);
            }

            return new MvcHtmlString(item.ToString());
        }
    }
}
