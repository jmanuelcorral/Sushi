using System;
using System.Collections.Generic;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.InputHelper
{
    public class InputComponent:ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public GridSize Size { get; set; }
        public List<String> CSSClasses { get; set; }
        public Dictionary<String,String> Attributes { get; set; } 
        #endregion
    }
}
