using System;
using System.Collections.Generic;
using Sushi.Html;

namespace Sushi.LinkHelper
{
    public class LinkComponent:ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public IconHelper.Icon LinkIcon { get; set; }
        public String Action { get; set; }
        public Boolean Active { get; set; }
        public List<String> cssClasses { get; set; }
        public Dictionary<String, String> Attributes { get; set; }
        #endregion


    }
}
