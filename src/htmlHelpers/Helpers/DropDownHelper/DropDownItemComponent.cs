using System;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.DropDownHelper
{
    public class DropDownItemComponent : ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public String Action { get; set; }
        #endregion
    }
}
