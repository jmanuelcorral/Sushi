using Sushi.Html;

namespace Sushi.DropDownHelper
{
    public class DropDownComponent:ISushiComponent,ISushiSkinnable
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public ISushiSkin Skin { get; set; }
        #endregion
    }
}
