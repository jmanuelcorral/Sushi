using System;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.PanelHelper
{
    public class PanelComponent:ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public String InnerHtml { get; set; }
        #endregion
    }
}
