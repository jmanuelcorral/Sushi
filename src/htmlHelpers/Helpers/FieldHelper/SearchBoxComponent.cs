using Sushi.Helpers.FormHelper;
using Sushi.Helpers.Html;
using Sushi.Helpers.InputHelper;

namespace Sushi.Helpers.FieldHelper
{
    public class SearchBoxComponent:ISushiComponent,ISushiSkinnable
    {
        #region Properties
        public HtmlProperties HtmlProperties { get; set; }
        public Form Form { get; set; }
        public Input Input { get; set; }
        public ISushiSkin Skin { get; set; }
        #endregion
    }
}
