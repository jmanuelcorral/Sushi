using Sushi.Enums;
using Sushi.Html;
using Sushi.InputHelper;
using Sushi.LabelHelper;


namespace Sushi.FieldHelper
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
