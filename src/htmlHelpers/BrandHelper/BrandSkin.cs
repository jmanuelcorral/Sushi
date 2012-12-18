using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sushi.BrandHelper
{
    public class BrandSkin:ISushiSkin
    {
        public string CssBaseclass
        {
            get { return "brand"; }
        }
    }
}
