using System;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.LayoutHelper
{
    public class LayoutComponent:ISushiComponent
    {
        
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public String InnerHtml { get; set; }
        public LayoutType? Layout { get; set; }
        public GridSize? LayoutSize { get; set; }
        #endregion

    }
}
