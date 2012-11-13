using Sushi.Enums;
using Sushi.Html;

namespace Sushi.NavigationHelper
{
    public class NavigationComponent:ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public NavType NavigationType { get; set; }
        #endregion
    }
}
