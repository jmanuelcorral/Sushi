using System;
using Sushi.Html;

namespace Sushi.SideBarHelper
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
