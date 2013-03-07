using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;

namespace Sushi.Helpers.NavigationHelper
{
    public class NavigationComponent:ISushiComponent
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public NavType NavigationType { get; set; }
        #endregion
    }
}
