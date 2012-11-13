using System;
using System.Collections.Generic;
using Sushi.Html;

namespace Sushi.NavigationHelper
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
