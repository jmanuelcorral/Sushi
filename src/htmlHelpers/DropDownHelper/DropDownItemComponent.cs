using System;
using Sushi.Html;

namespace Sushi.DropDownHelper
{
    public class DropDownItemComponent : ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public String Action { get; set; }
        #endregion
    }
}
