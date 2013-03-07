using Sushi.Helpers.Html;

namespace Sushi.Helpers.ButtonGroupHelper
{
    public class ButtonGroupComponent:ISushiComponent,ISushiSkinnable
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public ISushiSkin Skin { get; set; }
        #endregion

        
        
    }
}
