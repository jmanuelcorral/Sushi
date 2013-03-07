using System;
using System.Collections.Generic;
using Sushi.Helpers.Html;
using Sushi.Helpers.IconHelper;

namespace Sushi.Helpers.LinkHelper
{
    public class LinkComponent:ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public Icon LinkIcon { get; set; }
        public String Action { get; set; }
        public Boolean Active { get; set; }
        public List<String> cssClasses { get; set; }
        public Dictionary<String, String> Attributes { get; set; }
        #endregion


    }
}
