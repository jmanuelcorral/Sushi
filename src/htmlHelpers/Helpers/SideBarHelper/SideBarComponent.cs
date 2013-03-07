using System;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.SideBarHelper
{
    public class SideBarComponent :ISushiComponent
    {
        
        #region Properties
        /// <summary>
        /// Base Attributes of HtmlObject
        /// </summary>
        public HtmlProperties HtmlProperties { get; set; }
        public String InnerHtml { get; set; }
      
        #endregion

   


    }
}
