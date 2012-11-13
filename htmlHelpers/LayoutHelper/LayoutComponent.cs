using System;
using Sushi.Enums;
using Sushi.Html;

namespace Sushi.LayoutHelper
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
