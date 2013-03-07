using System;
using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.MenuHelper
{
    public class MenuComponent: ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public String InnerHtml { get; set; }
        public MenuPosition Position { get; set; }
        public MenuBehaviour Behaviour { get; set; }
        public ContainerLayoutType ContainerType { get; set; }
        public String BrandName { get; set; }
        #endregion
    }
}
