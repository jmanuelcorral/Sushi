using System;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.LabelHelper
{
    public class LabelComponent:ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public String For { get; set; }
        #endregion
    }
}
