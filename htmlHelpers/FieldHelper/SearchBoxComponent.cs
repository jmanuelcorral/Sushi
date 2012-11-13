using Sushi.FormHelper;
using Sushi.Html;
using Sushi.InputHelper;


namespace Sushi.FieldHelper
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
