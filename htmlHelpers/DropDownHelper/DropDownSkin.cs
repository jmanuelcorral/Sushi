using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sushi.DropDownHelper
{
    public class DropDownSkin :ISushiSkin
    {
        public string CssBaseclass
        {
            get { return "dropdown-menu"; }
        }
    }
}
