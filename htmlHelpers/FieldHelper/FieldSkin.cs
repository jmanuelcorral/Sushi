using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sushi.FieldHelper
{
    public class FieldSkin:ISushiSkin
    {
        public string CssBaseclass
        {
            get { return "clearfix"; }
        }

        public string CssInputClass
        {
            get { return "input"; }
        }
    }
}
