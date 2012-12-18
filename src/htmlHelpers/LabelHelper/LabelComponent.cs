using System;
using Sushi.Html;


namespace Sushi.LabelHelper
{
    public class LabelComponent:ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public String For { get; set; }
        #endregion
    }
}
