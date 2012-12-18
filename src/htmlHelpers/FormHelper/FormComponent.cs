using System;
using System.Collections.Generic;
using Sushi.Html;

namespace Sushi.FormHelper
{
    public class FormComponent:ISushiComponent
    {
        #region Properties
        public List<String> CSSClasses { get; set; }
        public HtmlProperties HtmlProperties { get; set; }
        public String Action { get; set; }
        #endregion
    }
}
