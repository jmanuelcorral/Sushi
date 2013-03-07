using Sushi.Helpers.Enums;
using Sushi.Helpers.Html;
using Sushi.Helpers.InputHelper;
using Sushi.Helpers.LabelHelper;

namespace Sushi.Helpers.FieldHelper
{
    public class FieldComponent:ISushiComponent, ISushiSkinnable
    {
        #region Properties
        /// <summary>
        /// Base Attributes of HtmlObject
        /// </summary>
        public HtmlProperties HtmlProperties { get; set; }
        public Label Label { get; set; }
        public Input Input { get; set; }
        public FieldType Type { get; set; }
        public ISushiSkin Skin { get; set; }
        #endregion
    }
}
