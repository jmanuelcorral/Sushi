using Sushi.Helpers.Html;

namespace Sushi.Helpers.DropDownHelper
{
    public class DropDownComponent:ISushiComponent,ISushiSkinnable
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public ISushiSkin Skin { get; set; }
        #endregion
    }
}
