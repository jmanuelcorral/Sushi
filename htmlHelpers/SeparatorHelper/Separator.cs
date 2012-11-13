using System;

namespace Sushi.SeparatorHelper
{
    public class Separator:ISushiComponentBuilder
    {

        #region IHtmlString

        public override String ToString()
        {
            return "<li class=\"divider\"></li>";
        }

        public String ToHtmlString()
        {
            return this.ToString();
        }
        #endregion

        public System.Web.Mvc.ViewContext ViewContext
        {
            get { throw new NotImplementedException(); }
        }
    }
}
