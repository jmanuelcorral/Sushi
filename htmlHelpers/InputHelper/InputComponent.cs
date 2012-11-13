using System;
using System.Collections.Generic;
using Sushi.Enums;
using Sushi.Html;

namespace Sushi.InputHelper
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
