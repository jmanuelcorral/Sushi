using System;

namespace Sushi.Helpers.Gridhelper
{
    public class GridSkin:ISushiSkin
    {
        public String CssBaseclass { get { return "table"; } }
        public String CssBordered { get { return "table-bordered"; } }
        public String CssZebraStripe { get { return "table-striped"; } }
        public String CssCondensed { get { return "table-condensed"; } }
        
    }
}
