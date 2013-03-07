using System;

namespace Sushi.Helpers.ButtonHelper
{
    public class ButtonSkin :ISushiSkin
    {
        #region Constants
        public String CssBaseclass { get { return "btn"; } }
        public String CssDisable { get { return "btn-disabled"; } } 
        public String CssPrimaryClass { get { return "btn-primary"; } }
        public String CssInfoClass { get { return "btn-info"; } }
        public String CssDangerClass { get { return "btn-danger"; } }
        public String CssSuccessClass { get { return "btn-success"; } }
        public String CssNormalClass { get { return "btn-normal"; } }
        public String CssLargeClass { get { return "btn-large"; } }
        public String CssSmallClass { get { return "btn-small"; } }
        #endregion

    }
}
