using System;
using System.Collections.Generic;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.NavigationHelper
{
    public class NavigationItemComponent:ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public List<String> cssClasses { get; set; }
        public Boolean Active { get; set; }
        #endregion

    }
}
