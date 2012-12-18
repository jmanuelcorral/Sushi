using System;
using Sushi.Html;

namespace Sushi.PanelHelper
{
    public class PanelComponent:ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public String InnerHtml { get; set; }
        #endregion
    }
}
